using Microsoft.EntityFrameworkCore;
using PhoneApp.Abstractions;
using PhoneApp.Data;
using PhoneApp.Entities;
using PhoneApp.Models;
using static PhoneApp.Entities.Sales;

namespace PhoneApp.Services
{
    public class ModelService: IModelService
    {
        private readonly PhoneDbContext _modelService;
        public ModelService(PhoneDbContext modelService)
        {
            _modelService = modelService;
        }

        public async Task<ModelDTO> AddNewModel(PostModelDTO model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "Model data can not be null");


            var newModel = new Entities.Model
            {
                Name = model.Name,
                Price = Math.Round(model.Price, 2),
                Quantity = model.Quantity,
                BrandID = model.BrandID
            };

            _modelService.Add(newModel);
            await _modelService.SaveChangesAsync();

            return new ModelDTO
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                BrandID = model.BrandID
            };
        }


        public async Task<ModelDTO?> UpdatePrice(int modelID, decimal newPrice)
        {
            if (modelID <= 0)
                throw new ArgumentOutOfRangeException(nameof(modelID));

            if (newPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice));

            var existingModel = await _modelService.Models.FindAsync(modelID);

            if (existingModel == null)
                throw new KeyNotFoundException("Model not found");

            var oldPrice = existingModel.Price;

            var history = new PriceHistory
            {
                ModelID = modelID,
                OldPrice = oldPrice,
                NewPrice = newPrice,
                ChangedAt = DateTime.UtcNow
            };

            _modelService.PriceHistories.Add(history);

            existingModel.Price = newPrice;

            await _modelService.SaveChangesAsync();

            return new ModelDTO
            {
                Id = existingModel.ID,
                Name = existingModel.Name,
                Price = existingModel.Price,
                Quantity = existingModel.Quantity,
                BrandID = existingModel.BrandID
            };
        }

        public async Task<bool> DeleteModel(int modelID)
        {
            if (modelID <= 0)
                throw new ArgumentOutOfRangeException(nameof(modelID), "ID must be greater than 0");

            var existingModel = await _modelService.Models
                .Include(m => m.Feature)
                .FirstOrDefaultAsync(m => m.ID == modelID);

            if (existingModel == null)
                throw new InvalidOperationException($"Model with {modelID} not found");

            // Soft delete model
            existingModel.IsDeleted = true;

            // Soft delete feature if exists
            if (existingModel.Feature != null)
                existingModel.Feature.IsDeleted = true;

            await _modelService.SaveChangesAsync();
            return true;
        }


        public async Task<bool> BuyModel(int modelID)
        {
            if (modelID <= 0)
                throw new ArgumentOutOfRangeException(nameof(modelID), "ID must be greater than 0");

            var existingModel = await _modelService.Models.FindAsync(modelID);

            if (existingModel == null)
                throw new InvalidOperationException($"Model with ID {modelID} not found");

            if (existingModel.Quantity <= 0)
                throw new InvalidOperationException("This model is out of stock");

            // Sales record
            var sale = new Sale
            {
                ModelID = existingModel.ID,
                SoldPrice = existingModel.Price,
                SoldAt = DateTime.UtcNow
            };

            _modelService.Sales.Add(sale);

            // Stock movement record
            var movement = new StockMovement
            {
                ModelID = existingModel.ID,
                QuantityChanged = -1,
                MovementType = "SALE",
                ChangedAt = DateTime.UtcNow
            };

            _modelService.StockMovements.Add(movement);

            existingModel.Quantity -= 1;

            await _modelService.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RestockModel(int modelID, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity must be greater than 0");

            var model = await _modelService.Models.FindAsync(modelID);

            if (model == null)
                throw new InvalidOperationException("Model not found");

            model.Quantity += quantity;

            var movement = new StockMovement
            {
                ModelID = model.ID,
                QuantityChanged = quantity,
                MovementType = "RESTOCK",
                ChangedAt = DateTime.UtcNow
            };

            _modelService.StockMovements.Add(movement);

            await _modelService.SaveChangesAsync();
            return true;
        }
    }
}
