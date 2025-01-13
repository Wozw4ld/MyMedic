using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Models
{
	public class ProductImages
	{
		public Guid Id { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
		public Guid ProductId { get; set; }
		public Guid CategoryId { get; set; }
		public ProductsEntity? Product { get; set; }
		public CategoriesEntity? Category { get; set; }
	}	
}
