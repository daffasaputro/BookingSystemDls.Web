using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.Room
{
    public class RoomIndexDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Color { get; set; }

        public RoomIndexDataModel() { }

        public RoomIndexDataModel(int id, string name, int floor, string description, string location, int capacity, string color)
        {
            this.Id = id;
            this.Name = name;
            this.Floor = floor;
            this.Description = description;
            this.Location = location;
            this.Capacity = capacity;
            this.Color = color;
        }
    }
}
