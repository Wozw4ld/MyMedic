using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Dto
{
	public class ProductCreateDto
	{
		public string ProductName { get; set; } = string.Empty;
		public string ProductDescription { get; set; } = string.Empty;
		public decimal ProductPrice { get; set; } = decimal.Zero;
		public Guid ProductCategoryId { get; set; }
		public bool ProductStatus { get; set; } = true;
		public List<IFormFile>? Images { get; set; }
	}
}
