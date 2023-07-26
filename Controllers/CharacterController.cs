using steven_api.Models;
using Microsoft.AspNetCore.Mvc;
using steven_api.Data;
using steven_api.Wrappers;
using steven_api.Filter;
using Microsoft.EntityFrameworkCore;
using steven_api.Services;
using steven_api.Helpers;


namespace steven_api.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterDbContext _characterDbContext;
        private readonly IUriService uriService;
        public CharacterController(CharacterDbContext characterDbContext, IUriService uriService) {
            _characterDbContext = characterDbContext;
            this.uriService = uriService;
            

        }
        [HttpGet]
        [Route("Characters")]
        public async Task<IActionResult> GetCharacters([FromQuery]PaginationFilter filter) {
            CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;
            var route = Request.Path.Value;
            
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = context.GetCharacters()
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToList();
            var totalRecords = pagedData.Count();
            
            var pagedResponse = PaginationHelper.CreatePagedResponse<Character>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedResponse);//Ok(new Response<Character>(context.GetCharacters()));
            // new PagedResponse<List<Character>>(pagedData, validFilter.PageNumber, validFilter.PageSize)
        }
        //         [HttpGet]
        // [Route("Characters")]
        // public IActionResult GetCharacters() {
        //     CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;
        //     var pagedData = context.GetCharacters();
        //    // var totalRecords = context.Characters.Count();
        //     return Ok(pagedData);//new PagedResponse<List<Character>>(pagedData, validFilter.PageNumber, validFilter.PageSize));//Ok(new Response<Character>(context.GetCharacters()));
        // }
        [HttpGet]
        [Route("Characters/names/{name}")]
        public IActionResult FilterCharacterByName(String name) {
            CharacterDbContext? context = HttpContext.RequestServices.GetService(typeof(steven_api.Data.CharacterDbContext)) as CharacterDbContext;
            return Ok(ApiResponse<Character>.Success(context.FilterCharacterByName(name)));
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