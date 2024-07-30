using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.Resource
{
    public class ResourceDataModel
    {
        public int TotalPage {  get; set; }
        public int TotalData {  get; set; }
        public List<ResourceIndexDataModel> IndexDataModels {  get; set; }
    }
}
