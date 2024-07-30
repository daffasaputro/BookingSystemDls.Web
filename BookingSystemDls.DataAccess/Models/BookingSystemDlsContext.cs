using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemDls.DataAccess.Models;

public partial class BookingSystemDlsContext : DbContext
{
    public BookingSystemDlsContext()
    {
    }

    public BookingSystemDlsContext(DbContextOptions<BookingSystemDlsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mstbookingcode> Mstbookingcodes { get; set; }

    public virtual DbSet<Mstlocation> Mstlocations { get; set; }

    public virtual DbSet<Mstmenu> Mstmenus { get; set; }

    public virtual DbSet<Mstresource> Mstresources { get; set; }

    public virtual DbSet<Mstrole> Mstroles { get; set; }

    public virtual DbSet<Mstroom> Mstrooms { get; set; }

    public virtual DbSet<Mstuser> Mstusers { get; set; }

    public virtual DbSet<Resourcecode> Resourcecodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BookingSystemDls;Username=postgres;Password=indocyber");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mstbookingcode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("pk_mstbookingcode");

            entity.ToTable("mstbookingcode");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Mstlocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_mstlocation");

            entity.ToTable("mstlocation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Mstmenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_mstmenu");

            entity.ToTable("mstmenu");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Header).HasColumnName("header");
            entity.Property(e => e.Isheader).HasColumnName("isheader");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Mstresource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_mstresource");

            entity.ToTable("mstresource");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Mstrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_mstrole");

            entity.ToTable("mstrole");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasMany(d => d.Menus).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "Rolemenu",
                    r => r.HasOne<Mstmenu>().WithMany()
                        .HasForeignKey("Menuid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_rolemenu_menuid"),
                    l => l.HasOne<Mstrole>().WithMany()
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_rolemenu_roleid"),
                    j =>
                    {
                        j.HasKey("Roleid", "Menuid").HasName("pk_rolemenu");
                        j.ToTable("rolemenu");
                        j.IndexerProperty<int>("Roleid").HasColumnName("roleid");
                        j.IndexerProperty<int>("Menuid").HasColumnName("menuid");
                    });
        });

        modelBuilder.Entity<Mstroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_mstroom");

            entity.ToTable("mstroom");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Color)
                .HasColumnType("character varying")
                .HasColumnName("color");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.Locationid).HasColumnName("locationid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.Mstrooms)
                .HasForeignKey(d => d.Locationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mstroom_locationid");

            entity.HasMany(d => d.Resources).WithMany(p => p.Rooms)
                .UsingEntity<Dictionary<string, object>>(
                    "Roomresource",
                    r => r.HasOne<Mstresource>().WithMany()
                        .HasForeignKey("Resourceid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pk_roomresource_resourceid"),
                    l => l.HasOne<Mstroom>().WithMany()
                        .HasForeignKey("Roomid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pk_roomresource_roomid"),
                    j =>
                    {
                        j.HasKey("Roomid", "Resourceid").HasName("pk_roomresource");
                        j.ToTable("roomresource");
                        j.IndexerProperty<int>("Roomid").HasColumnName("roomid");
                        j.IndexerProperty<int>("Resourceid").HasColumnName("resourceid");
                    });
        });

        modelBuilder.Entity<Mstuser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mstuser");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Loginname)
                .HasMaxLength(100)
                .HasColumnName("loginname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(100)
                .HasColumnName("middlename");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Roleid).HasColumnName("roleid");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mstuser_roleid");
        });

        modelBuilder.Entity<Resourcecode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("pk_resourcecode");

            entity.ToTable("resourcecode");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.Resourceid).HasColumnName("resourceid");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Resource).WithMany(p => p.Resourcecodes)
                .HasForeignKey(d => d.Resourceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_resourcecode_resourceid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
