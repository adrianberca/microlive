using System;

namespace Microlive.DataLayer.Interfaces
{
	public interface IDataAccesObjectWithStatus : IDataAccesObject
    {
	    int Status { get; set; }
	}
}