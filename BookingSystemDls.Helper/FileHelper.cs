using BookingSystemDls.DataModel.Resource;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Helper
{
    public class FileHelper
    {
        private IHostingEnvironment _hostingEnvironment;

        public FileHelper(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public static string UploadFile(ResourceUpsertDataModel dataModel)
        {
            var uniqueFileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
            var filePath = Path.Combine(uploads, uniqueFileName);
            dataModel.IconFile.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}
