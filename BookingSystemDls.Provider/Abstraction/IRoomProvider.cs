using BookingSystemDls.DataModel.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Abstraction
{
    public interface IRoomProvider
    {
        RoomDataModel GetAll(int page, int displayPage);

        RoomUpsertDataModel GetUpdate(int id);
    }
}
