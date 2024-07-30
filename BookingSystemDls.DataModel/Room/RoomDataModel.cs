using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.Room
{
    public class RoomDataModel
    {
        public int TotalPage { get; set; }
        public int TotalData { get; set; }
        public List<RoomIndexDataModel> IndexDataModels { get; set; }
    }
}
