using System.Net;
using Xunit;
using XCarpaccio.Models;
using XCarpaccio.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace XCarpaccio.Tests
{
    
    public class QuotesControllerTest
    {
        [Fact]
        public void Post_should_respond_with_400()
        {
            var controller = new QuoteController();
            Quote quote = new Quote();
            var response = controller.Post(quote);

            var viewResult = Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void Post_should_respond_with_400_when_model_is_not_valid()
        {
            var controller = new QuoteController();
            Quote quote = new Quote();
            controller.ModelState.AddModelError("SessionName", "Required");
            var response = controller.Post(quote);

            var viewResult = Assert.IsType<BadRequestResult>(response);
        }

        
    }    
}
