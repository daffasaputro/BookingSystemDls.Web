using BookingSystemDls.DataAccess.Models;
using BookingSystemDls.DataModel.Resource;
using BookingSystemDls.DataModel.Room;
using BookingSystemDls.DataModel.RoomResource;
using BookingSystemDls.Provider.Abstraction;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Implementation
{
    public class RoomProvider : IRoomProvider
    {
        private BookingSystemDlsContext _context;

        public RoomProvider(BookingSystemDlsContext context)
        {
            this._context = context;
        }

        public RoomDataModel GetAll(int page, int displayData)
        {
            var query = from room in _context.Mstrooms
                        join location in _context.Mstlocations on room.Id equals location.Id
                        select new RoomIndexDataModel
                        {
                            Id = room.Id,
                            Name = room.Name,
                            Floor = room.Floor,
                            Description = room.Description,
                            Location = location.Name,
                            Capacity = room.Capacity,
                            Color = room.Color
                        };

            var indexData = query.Skip((page - 1) * displayData).Take(displayData).ToList();
            var dataModel = new RoomDataModel();
            dataModel.TotalPage = (int)Math.Ceiling((decimal)query.Count() / (decimal)displayData);
            dataModel.TotalData = query.Count();
            dataModel.IndexDataModels = indexData;
            return dataModel;
        }

        public RoomUpsertDataModel GetUpdate(int id)
        {
            var roomQuery = _context.Mstrooms.SingleOrDefault(rm => rm.Id == id);

            var resourceQuery = from resource in _context.Mstresources
                                select new RoomResourceUpsertDataModel
                                {
                                    RoomId = id,
                                    ResourceId = resource.Id,
                                    ResourceName = resource.Name,
                                };

            var resourceDataModel = resourceQuery.ToList();
            var roomDataModel = new RoomUpsertDataModel();
            roomDataModel.Id = roomQuery.Id;
            roomDataModel.Name = roomQuery.Name;
            roomDataModel.Floor = roomQuery.Floor;
            roomDataModel.Description = roomQuery.Description;
            roomDataModel.LocationId = roomQuery.Locationid;
            roomDataModel.Capacity = roomQuery.Capacity;
            roomDataModel.Color = roomQuery.Color;
            roomDataModel.RoomResources = resourceDataModel;
            return roomDataModel;
        }
    }
}
