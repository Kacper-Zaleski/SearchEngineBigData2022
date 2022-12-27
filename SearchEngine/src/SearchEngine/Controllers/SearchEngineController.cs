using Microsoft.AspNetCore.Mvc;
using SearchEngine.Models.Dto;
using SearchEngine.UseCase.SearchBooksUseCase;

namespace SearchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchEngineController : ControllerBase
    {
        public SearchBooksUseSace searchBooksUseSace;

        public SearchEngineController()
        {
            searchBooksUseSace = new SearchBooksUseSace();
        }

        [HttpGet]
        [Route("/search")]
        public IActionResult Search([FromBody] FindBookRequest request)
        {
            var result = searchBooksUseSace.FindBooks(request);
            return Ok(result);
        }
    }
}