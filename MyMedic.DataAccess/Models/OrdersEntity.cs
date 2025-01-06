using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Models
{
	public class OrdersEntity
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public UsersEntity? User { get; set; }

		public List<ProductsEntity>? Products { get; set; }

		public decimal TotalAmount { get; set; } = decimal.Zero;
		public string UserPhone { get; set; } = string.Empty;
		public string UserAddress {  get; set; } = string.Empty;	
		public DateTime CreatedAt { get; set; }
		public OrderStatus Status { get; set; } = OrderStatus.NotSent;
		public bool Paid { get; set; } = false;
		

	}
}
