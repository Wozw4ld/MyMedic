using MyMedic.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Dto
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string ProductDescription { get; set; } = string.Empty;
		public decimal ProductPrice { get; set; } = decimal.Zero;
		public Guid ProductCategoryId { get; set; }
		public bool ProductStatus { get; set; } = true;
		public List<ProductImageDto>? Images { get; set; }

	}
}
