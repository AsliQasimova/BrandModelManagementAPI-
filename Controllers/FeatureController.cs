using Microsoft.AspNetCore.Mvc;
using PhoneApp.Abstractions;
using PhoneApp.Models;

namespace PhoneApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet()]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllFeatures(int modelID)
        {
            try
            {
                var result = await _featureService.SendAllFeatures(modelID);
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

        [HttpPost("Add")]
        [Produces("application/json")]
        public async Task<IActionResult> AddFeature([FromBody] FeatureDTO feature)
        {
            try
            {
                var newFeature = await _featureService.AddFeature(feature);
                return Ok(newFeature);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
