using BookingSystemDls.DataAccess.Models;
using BookingSystemDls.DataModel.ResourceCode;
using BookingSystemDls.Provider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Implementation
{
    public class ResourceCodeProvider : IResourceCodeProvider
    {
        private BookingSystemDlsContext _context;

        public ResourceCodeProvider(BookingSystemDlsContext context)
        {
            this._context = context;
        }

        public void Upsert(List<ResourceCodeUpsertDataModel> dataModel)
        {
            dataModel.ForEach(dmo =>
            {
                var isResourceCodeExist = _context.Resourcecodes.Any(rco => rco.Code == dmo.Code);

                if (!isResourceCodeExist)
                {
                    var resourceCode = new Resourcecode();
                    resourceCode.Code = dmo.Code;
                    resourceCode.Resourceid = dmo.ResourceId;
                    resourceCode.Status = dmo.Status;
                    _context.Resourcecodes.Add(resourceCode);
                    _context.SaveChanges();
                } else
                {
                    var resourceCode = _context.Resourcecodes.SingleOrDefault(rco => rco.Code == dmo.Code);
                    resourceCode.Status = dmo.Status;
                    _context.SaveChanges();
                }
            });
        }
    }
}
