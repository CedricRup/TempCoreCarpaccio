using Xunit;
using XCarpaccio.Models;
using XCarpaccio.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace XCarpaccio.Tests
{

    public class QuotesControllerTest
    {
        private Quote GetNormalQuote(){
            var quote = new Quote();
            quote.Country = "FR";
            quote.DepartureDate = new DateTime(2017,1,1);
            quote.ReturnDate = new DateTime(2017,1,10);
            quote.Options = Array.Empty<string>();
            quote.Cover = "BASIC";
            quote.TravellerAges = new []{66,67,68};
            return quote;
        }
        QuoteController controller;

        public QuotesControllerTest()
        {
            controller = new QuoteController();
        }

        [Fact]
        public void Post_should_respond_Quote()
        {    
            Quote quote = GetNormalQuote();
            var response = controller.Post(quote);
            var viewResult = Assert.IsType<OkObjectResult>(response);
            var answer = viewResult.Value as QuoteResponse;
            Assert.NotNull(answer);
        }

        [Fact]
        public void Post_400_when_stay_is_less_than_7_days()
        {
            Quote quote = GetNormalQuote();
            quote.DepartureDate = new DateTime(2017,1,1);
            quote.ReturnDate = new DateTime(2017,1,7);
            var response = controller.Post(quote);
            AssertBadRequest(response);
        }

        [Fact]
        public void Post_400_when_stay_When_Options()
        {
            Quote quote = GetNormalQuote();
            quote.Options = new []{"Glop"};
            var response = controller.Post(quote);
            AssertBadRequest(response);
        }

        [Fact]
        public void Post_400_when_stay_Cover_is_not_basic()
        {
            Quote quote = GetNormalQuote();
            quote.Cover = "GLOP";
            var response = controller.Post(quote);
            AssertBadRequest(response);
        }

        [Fact]
        public void Post_400_when_stay_all_age_is_above_or_equal_66()
        {
            Quote quote = GetNormalQuote();
            quote.TravellerAges = new[]{66,67,68};
            var response = controller.Post(quote);
            AssertOkResponse(response);
        }

        [Fact]
        public void Post_400_when_stay_one_age_is_below_66()
        {
            Quote quote = GetNormalQuote();
            quote.TravellerAges = new[]{66,45,68};
            var response = controller.Post(quote);
            AssertBadRequest(response);
        }

        [Fact]
        public void Post_is_able_to_quote()
        {
            var quote = GetNormalQuote();
            var response = controller.Post(quote);
            var quoteResponse = GetQuoteResponse(response);
            Assert.Equal(quoteResponse.Quote, 1.8m * 1 * (201 * 1.5m) * 9);
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
            AssertBadRequest(response);
        }

        public void AssertBadRequest(IActionResult result)
        {
            Assert.IsType<BadRequestResult>(result);
        }

        public QuoteResponse GetQuoteResponse(IActionResult result)
        {
            var viewResult = Assert.IsType<OkObjectResult>(result);
            return viewResult.Value as QuoteResponse;
        }

        public void AssertOkResponse(IActionResult result)
        {
            Assert.IsType<OkObjectResult>(result);
        }

        
    }    
}
