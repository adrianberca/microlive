using System;

namespace Microlive.Model.Interfaces
{
	public interface IModelWithSinglePk : IModel
    {
        Guid Id { get; set; }
    }
}