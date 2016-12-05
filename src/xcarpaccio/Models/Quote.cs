using System;

namespace XCarpaccio.Models
{
    public class Quote
    {
       public string Country{get;set;}
       public DateTime DepartureDate{get;set;}
       public DateTime ReturnDate{get;set;}
       public int[] TravellerAges{get;set;}
       public string[] Options{get;set;}
       public string Cover{get;set;}       
    }
}

