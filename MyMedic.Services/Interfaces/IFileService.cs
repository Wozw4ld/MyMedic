using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Interfaces
{
	public interface IFileService
	{
		public Task<List<string>> SaveImageAsync(List<IFormFile> images);

	}
}
