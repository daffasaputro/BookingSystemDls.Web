using BookingSystemDls.DataAccess.Models;
using BookingSystemDls.Provider.Abstraction;
using BookingSystemDls.Provider.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBookingCodeProvider, BookingCodeProvider>();
builder.Services.AddScoped<IResourceProvider, ResourceProvider>();
builder.Services.AddScoped<IResourceCodeProvider, ResourceCodeProvider>();
builder.Services.AddScoped<IRoomProvider, RoomProvider>();
builder.Services.AddScoped<IDropdownProvider, DropdownProvider>();
builder.Services.AddScoped<BookingSystemDlsContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BookingCode}/{action=Index}");

app.Run();
