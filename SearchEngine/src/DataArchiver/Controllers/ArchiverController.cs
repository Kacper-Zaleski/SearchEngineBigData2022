using DataArchiver.Models;
using DataArchiver.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace DataArchiver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArchiverController : ControllerBase
    {
        [HttpPut]
        [Route("/archive-data")]
        public async Task<IActionResult> ArchiveData([FromBody] ArchiveDataRequest request)
        {
            var archiveData = new ArchiveData();
            var result = await archiveData.ArchiveDataUseCase(request.Books);
            return Ok(result);
        }
    }
}