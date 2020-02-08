using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;
using MenuWebAPI.Models;

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

		[HttpGet("weather")]
		[EnableCors]
		public string GetWeather()
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

		[HttpGet("menu")]
		[EnableCors]
		public string GetMenu()
		{
			var rng = new Random();

			var result = Enumerable.Range(1, 5).Select(index => new FoodItem
			{
				ID = index,
				Name = "Food Name " + index.ToString(),
				Description = "Food Name " + index.ToString(),
				Picture = "Classic-Burger-508441287-200x200.jpg",
				Price = Convert.ToDecimal(index * 10 % 15 + 10) + (Convert.ToDecimal(new Random().Next() % 100) / 10)
			})
			.ToList();

			return JsonSerializer.Serialize(result);
		}
	}
}
