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
        public IActionResult Get()
        {
            return Ok(valuesService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var item = valuesService.GetById(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ValueDTO valueDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            valuesService.Create(valueDTO);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ValueDTO valueDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            valuesService.Update(valueDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            valuesService.Delete(id);

            return Ok();
        }
    }
}
