using PhoneApp.Models;

namespace PhoneApp.Abstractions
{
    public interface IModelService
    {
        Task<ModelDTO> AddNewModel(PostModelDTO model);
        Task<ModelDTO> UpdatePrice(int modelID, decimal newPrice);
        Task<bool> DeleteModel(int modelID);
        Task<bool> BuyModel(int modelID);
        Task<bool> RestockModel(int modelID, int quantity);
    }
}
