using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckingDocx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService valuesService;

        public ValuesController(IValuesService valuesService)
        {
            this.valuesService = valuesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await valuesService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = valuesService.GetById(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ValueDTO valueDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            await valuesService.Create(valueDTO);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ValueDTO valueDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            await valuesService.Update(valueDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await valuesService.Delete(id);

            return Ok();
        }
    }
}
