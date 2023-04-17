using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Dtos;
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

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _customerRepository.GetAllAsync();
			var customerData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(customerData);
			
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _customerRepository.GetByIdAsync(id);
			var customerData = _mapper.Map<List<CustomerDto>>(data);
			if (customerData == null) return Ok();
			return Ok(customerData);
			
           
        }
        [HttpPost("PostCustomer")]
        public async Task<IActionResult> Add(Customer customer)
        {
            var data = await _customerRepository.AddAsync(customer);
			var customerData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(customerData);

		}
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerRepository.DeleteAsync(id);
			var customerData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(customerData);
		}
        [HttpPut("PutCustomer")]
        public async Task<IActionResult> Update(Customer customer)
        {
            var data = await _customerRepository.UpdateAsync(customer);
			var customerData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(customerData);
		}
    }
}
