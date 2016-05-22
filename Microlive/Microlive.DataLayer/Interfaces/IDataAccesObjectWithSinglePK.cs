using System;

namespace Microlive.DataLayer.Interfaces
{
	public interface IDataAccesObjectWithSinglePk : IDataAccesObject
    {
	    Guid Id { get; set; }
	}
}