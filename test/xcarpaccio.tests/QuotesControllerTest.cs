using System.Net;
using Xunit;
using XCarpaccio.Models;
using XCarpaccio.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace XCarpaccio.Tests
{
    
    public class QuotesControllerTest
    {
        QuoteController controller;

        public QuotesControllerTest()
        {
            controller = new QuoteController();
        }

        [Fact]
        public void Post_should_respond_Quote()
        {    
            Quote quote = new Quote();
            quote.Country = "FR";
            var response = controller.Post(quote);
            var viewResult = Assert.IsType<ObjectResult>(response);
            Assert.Equal((object)(viewResult.StatusCode),HttpStatusCode.OK);
        }

        [Fact]
        public void Post_should_respond_with_400_if_country_is_unknown()
        {
            
            Quote quote = new Quote();
            quote.Country = "MONT";
            var response = controller.Post(quote);
            var viewResult = Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void Post_should_respond_with_400_when_model_is_not_valid()
        {
            Quote quote = new Quote();
            controller.ModelState.AddModelError("SessionName", "Required");
            var response = controller.Post(quote);

            var viewResult = Assert.IsType<BadRequestResult>(response);
        }

        
    }    
}
