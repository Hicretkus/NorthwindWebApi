using Castle.Core.Configuration;
using Northwind.Domain.Entities;

namespace Northwind.Application.Repository
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly IConfiguration _configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public Task<int> AddAsync(Customer entity)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Customer>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Customer> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> UpdateAsync(Customer entity)
		{
			throw new NotImplementedException();
		}

		//public Task<int> AddAsync(Customer entity)
		//{
		//    var sql = "Insert into Customers(CustomerName,ContactName,ContactTitle) VALUES (@CustomerName,@ContactName,@ContactTitle)";

		//    return;
		//}

		//public Task<int> DeleteAsync(int id)
		//{
		//    var sql = "DELETE FROM Customers WHERE CustomerID = @id";

		//    return;
		//}

		//public Task<IReadOnlyList<Customer>> GetAllAsync()
		//{
		//    var sql = "SELECT * FROM Customers";

		//    return;
		//}

		//public Task<Customer> GetByIdAsync(int id)
		//{
		//    var sql = "SELECT * FROM Customers WHERE CustomerID = @id";

		//    return;
		//}

		//public Task<int> UpdateAsync(Customer entity)
		//{
		//    var sql = "UPDATE Customers SET CustomerName = @CustomerName, ContactName = @ContactName, ContactTitle = @ContactTitle  WHERE CustomerID = @id";

		//    return;
		//}
	}
}
