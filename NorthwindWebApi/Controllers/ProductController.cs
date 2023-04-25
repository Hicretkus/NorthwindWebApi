using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Dtos;
using Northwind.Application.Repository;
using Northwind.Domain.Entities;

namespace Northwind.Api.Controllers
{
	    [Route("api/[controller]")]
	    [ApiController]
	    public class ProductController : ControllerBase
	    {
		private readonly IMapper _mapper;
		private readonly ProductRepository _productRepository;
		public ProductController(IMapper mapper, ProductRepository productRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;

		}
		[HttpGet("GetProduct")]
		public async Task<IActionResult> GetAll()
		{
			var data = await _productRepository.GetAllAsync();
			var productData = _mapper.Map<List<ProductDto>>(data);

			return Ok(productData);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _productRepository.GetByIdAsync(id);
			var productData = _mapper.Map<List<ProductDto>>(data);
            if (productData == null) return Ok();

			return Ok(productData);
		}

		[HttpPost("PostProduct")]
		public async Task<IActionResult> Add(Product product)
		{
			var data = await _productRepository.AddAsync(product);
			var productData = _mapper.Map<List<ProductDto>>(data);

			return Ok(productData);
		}

		[HttpDelete("DeleteProduct")]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _productRepository.DeleteAsync(id);
			var productData = _mapper.Map<List<ProductDto>>(data);

			return Ok(productData);
		}

		[HttpPut("PutProduct")]
		public async Task<IActionResult> Update(Product product)
		{
			var data = await _productRepository.UpdateAsync(product);
			var productData = _mapper.Map<List<ProductDto>>(data);

			return Ok(productData);
		}
	}
}
