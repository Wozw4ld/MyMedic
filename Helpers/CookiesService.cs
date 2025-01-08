
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
	public class CookiesService 
	{
		private readonly IHttpContextAccessor _httpContext;
		public CookiesService(IHttpContextAccessor httpContext)
		{
			_httpContext = httpContext;
		}
		public Guid GetUserIdFromCookie()
		{
			var userIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Equals("userID"));
			if(userIdClaim != null)
			{
				var userId = Guid.Parse(userIdClaim.Value);
				return userId;
			}
			return Guid.Empty;
		}
	}
}
