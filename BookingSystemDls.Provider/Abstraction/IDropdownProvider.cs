using BookingSystemDls.DataModel.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Abstraction
{
    public interface IDropdownProvider
    {
        List<DropdownDataModel> GetLocationDropdown();
    }
}
