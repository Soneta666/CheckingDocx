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
        public IActionResult Get()
        {
            return Ok(requirementsService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var item = requirementsService.GetById(id);
            if(item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RequirementDTO requirementDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            requirementsService.Create(requirementDTO);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] RequirementDTO requirementDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            requirementsService.Update(requirementDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            requirementsService.Delete(id);

            return Ok();
        }
    }
}
