using Dapper;
using Microsoft.Data.SqlClient;
using Northwind.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Northwind.Application.Repository
{
	public class EmployeeRepository : IGenericRepository<Employee>
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;
		public EmployeeRepository(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("SqlConnection");
		}

		public async Task<int> AddAsync(Employee entity)
		{
			var sql = "INSERT INTO Employees (LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,PhotoPath)" +
				" VALUES (@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country,@HomePhone,@Extension,@Photo,@Notes,@PhotoPath)";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.ExecuteAsync(sql, entity);

				return result;
			}
		}

		public async Task<int> DeleteAsync(int id)
		{
			var sql = "DELETE FROM Employees WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.ExecuteAsync(sql, new { Id = id });

				return result;
			}
		}

		public async Task<IReadOnlyList<Employee>> GetAllAsync()
		{
			var sql = "SELECT * FROM Employees";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.QueryAsync<Employee>(sql);

				return result.ToList();
			}
		}

		public async Task<Employee> GetByIdAsync(int id)
		{
			var sql = "SELECT * FROM Employees WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });

				return result;
			}
		}

		public async Task<int> UpdateAsync(Employee entity)
		{
			var sql = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title,TitleOfCourtesy=@TitleOfCourtesy,BirthDate=@BirthDate,HireDate=@HireDate," +
				"Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,HomePhone=@HomePhone,Extension=@Extension,Photo=@Photo,Notes=@Notes,PhotoPath=@PhotoPath  WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{
				var result = await connection.ExecuteAsync(sql, entity);

				return result;
			}
		}
	}
}
