using BookingSystemDls.DataAccess.Models;
using BookingSystemDls.DataModel.Dropdown;
using BookingSystemDls.Provider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Implementation
{
    public class DropdownProvider : IDropdownProvider
    {
        private BookingSystemDlsContext _context;

        public DropdownProvider(BookingSystemDlsContext context)
        {
            this._context = context;
        }

        public List<DropdownDataModel> GetLocationDropdown()
        {
            var query = from location in _context.Mstlocations
                        select new DropdownDataModel
                        {
                            Value = location.Id,
                            Label = location.Name
                        };

            var dataModel = query.ToList();
            return dataModel;
        }
    }
}
