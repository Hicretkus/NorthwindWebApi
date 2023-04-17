using Northwind.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; set; }
        ICustomerRepository Customer { get; set; }  
        IEmployeeRepository Employee { get; set; }
    }
}
