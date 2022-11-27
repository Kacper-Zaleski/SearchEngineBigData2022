using Microsoft.AspNetCore.Mvc;
using WebCrawler.UseCases;

namespace WebCrawler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebScraperController : ControllerBase
    {
        [HttpPut]
        [Route("/web-scrape")]
        public IActionResult WebScrape()
        {
            var webScraper = new WebScrape();
            var result = webScraper.GetBooks();
            return Ok(result);
        }
    }
}