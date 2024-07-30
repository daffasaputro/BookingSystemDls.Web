using BookingSystemDls.DataModel.RoomResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.Room
{
    public class RoomUpsertDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor {  get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int Capacity { get; set; }
        public string Color { get; set; }
        public List<RoomResourceUpsertDataModel> RoomResources { get; set; }   
    }
}
