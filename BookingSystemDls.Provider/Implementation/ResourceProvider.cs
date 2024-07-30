using BookingSystemDls.DataAccess.Models;
using BookingSystemDls.DataModel.BookingCode;
using BookingSystemDls.DataModel.Resource;
using BookingSystemDls.DataModel.ResourceCode;
using BookingSystemDls.Provider.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Implementation
{
    public class ResourceProvider : IResourceProvider
    {
        private BookingSystemDlsContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public ResourceProvider(BookingSystemDlsContext context, IHostingEnvironment hostingEnvironment)
        {
            this._context = context;
            this._hostingEnvironment = hostingEnvironment;
        }

        public ResourceDataModel GetAll(int page, int displayData)
        {
            var query = from resource in _context.Mstresources
                        select new ResourceIndexDataModel
                        {
                            Id = resource.Id,
                            Name = resource.Name,
                            Status = resource.Status,
                            Icon = resource.Icon
                        };

            var indexData = query.Skip((page - 1) * displayData).Take(displayData).ToList();
            var dataModel = new ResourceDataModel();
            dataModel.TotalPage = (int)Math.Ceiling((decimal)query.Count() / (decimal)displayData);
            dataModel.TotalData = query.Count();
            dataModel.IndexDataModels = indexData;
            return dataModel;
        }

        public ResourceUpsertDataModel GetUpdate(int id)
        {
            var resourceQuery = _context.Mstresources.SingleOrDefault(res => res.Id == id);

            var resourceCodeQuery = from resourceCode in _context.Resourcecodes
                                    where resourceCode.Resourceid == id
                                    select new ResourceCodeUpsertDataModel
                                    {
                                        Code = resourceCode.Code,
                                        ResourceId = resourceCode.Resourceid,
                                        Status = resourceCode.Status,
                                    };

            var resourceCodeDataModel = resourceCodeQuery.ToList();
            var resourceDataModel = new ResourceUpsertDataModel(id, resourceQuery.Name, resourceQuery.Status, resourceQuery.Icon, resourceCodeDataModel);
            return resourceDataModel;
        }

        public void Upsert(ResourceUpsertDataModel dataModel)
        {
            var resource = dataModel.Id == 0 ? new Mstresource() : _context.Mstresources.SingleOrDefault(res => res.Id == dataModel.Id);
            resource.Name = dataModel.Name;
            resource.Status = dataModel.Status;
            if (resource.Icon != null) RemoveFile(resource.Icon);

            if (dataModel.IconFile != null)
            {
                var iconFileName = UploadFile(dataModel);
                resource.Icon = iconFileName;
            }

            if (dataModel.Id == 0) { _context.Mstresources.Add(resource); }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var resource = _context.Mstresources.SingleOrDefault(res => res.Id == id);
            _context.Mstresources.Remove(resource);
            _context.SaveChanges();
        }

        private string UploadFile(ResourceUpsertDataModel dataModel)
        {
            var fileName = dataModel.IconFile.FileName;
            var fileExtension = fileName.Split(".")[1];
            var uniqueFileName = Guid.NewGuid().ToString() + "." + fileExtension;
            var upload = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
            var filePath = Path.Combine(upload, uniqueFileName);
            dataModel.IconFile.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        private void RemoveFile(string fileName)
        {
            var existingFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload", fileName);
            if (File.Exists(existingFilePath)) { File.Delete(existingFilePath); }
        }
    }
}
