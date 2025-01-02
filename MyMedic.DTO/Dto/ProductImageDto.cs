using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Dto
{
	public class ProductImageDto
	{
		public Guid Id { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
	}
}
