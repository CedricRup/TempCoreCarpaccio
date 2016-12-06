using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XCarpaccio.Models;

namespace XCarpaccio.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
       
       [HttpGet]
       public IActionResult Get()
       {
           return Content("Hello world of Carpaccio!");
       }
            
    }
}