﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CBT.DataLayer;
using Microlive.DataLayer.Interfaces;

namespace Microlive.DataLayer.BaseRepo
{
    public abstract class BaseRepo<T> : GenericDataRepository<T>
    where T : class, IDataAccesObject
    {
        public BaseRepo(Entities context) : base(context)
        {
        }

        public abstract Task<T> CreateAsync(T model, IList<string> navigationProperties = null);


        public abstract Task<T> UpdateAsync(T model, IList<string> navigationProperties = null);
    }
}