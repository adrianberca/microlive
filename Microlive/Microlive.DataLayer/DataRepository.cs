﻿using System;
using Microlive.DataLayer;

namespace CBT.DataLayer
{
    public abstract class DataRepository : IDisposable
    {
        private Entities mContext;

        protected internal DataRepository(Entities context)
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Context = context;
            mContext.Configuration.LazyLoadingEnabled = false;
        }

        public virtual Entities Context
        {
            get
            {
                return mContext;
            }
            set
            {
                if (value != null)
                {
                    mContext = value;
                }
                else
                {
                    //LogHelper.LogException<DataRepository>("Could not create the database context.");
                    throw new NullReferenceException("Tried to use repository with null context");
                }
            }
        }

        public abstract bool IsEntityTrackingOn { get; set; }

        #region Disposing logic

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}