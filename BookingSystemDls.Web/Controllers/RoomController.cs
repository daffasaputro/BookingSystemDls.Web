using BookingSystemDls.DataModel.Room;
using BookingSystemDls.Provider.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDls.Web.Controllers
{
    public class RoomController : Controller
    {
        private IRoomProvider _roomProvider;
        private IDropdownProvider _dropdownProvider;

        public RoomController(IRoomProvider roomProvider, IDropdownProvider dropdownProvider)
        {
            this._roomProvider = roomProvider;
            this._dropdownProvider = dropdownProvider;
        }

        public IActionResult Index(int page = 1, int displayData = 5)
        {
            var dataModel = _roomProvider.GetAll(page, displayData);
            ViewBag.TotalPage = dataModel.TotalPage;
            ViewBag.TotalData = dataModel.TotalData;
            ViewBag.Page = page;
            ViewBag.DisplayData = displayData;
            ViewBag.DataFrom = ((page - 1) * displayData) + 1;
            ViewBag.DataTo = (displayData * page < dataModel.TotalData) ? displayData * page : dataModel.TotalData;
            return View(dataModel);
        }

        public IActionResult UpsertForm(int id)
        {
            var dataModel = id == 0 ? new RoomUpsertDataModel() : _roomProvider.GetUpdate(id);
            ViewBag.LocationDropdown = _dropdownProvider.GetLocationDropdown();
            return View(dataModel);
        }

        public IActionResult Upsert(RoomUpsertDataModel dataModel)
        {
            return RedirectToAction("Index");
        }
    }
}
