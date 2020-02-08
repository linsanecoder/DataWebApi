using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataWebAPI.Models
{
	public class FoodItem
	{
			[Key]
			public int ID { get; set; }
			public string Name { get; set; }
			public string Description { get; set; }
			public string Picture { get; set; }
			public decimal Price { get; set; }
	}
}
