using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XCarpaccio.Models;

namespace XCarpaccio.Controllers
{
    [Route("[controller]")]
    public class QuoteController : Controller
    {
        ILogger<FeedbackController> logger;

        Dictionary<string, decimal> countriesRate;
        
        public QuoteController(){
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            if(
                quote.Country != "FR" ||
                (quote.ReturnDate - quote.DepartureDate).Days <7 ||
                (quote.Options != null && quote.Options.Any())||
                quote.Cover != "BASIC" ||
                (quote.TravellerAges != null && quote.TravellerAges.Any(a=> a<66))
            )

            {
                return this.BadRequest();
            }
            var quoteResponse = new QuoteResponse();
            quoteResponse.Quote = 
                1.8m *
                1m *
                quote.TravellerAges.Sum() * 1.5m *
                (quote.ReturnDate - quote.DepartureDate).Days ;
            return this.Ok(quoteResponse);
                      
        }
    }
}