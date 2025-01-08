using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Dto
{
	
		public class OrderCreateDto
		{	
			public DateTime CreatedAt { get; set; }
			
			public List<Guid> Products { get; set; }
			public OrderStatus Status { get; set; } = OrderStatus.NotSent;
			public decimal TotalAmount { get; set; } = decimal.Zero;
			public string UserPhone { get; set; } = string.Empty;
			public string UserAddress { get; set; } = string.Empty;
			public bool Paid { get; set; } = false;
		}
	
}
