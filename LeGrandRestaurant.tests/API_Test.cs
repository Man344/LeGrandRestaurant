using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace LeGrandRestaurant.tests
{
    public class API_Test
    {
        [Fact]
        public async Task GET_retrieves_weather_forecast()
        {
            using var application = new WebApplicationFactory<API.Startup>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/weatherforecast");
            response.StatusCode.Equals(HttpStatusCode.OK);
        }
    }
}
