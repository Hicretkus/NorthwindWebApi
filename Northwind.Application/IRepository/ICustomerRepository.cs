﻿using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Repository
{
   
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
