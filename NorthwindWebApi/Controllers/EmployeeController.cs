using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Dtos;
using Northwind.Application.Repository;
using Northwind.Domain.Entities;

namespace Northwind.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly EmployeeRepository _employeeRepository;
		public EmployeeController(IMapper mapper, EmployeeRepository employeeRepository)
		{
			_mapper = mapper;
			_employeeRepository = employeeRepository;
		}

		[HttpGet("GetEmployee")]
		public async Task<IActionResult> GetAll()
		{
			var data = await _employeeRepository.GetAllAsync();
			var employeeData = _mapper.Map<List<EmployeeDto>>(data);

			return Ok(employeeData);

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _employeeRepository.GetByIdAsync(id);
			var employeeData = _mapper.Map<List<EmployeeDto>>(data);
			if (employeeData == null) return Ok();

			return Ok(employeeData);


		}
		[HttpPost("PostEmployee")]
		public async Task<IActionResult> Add(Employee employee)
		{
			var data = await _employeeRepository.AddAsync(employee);
			var employeeData = _mapper.Map<List<EmployeeDto>>(data);

			return Ok(employeeData);
		}
		[HttpDelete("DeleteEmployee")]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _employeeRepository.DeleteAsync(id);
			var employeeData = _mapper.Map<List<EmployeeDto>>(data);

			return Ok(employeeData);
		}
		[HttpPut("PutEmployee")]
		public async Task<IActionResult> Update(Employee employee)
		{
			var data = await _employeeRepository.UpdateAsync(employee);
			var employeeData = _mapper.Map<List<EmployeeDto>>(data);

			return Ok(employeeData);
		}
	}
}
