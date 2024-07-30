using BookingSystemDls.DataModel.BookingCode;
using BookingSystemDls.Provider.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDls.Web.Controllers
{
    public class BookingCodeController : Controller
    {
        private IBookingCodeProvider _bookingCodeProvider;

        public BookingCodeController(IBookingCodeProvider bookingCodeService)
        {
            this._bookingCodeProvider = bookingCodeService;
        }

        public IActionResult Index(int page = 1, int displayData = 5)
        {
            var dataModel = _bookingCodeProvider.GetAll(page, displayData);
            ViewBag.TotalPage = dataModel.TotalPage;
            ViewBag.TotalData = dataModel.TotalData;
            ViewBag.Page = page;
            ViewBag.DisplayData = displayData;
            ViewBag.DataFrom = ((page - 1) * displayData) + 1;
            ViewBag.DataTo = (displayData * page < dataModel.TotalData) ? displayData * page : dataModel.TotalData;
            return View(dataModel);
        }

        public IActionResult UpsertForm(string? code)
        {
            var dataModel = code == null ? new BookingCodeUpsertDataModel() : _bookingCodeProvider.GetUpdate(code);
            return View(dataModel);
        }

        [HttpPost]
        public IActionResult Insert(BookingCodeUpsertDataModel dataModel)
        {
            _bookingCodeProvider.Insert(dataModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(BookingCodeUpsertDataModel dataModel)
        {
            _bookingCodeProvider.Update(dataModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string code)
        {
            _bookingCodeProvider.Delete(code);
            return RedirectToAction("Index");
        }
    }
}
