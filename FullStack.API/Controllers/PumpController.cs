using FullStack.API.Helpers;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PumpController : Controller
    {
        private readonly IPumps pumpsRepository;
        public PumpController(IPumps pumpsRepository)
        {
            this.pumpsRepository = pumpsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPumps()
        {
            var pumps = await pumpsRepository.GetAllAsync();

            return Ok(pumps.ToProductViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> AddPump([FromBody] PumpViewModel pumpRequest)
        {
            pumpRequest.Id = Guid.NewGuid();
            pumpRequest.Engine.Id = Guid.NewGuid();
            pumpRequest.HousingMaterial.Id = Guid.NewGuid();
            pumpRequest.LmpellerMaterial.Id = Guid.NewGuid();

            await pumpsRepository.AddAsync(pumpRequest.ToPump());

            return Ok(pumpRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetPump([FromRoute]Guid id)
        {
            var pump = pumpsRepository.GetPump(id);

            if(pump == null)
            {
                return NotFound();
            }
            return Ok(pump.ToPumpViewModel());
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatePump([FromRoute] Guid id, PumpViewModel updatePumpRequest)
        {
            var pump = pumpsRepository.GetPump(id);

            if (pump == null)
            {
                return NotFound();
            }

            var pumpUpdate = await pumpsRepository.UpdatePumpAsync(pump, updatePumpRequest.ToPump());

            return Ok(pumpUpdate.ToPumpViewModel());
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePump([FromRoute] Guid id)
        {
            var pump = pumpsRepository.GetPump(id);

            if (pump == null)
            {
                return NotFound();
            }

            await pumpsRepository.RemoveAsync(pump);

            return Ok(pump.ToPumpViewModel());
        }
    }
}
