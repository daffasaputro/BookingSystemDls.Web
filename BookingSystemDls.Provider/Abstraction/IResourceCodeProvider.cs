using BookingSystemDls.DataModel.ResourceCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDls.Provider.Abstraction
{
    public interface IResourceCodeProvider
    {
        void Upsert(List<ResourceCodeUpsertDataModel> dataModel);
    }
}
