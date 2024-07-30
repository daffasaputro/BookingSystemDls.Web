using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.RoomResource
{
    public class RoomResourceUpsertDataModel
    {
        public int RoomId { get; set; }
        public int ResourceId {  get; set; }
        public string ResourceName { get; set; }
        public bool IsChecked { get; set; }
    }
}
