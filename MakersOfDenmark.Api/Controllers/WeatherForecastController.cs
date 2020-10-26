﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MakersOfDenmark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        private static readonly string[] scopeRequiredByApi = {"access_as_user"};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // Used as a Testing101 API test.
        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }


        // Used as pipeline test
        [HttpGet("/azure")]
        public string Get(){
            return "Hello Azure";
        }

    }
}