using Hungyi.DataClass.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataAccess.Customer
{
    public interface ICustomerDao
    {

        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CustomerEntity> GetAllCustomer();

        int InsertCustomer(IEnumerable<CustomerEntity> customerEntity);
    }
}
