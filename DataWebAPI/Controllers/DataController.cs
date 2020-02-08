using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;

namespace MenuWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		  };

		private readonly ILogger<DataController> _logger;

		public DataController(ILogger<DataController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[EnableCors]
		public string Get()
		{
			var rng = new Random();

			var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				ID = index,
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToList();

			return JsonSerializer.Serialize(result);			
		}
	}
}
