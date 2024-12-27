using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Models
{
	public class ProductsEntity
	{
		public Guid Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string ProductDescription { get; set; } = string.Empty ;
		public decimal ProductPrice { get; set; } = decimal.Zero;
		public Guid ProductCategoryId { get; set; }
		public CategoriesEntity? Category { get; set; }
		public bool ProductStatus { get; set; } = true;
		public List<OrdersEntity>? Orders { get; set; }
		public List<ProductImages>? Images { get; set; }

	}
}
