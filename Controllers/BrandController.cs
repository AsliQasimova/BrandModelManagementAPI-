using Microsoft.AspNetCore.Mvc;
using PhoneApp.Abstractions;

namespace PhoneSelling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet()]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var result = await _brandService.SendAllBrands();
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("ModelsByBrandID")]
        [Produces("application/json")]
        public async Task<IActionResult> GetModelsByBrand(int id)
        {
            try
            {
                var result = await _brandService.SendModelByBrand(id);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
