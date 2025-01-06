using Helpers;
using MyMedic.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Dto
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		//public UsersEntity? User { get; set; }
		public DateTime CreatedAt { get; set; }
		//public string Status { get; set; } = "NotSent";
		public List<ProductDto>? Products { get; set; }
		public OrderStatus Status { get; set; } = OrderStatus.NotSent;
		public decimal TotalAmount { get; set; } = decimal.Zero;
		public string UserPhone { get; set; } = string.Empty;
		public string UserAddress { get; set; } = string.Empty;
		public bool Paid { get; set; } = false;
	}
}
