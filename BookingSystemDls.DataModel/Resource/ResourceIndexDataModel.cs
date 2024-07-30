using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.Resource
{
    public class ResourceIndexDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status {  get; set; }
        public string Icon {  get; set; }

        public ResourceIndexDataModel() { }

        public ResourceIndexDataModel(int id, string name, bool status, string icon)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
            this.Icon = icon;
        }
    }
}
