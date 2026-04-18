using Microsoft.AspNetCore.Mvc;
using PhoneApp.Abstractions;
using PhoneApp.Models;
using PhoneApp.Services;

namespace PhoneApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost("AddNewModel")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> AddModel([FromBody] PostModelDTO model)
        {
            try
            {
                var newModel = await _modelService.AddNewModel(model);
                return Ok(newModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }


        [HttpPatch("UpdatePrice")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePrice(int id, [FromBody] UpdatePriceDTO model)
        {
            var updated = await _modelService.UpdatePrice(id, model.NewPrice);
            if (updated == null)
                return NotFound(new { error = $"Model with ID {id} not found." });

            return Ok(new { message = $"Price updated to {updated.Price}" });
        }


        [HttpDelete("Delete")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            try
            {
                var deleted = await _modelService.DeleteModel(id);

                if (!deleted)
                    return NotFound(new { error = $"Model with ID {id} not found." });

                return Ok(new { message = "Model deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }


        
        [HttpPost("Buy", Name = "Buy Model")]
        [Produces("application/json")]
        public async Task<ActionResult> BuyModel(int id)
        {
            try
            {
                await _modelService.BuyModel(id);
                return Ok("Purchase successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Restock")]
        public async Task<IActionResult> Restock(int id, int quantity)
        {
            await _modelService.RestockModel(id, quantity);
            return Ok("Stock updated successfully");
        }
    }
}
