using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Models
{
	public class CategoriesEntity
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public Guid? ParentCategoryId { get; set; }
		public CategoriesEntity? ParentCategory { get; set; }
		public List<CategoriesEntity>? SubCategories { get; set; }
		public List<ProductsEntity> Products { get; set; } = new();
		public List<ProductImages>? Images {  get; set; } 

	}
}
