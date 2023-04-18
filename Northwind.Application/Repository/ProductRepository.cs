using Microsoft.Extensions.Configuration;
using Northwind.Domain.Entities;


namespace Northwind.Application.Repository
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly IConfiguration _configuration;
        
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            
        var sql = "Insert into Products (ProductName,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) VALUES (@ProductName,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)";

            return;
        }

        public Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE ProductID = @id";

            return;
            
        }

        public Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";

            return;
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE ProductID = @id";

            return;
        }

        public Task<int> UpdateAsync(Product entity)
        {
            var sql = "UPDATE Products SET ProductName = @ProductName, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel=@ReorderLevel, Discontinued=@Discontinued  WHERE ProductID = @id";

            return;
        }
    }
}
