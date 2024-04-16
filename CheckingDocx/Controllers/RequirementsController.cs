using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckingDocx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : ControllerBase
    {
        private readonly IRequirementsService requirementsService;

        public RequirementsController(IRequirementsService requirementsService)
        {
            this.requirementsService = requirementsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await requirementsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] uint id)
        {
            var item = await requirementsService.GetById(id);
            if(item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequirementDTO requirementDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            await requirementsService.Create(requirementDTO);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] RequirementDTO requirementDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            await requirementsService.Update(requirementDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] uint id)
        {
            await requirementsService.Delete(id);

            return Ok();
        }
    }
}
