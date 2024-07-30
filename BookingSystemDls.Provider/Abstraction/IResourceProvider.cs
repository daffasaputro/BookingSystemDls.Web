using BookingSystemDls.DataModel.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Abstraction
{
    public interface IResourceProvider
    {
        ResourceDataModel GetAll(int page, int displayData);

        ResourceUpsertDataModel GetUpdate(int id);

        void Upsert(ResourceUpsertDataModel dataModel);

        void Delete(int id);
    }
}
