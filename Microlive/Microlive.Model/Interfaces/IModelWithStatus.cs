namespace Microlive.Model.Interfaces
{
	public interface IModelWithStatus : IModel
    {
        int Status { get; set; }
    }
}