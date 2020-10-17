using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleQuotes.App.Contract.Handler;
using SimpleQuotes.App.Model.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleQuotes.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : BaseController
    {
        private readonly ILeadHandler LeadHandler;

        public LeadController(ILeadHandler leadHandler)
        {
            LeadHandler = leadHandler;
        }

        [HttpGet("{page:required}/{pageSize:required}")]
        public async Task<IActionResult> Get(int page, int pageSize, [FromQuery] string sort, [FromQuery] string filter)
        {
            var result = await LeadHandler.List(page, pageSize, sort, filter);

            return Ok(result);
        }

        [HttpGet("{id:required}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await LeadHandler.Read(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Lead value)
        {
            await LeadHandler.Create(value);

            return CreatedAtRoute(new { controller = ControllerContext.ActionDescriptor.ControllerName }, value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Lead value)
        {
            await LeadHandler.Update(id, value);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await LeadHandler.Destroy(id);

            return NoContent();
        }
    }
}
