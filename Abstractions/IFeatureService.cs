using PhoneApp.Models;

namespace PhoneApp.Abstractions
{
    public interface IFeatureService
    {
        Task<IEnumerable<FeatureDTO>> SendAllFeatures(int modelID);
        Task<FeatureDTO> AddFeature(FeatureDTO feature);
    }
}
