using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.DataModel.BookingCode
{
    public class BookingCodeDataModel
    {
        public int TotalPage {  get; set; }
        public int TotalData {  get; set; }
        public List<BookingCodeIndexDataModel> IndexDataModels { get; set; }
    }
}
