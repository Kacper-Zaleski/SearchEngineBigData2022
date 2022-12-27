using DataIndexer.Helpers.Calculation;
using DataIndexer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataIndexer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataIndexerController : ControllerBase
    {
        [HttpPut]
        [Route("/index-data")]
        public async Task<IActionResult> IndexData([FromBody] IndexDataRequest request)
        {
            var indexer = new IndexerProcessor();
            var result = indexer.Index(request.Books);
            return Ok(result);
        }
    }
}