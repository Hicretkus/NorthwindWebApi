using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Repository;
using Northwind.Domain.Entities;
using System.Net;

namespace Northwind.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;
		public CustomerController(IMapper mapper,ICustomerRepository customerRepository)
		{
			_mapper = mapper;
            _customerRepository = customerRepository;
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _customerRepository.GetAllAsync();

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _customerRepository.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            var data = await _customerRepository.AddAsync(customer);
            return Ok(data);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerRepository.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            var data = await _customerRepository.UpdateAsync(customer);
            return Ok(data);
        }
    }
}
