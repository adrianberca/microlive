using Microlive.DataLayer;
using Microlive.DataLayer.BaseRepo;
using Microlive.DataLayer.Interfaces;
using Microlive.Model.Interfaces;

namespace Microlive.BusinessLogic.BaseCore
{
    public abstract class BaseCore<T, U>
        where T : class, IModel, new()
        where U : class, IDataAccesObject, new()
    {
        internal abstract BaseRepo<U> GetRepoInstance(Entities context = null);
    }
}