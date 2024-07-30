using BookingSystemDls.DataModel.ResourceCode;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.Resource
{
    public class ResourceUpsertDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Icon { get; set; }
        public IFormFile IconFile {  get; set; }
        public List<ResourceCodeUpsertDataModel> ResourceCodes { get; set; }

        public ResourceUpsertDataModel() { }

        public ResourceUpsertDataModel(int id, string name, bool status, string icon, List<ResourceCodeUpsertDataModel> resourceCodes)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
            this.Icon = icon;
            this.ResourceCodes = resourceCodes;
        }
    }
}
