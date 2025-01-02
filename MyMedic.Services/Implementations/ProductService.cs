using Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.DataAccess.Repositories.Repositories;
using MyMedic.DTO.Dto;
using MyMedic.DTO.Mappers;
using MyMedic.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Implementations
{
	public class ProductService : IProductService
	{
	private readonly IUnitOfWork _unitOfWork;
		private readonly ProductsMapper _productsMapper;
		private readonly IFileService _fileService;
		public ProductService(IUnitOfWork unitOfWork, ProductsMapper productsMapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_productsMapper = productsMapper;
			_fileService = fileService;
		}

		public async Task<string> AddProductAsync(ProductCreateDto productDto)
		{

			if (productDto.Images == null || !productDto.Images.Any())
			{
				return "No images provided.";
			}

		
			var imageUrls = await _fileService.SaveImageAsync(productDto.Images);
				
			
			var productEntity = _productsMapper.ToEntity(productDto, imageUrls);
			await _unitOfWork.Products.AddAsync(productEntity);
			await _unitOfWork.SaveChangeAsync();
			return "Product added successfully.";
		
		}

		

		public async Task<PagedResult<ProductDto>> GetAllProducts(int page, int count)
		{
			var productsList =  _unitOfWork.Products.GetAllAsync();
			var productsWithImages = productsList.Result.Include(x => x.Images);
			var totalProducts = await productsWithImages.CountAsync();
			var products = await productsWithImages
				.Skip((page-1)*count)
				.Take(count)
				.ToListAsync();
			var pagedProducts = products.Select(p => _productsMapper.ToDto(p)).ToList();
			var pagedResult = new PagedResult<ProductDto>
			{
				Items = pagedProducts,
				PageSize = count,
				PageNumber = page,
				TotalCount = totalProducts
			};
			return pagedResult;
		}

		public async Task<PagedResult<ProductDto>> GetByCategory(Guid categoryId, int page, int count)
		{
			var productsList = _unitOfWork.Products.GetByCategoryAsync(categoryId);
			var totalProducts = await productsList.Result.CountAsync();
			var products = await productsList.Result.Skip((page-1) * count)
				.Take(count).ToListAsync();
			var pagedProducts = products.Select(p => _productsMapper.ToDto(p)).ToList();
			var pagedResult = new PagedResult<ProductDto>
			{
				Items = pagedProducts,
				PageSize = count,
				PageNumber = page,
				TotalCount = totalProducts
			};
			return pagedResult;
		}

		public Task<PagedResult<ProductDto>> GetByName(string name)
		{
				throw new NotImplementedException();
		}

		public Task<PagedResult<ProductDto>> GetByNameAndCategory(string name, Guid categoryId)
		{
			throw new NotImplementedException();
		}

		public Task<ProductsEntity> GetProduct(Guid id)
		{
			var product = _unitOfWork.Products.GetByIdAsync(id);
			return product;
		}

	}
}
