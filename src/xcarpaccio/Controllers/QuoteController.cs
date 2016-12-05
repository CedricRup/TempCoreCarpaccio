using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XCarpaccio.Models;

namespace XCarpaccio.Controllers
{
    [Route("[controller]")]
    public class QuoteController : Controller
    {
        ILogger<FeedbackController> logger;
        
        public QuoteController(){
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            return this.BadRequest();          
        }
    }
}