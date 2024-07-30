using BookingSystemDls.DataModel.Resource;
using BookingSystemDls.Provider.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDls.Web.Controllers
{
    public class ResourceController : Controller
    {
        private IResourceProvider _resourceProvider;
        private IResourceCodeProvider _resourceCodeProvider;

        public ResourceController(IResourceProvider resourceProvider, IResourceCodeProvider resourceCodeProvider)
        {
            this._resourceProvider = resourceProvider;
            this._resourceCodeProvider = resourceCodeProvider;
        }

        public IActionResult Index(int page = 1, int displayData = 5)
        {
            var dataModel = _resourceProvider.GetAll(page, displayData);
            ViewBag.TotalPage = dataModel.TotalPage;
            ViewBag.TotalData = dataModel.TotalData;
            ViewBag.Page = page;
            ViewBag.DisplayData = displayData;
            ViewBag.DataFrom = ((page - 1) * displayData) + 1;
            ViewBag.DataTo = (displayData * page < dataModel.TotalData) ? displayData * page : dataModel.TotalData;
            return View(dataModel);
        }

        public IActionResult Upsertform(int? id)
        {
            var dataModel = id == null ? new ResourceUpsertDataModel() : _resourceProvider.GetUpdate(id.Value);
            return View(dataModel);
        }

        public IActionResult Upsert(ResourceUpsertDataModel dataModel)
        {
            _resourceProvider.Upsert(dataModel);
            if (dataModel.ResourceCodes != null) _resourceCodeProvider.Upsert(dataModel.ResourceCodes);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _resourceProvider.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
