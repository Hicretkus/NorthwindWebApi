using Northwind.Application.Repository;



namespace Northwind.Application.UnitOfWork
{
    public class UnitOfWork /*: IUnitOfWork*/
    {
        public UnitOfWork(IProductRepository productRepository,IEmployeeRepository employeeRepository,ICustomerRepository customerRepository)
        {
            Products = productRepository;
            Employee = employeeRepository;  
            Customer = customerRepository;
        }

        public IProductRepository Products { get; }
        public IEmployeeRepository Employee { get; }
        public ICustomerRepository Customer { get; }


      
    }
}
