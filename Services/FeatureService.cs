using Microsoft.EntityFrameworkCore;
using PhoneApp.Abstractions;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly PhoneDbContext _featureContext;

        public FeatureService(PhoneDbContext featureContext)
        {
            _featureContext = featureContext;
        }

        public async Task<IEnumerable<FeatureDTO>> SendAllFeatures(int modelID) //Sends all features by model ID
        {
            var features = await _featureContext.Features
                .Where(f => f.ModelID == modelID)
                .ToListAsync();

            if (features.Count == 0)
                throw new InvalidOperationException($"No features found for ModelID {modelID}.");

            return features
                .Where(f => f.ModelID == modelID && !f.IsDeleted)
                .Select(f => new FeatureDTO
            { 
                ModelID = f.ModelID,
                Camera = f.Camera,
                Storage = f.Storage,
                Ram = f.Ram
            });
        }

        public async Task<FeatureDTO> AddFeature(FeatureDTO feature) //Adds new feature 
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature), "Feature data can not be null");

            var modelExists = await _featureContext.Models.AnyAsync(m => m.ID == feature.ModelID);
            if (!modelExists)
                throw new InvalidOperationException($"Model with ID {feature.ModelID} does not exist.");



            var newFeature = new PhoneApp.Entities.Feature
            {
                ModelID = feature.ModelID,
                Camera = feature.Camera,
                Storage = feature.Storage,
                Ram = feature.Ram
            };

            _featureContext.Add(newFeature);
            await _featureContext.SaveChangesAsync();

            return new FeatureDTO
            {
                ModelID = newFeature.ModelID,
                Camera = newFeature.Camera,
                Storage = newFeature.Storage,
                Ram = newFeature.Ram,
            };
        }

    }
}
