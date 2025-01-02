using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MyMedic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Implementations
{
	public class FileService : IFileService
	{
		private readonly string _imagePath;
		public FileService(IConfiguration configuration)
		{
			_imagePath = configuration["ImagePath"] ?? "wwwroot/images/products";
		}
		public async Task<List<string>> SaveImageAsync(List<IFormFile> images)
		{
			var imagesPath = new List<string>();
			foreach (var image in images)
			{
				if(image.Length> 0)
				{
					var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
					var imagePath = Path.Combine(_imagePath, imageName);

					using(var stream = new FileStream(imagePath, FileMode.Create))
					{
						await image.CopyToAsync(stream);
					}
					imagesPath.Add(imageName);
				}
			}
			return imagesPath;
			
		}

		
	}
}
