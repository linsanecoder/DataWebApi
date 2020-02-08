using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;
using DataWebAPI.Models;

namespace DataWebAPI.Controllers
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
		private readonly MenuDbContext _menuDb;

		public DataController(MenuDbContext menuDbContext, ILogger<DataController> logger)
		{
			_menuDb = menuDbContext;
			_logger = logger;
		}

		[HttpGet]
		public string Get()
		{
			return "https://localhost:44320/data/menu;https://localhost:44320/data/weather";
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
			IList<FoodItem> menuItems = new List<FoodItem>();

			using (var db = _menuDb)
			{
				foreach (var f in db.FoodItems)
				{
					menuItems.Add(f);
				}
			}
			//var rng = new Random();

			//var result = Enumerable.Range(1, 5).Select(index => new FoodItem
			//{
			//	ID = index,
			//	Name = "Food Name " + index.ToString(),
			//	Description = "Food Name " + index.ToString(),
			//	Picture = "Classic-Burger-508441287-200x200.jpg",
			//	Price = Convert.ToDecimal(rng.Next(9, 28)) + (Convert.ToDecimal(rng.Next(1,99)) / 10)
			//})
			//.ToList();

			return JsonSerializer.Serialize(menuItems);
		}
	}
}
