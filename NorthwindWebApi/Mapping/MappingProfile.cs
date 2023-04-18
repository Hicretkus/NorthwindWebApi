using AutoMapper;
using Northwind.Application.Dtos;
using Northwind.Domain.Entities;

namespace Northwind.Api.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<Customer, CustomerDto>().ReverseMap();
			CreateMap<Employee, EmployeeDto>().ReverseMap();

		}
	}
}
