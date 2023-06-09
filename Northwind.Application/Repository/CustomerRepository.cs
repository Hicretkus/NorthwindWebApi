﻿using Microsoft.Data.SqlClient;
using Northwind.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Northwind.Application.Repository
{
	public class CustomerRepository : IGenericRepository<Customer>
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;
		public CustomerRepository(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("SqlConnection");
		}
		public async Task<int> AddAsync(Customer entity)
		{
			var sql = "INSERT INTO Customers (Name,Contact,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax) VALUES (@Name,@Contact,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.ExecuteAsync(sql, entity);

				return result;

			}
		}

		public async Task<int> DeleteAsync(int id)
		{
			var sql = "DELETE FROM Customers WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.ExecuteAsync(sql, new { Id = id });

				return result;
			}
		}

		public async Task<IReadOnlyList<Customer>> GetAllAsync()
		{
			var sql = "SELECT * FROM Customers";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.QueryAsync<Customer>(sql);

				return result.ToList();
			}
		}

		public async Task<Customer> GetByIdAsync(int id)
		{
			var sql = "SELECT * FROM Customers WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result =await  connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });

				return result;
			}
		}

		public async Task<int> UpdateAsync(Customer entity)
		{
			var sql = "UPDATE Customers SET  Name = @Name, Contact = @Contact, ContactTitle = @ContactTitle,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,Phone=@Phone,Fax=@Fax WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.ExecuteAsync(sql, entity);

				return result;
			}
		}
	}
}
