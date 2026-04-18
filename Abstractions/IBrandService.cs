using PhoneApp.Entities;
using PhoneApp.Models;

namespace PhoneApp.Abstractions
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> SendAllBrands();
        Task<IEnumerable<ModelDTO>> SendModelByBrand(int id);
    }
}
