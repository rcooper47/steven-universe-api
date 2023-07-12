using steven_api.Models;
using Microsoft.AspNetCore.Mvc;
using steven_api.Data;

namespace steven_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterDbContext _characterDbContext;
        public CharacterController(CharacterDbContext characterDbContext) {
            _characterDbContext = characterDbContext;

        }
        [HttpGet]
        [Route("Characters")]
        public IActionResult GetCharacters() {
            CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;

            return Ok(context.GetCharacters());
        }
        [HttpGet]
        [Route("Characters/names/{name}")]
        public IActionResult FilterCharacterByName(String name) {
            CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;

            return Ok(context.FilterCharacterByName(name));
        }
        [HttpGet]
        [Route("Characters/gems/{gem}")]
        public IActionResult FilterCharacterByGem(String gem) {
            CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;

            return Ok(context.FilterCharacterByGem(gem));
        }
        [HttpGet]
        [Route("Characters/statuses/{status}")]
        public IActionResult FilterCharacterByStatus(String status) {
            CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;

            return Ok(context.FilterCharacterByStatus(status));
        }

        [HttpGet]
        [Route("Characters/alignments/{alignment}")]
        public IActionResult FilterCharacterByAlignment(String alignment) {
            CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;

            return Ok(context.FilterCharacterByAlignment(alignment));
        }



    }
}