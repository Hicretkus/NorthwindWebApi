using Microsoft.Data.SqlClient;
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
			_connectionString= _configuration.GetConnectionString("SqlConnection");
		}
		public async Task<int> AddAsync(Customer entity)
		{
			var sql = "Insert into Customers (Id,Name,Contact,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax) VALUES (@Id,@Name,@Contact,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)";

			using (var connection = new SqlConnection(_connectionString))
			{
				//connection.Open();
				var result = await connection.ExecuteAsync(sql, entity);
				return result;
			}
		}

		public Task<int> DeleteAsync(int id)
		{
			var sql = "DELETE FROM Customers WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				//connection.Open();
				var result = connection.ExecuteAsync(sql, new { Id = id });
				return result;
			}
		}

		public async Task<IReadOnlyList<Customer>> GetAllAsync()
		{
			var sql = "SELECT * FROM Customers";

			using (var connection = new SqlConnection(_connectionString))
			{
				//connection.Open();
				var result = await connection.QueryAsync<Customer>(sql);
				return result.ToList();
			}
		}

		public Task<Customer> GetByIdAsync(int id)
		{
			var sql = "SELECT * FROM Customers WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				//connection.Open();
				var result = connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });
				return result;
			}
		}

		public Task<int> UpdateAsync(Customer entity)
		{
			var sql = "UPDATE Customers SET Name = @Name, Contact = @Contact, ContactTitle = @ContactTitle,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,Phone=@Phone,Fax=@Fax  WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				//connection.Open();
				var result = connection.ExecuteAsync(sql, entity);
				return result;
			}
		}
	}
}
