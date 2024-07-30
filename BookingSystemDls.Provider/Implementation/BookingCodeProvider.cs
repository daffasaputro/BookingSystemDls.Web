using BookingSystemDls.DataAccess.Models;
using BookingSystemDls.DataModel.BookingCode;
using BookingSystemDls.Provider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Implementation
{
    public class BookingCodeProvider : IBookingCodeProvider
    {
        private BookingSystemDlsContext _context;

        public BookingCodeProvider(BookingSystemDlsContext context)
        {
            this._context = context;
        }

        public BookingCodeDataModel GetAll(int page, int displayData)
        {
            var query = from bookingCode in _context.Mstbookingcodes
                        where bookingCode.Status == true
                        select new BookingCodeIndexDataModel
                        {
                            Code = bookingCode.Code,
                            Status = bookingCode.Status
                        };

            var indexData = query.Skip((page - 1) * displayData).Take(displayData).ToList();
            var dataModel = new BookingCodeDataModel();
            dataModel.TotalPage = (int) Math.Ceiling((decimal) query.Count() / (decimal) displayData);
            dataModel.TotalData = query.Count();
            dataModel.IndexDataModels = indexData;
            return dataModel;
        }

        public BookingCodeUpsertDataModel GetUpdate(string code)
        {
            var query = _context.Mstbookingcodes.SingleOrDefault(bco => bco.Code == code);
            var dataModel = new BookingCodeUpsertDataModel();
            dataModel.Code = code;
            dataModel.Status = query.Status;
            return dataModel;
        }

        public void Insert(BookingCodeUpsertDataModel dataModel)
        {
            var bookingCode = new Mstbookingcode();
            bookingCode.Code = dataModel.Code;
            bookingCode.Status = dataModel.Status;
            _context.Mstbookingcodes.Add(bookingCode);
            _context.SaveChanges();
        }

        public void Update(BookingCodeUpsertDataModel dataModel)
        {
            var bookingCode = _context.Mstbookingcodes.SingleOrDefault(bco => bco.Code == dataModel.Code);
            bookingCode.Status = dataModel.Status;
            _context.SaveChanges();
        }

        public void Delete(string code)
        {
            var bookingCode = _context.Mstbookingcodes.SingleOrDefault(bco => bco.Code == code);
            _context.Mstbookingcodes.Remove(bookingCode);
            _context.SaveChanges();
        }
    }
}
