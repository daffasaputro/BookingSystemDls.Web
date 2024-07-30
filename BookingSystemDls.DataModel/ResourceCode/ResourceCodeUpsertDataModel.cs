using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.ResourceCode
{
    public class ResourceCodeUpsertDataModel
    {
        public string Code {  get; set; }
        public int ResourceId { get; set; }
        public bool Status {  get; set; }

        public ResourceCodeUpsertDataModel() { }

        public ResourceCodeUpsertDataModel(string code, int resourceId, bool status)
        {
            this.Code = code;
            this.ResourceId = resourceId;
            this.Status = status;
        }
    }
}
