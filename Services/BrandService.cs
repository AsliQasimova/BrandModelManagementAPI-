using Microsoft.EntityFrameworkCore;
using PhoneApp.Abstractions;
using PhoneApp.Data;
using PhoneApp.Entities;
using PhoneApp.Models;

namespace PhoneApp.Services
{
    public class BrandService : IBrandService
    {
        private readonly PhoneDbContext _context;

        public BrandService(PhoneDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandDTO>> SendAllBrands() //Sends All Brands
        {
            var brands = await _context.Brands.ToListAsync();

            if (brands.Count == 0)
                throw new InvalidOperationException("No brands found.");

            return brands.Select (b=> new BrandDTO {
                   Name = b.Name
            }
            );
        }


        public async Task<IEnumerable<ModelDTO>> SendModelByBrand(int id) // Sends models by brand ID
        {
            var brand = await _context.Brands
                .Include(b => b.Models)
                .FirstOrDefaultAsync(b => b.ID == id);

            if (brand == null)
                throw new InvalidOperationException($"Brand id '{id}' not found.");

            var models = brand.Models
                .Where(m => !m.IsDeleted)
                .Select(m => new ModelDTO
            {
                Id = m.ID,
                Name = m.Name,
                Price = m.Price,
                Quantity = m.Quantity,
                BrandID= m.BrandID
            }).ToList();

            if (models.Count == 0)
                throw new InvalidOperationException($"No models found for {id} brand.");

            return models;
        }
    }
}
