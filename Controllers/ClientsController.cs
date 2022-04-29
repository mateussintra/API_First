using API_FF6.Models.Entities.Clients;
using API_FF6.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FF6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository repos;

        public ClientsController(IClientsRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute]ClientId client)
        {
            var client_db = repos.Read(client.Id);
            return Ok(client_db);
        }

        [HttpPost]
        public IActionResult Post(PostClients client)
        {
            if (repos.Create(client))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutClients client)
        {
            if (repos.Update(client))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] ClientId client)
        {
            if (repos.Delete(client.Id))
                return Ok();

            return BadRequest();
        }
    }
}
