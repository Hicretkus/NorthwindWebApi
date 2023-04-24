﻿using Castle.Core.Configuration;
using Northwind.Domain.Entities;

namespace Northwind.Application.Repository
{
    public class EmployeeRepository : IGenericRepository<Employee>
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public Task<int> AddAsync(Employee entity)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Employee>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Employee> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> UpdateAsync(Employee entity)
		{
			throw new NotImplementedException();
		}

		//public Task<int> AddAsync(Employee entity)
		//{
		//    var sql = "Insert into Employees(LastName,FirstName,Title) VALUES (@LastName,@FirstName,@Title)";

		//    return;
		//}

		//public Task<int> DeleteAsync(int id)
		//{
		//    var sql = "DELETE FROM Employees WHERE EmployeeID = @id";

		//    return;
		//}

		//public Task<IReadOnlyList<Employee>> GetAllAsync()
		//{
		//    var sql = "SELECT * FROM Employees";

		//    return;
		//}

		//public Task<Employee> GetByIdAsync(int id)
		//{
		//    var sql = "SELECT * FROM Employees WHERE EmployeeID = @id";

		//    return;
		//}

		//public Task<int> UpdateAsync(Employee entity)
		//{
		//    var sql = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title  WHERE EmployeeID = @id";

		//    return;
		//}
	}
}
