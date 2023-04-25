using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Northwind.Domain.Entities;


namespace Northwind.Application.Repository
{
    public class ProductRepository : IGenericRepository<Product>
    {	
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;
		public ProductRepository(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("SqlConnection");
		}

		public async Task<int> AddAsync(Product entity)
		{

		var sql = "INSERT INTO Products (Name,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,AddedOn) VALUES (@Name,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued,@AddedOn)";
			using (var connection = new SqlConnection(_connectionString))
			{				
				var result = await connection.ExecuteAsync(sql, entity);

				return result;
			}
		}

		public async Task<int> DeleteAsync(int id)
		{
		    var sql = "DELETE FROM Products WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{				
				var result =  await connection.ExecuteAsync(sql, new { Id = id });

				return result;
			}

		}

		public async Task<IReadOnlyList<Product>> GetAllAsync()
		{
		    var sql = "SELECT * FROM Products";

			using (var connection = new SqlConnection(_connectionString))
			{				
				var result =  await connection.QueryAsync<Product>(sql);

				return result.ToList();
			}
		}

		public async Task<Product> GetByIdAsync(int id)
		{
		    var sql = "SELECT * FROM Products WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{				
				var result = await  connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });

				return result;
			}
		}

		public async Task<int> UpdateAsync(Product entity)
		{
		    var sql = "UPDATE Products SET Name = @Name, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel=@ReorderLevel, Discontinued=@Discontinued ,AddedOn=@AddedOn WHERE Id = @id";

			using (var connection = new SqlConnection(_connectionString))
			{				
				var result =  await connection.ExecuteAsync(sql, entity);

				return result;
			}
		}
	}
}
