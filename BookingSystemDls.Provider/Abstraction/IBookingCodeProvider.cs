using BookingSystemDls.DataModel.BookingCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Abstraction
{
    public interface IBookingCodeProvider
    {
        BookingCodeDataModel GetAll(int page, int displayData);

        BookingCodeUpsertDataModel GetUpdate(string code);

        void Insert(BookingCodeUpsertDataModel dataModel);

        void Update(BookingCodeUpsertDataModel dataModel);

        void Delete(string code);
    }
}
