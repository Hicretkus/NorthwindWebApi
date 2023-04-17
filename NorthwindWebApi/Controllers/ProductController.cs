using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Repository;
using Northwind.Domain.Entities;

namespace Northwind.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductController(IMapper mapper,IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository= productRepository;

        }
         [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _productRepository.GetAllAsync();
        return Ok (data);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _productRepository.GetByIdAsync(id);
        if (data == null) return Ok();
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        var data = await _productRepository.AddAsync(product);
        return Ok(data);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _productRepository.DeleteAsync(id);
        return Ok(data);
    }
    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        var data = await _productRepository.UpdateAsync(product);
        return Ok(data);
    }
    }
}
