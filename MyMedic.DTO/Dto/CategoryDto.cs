﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Dto
{
	public class CategoryDto
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public Guid? ParentCategoryId { get; set; }
		public List<ProductImageDto>? Images { get; set; }
	}
}
