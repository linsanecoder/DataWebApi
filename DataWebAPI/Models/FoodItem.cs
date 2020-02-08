using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuWebAPI.Models
{
	public class FoodItem
	{
			[Key]
			public int Id { get; set; }
			public string Name { get; set; }
			public string Description { get; set; }
			public string Picture { get; set; }
			public decimal Price { get; set; }
	}
}
