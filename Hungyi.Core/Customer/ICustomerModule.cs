using Hungyi.DataClass.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Core.Customer
{
    public interface ICustomerModule
    {

        /// <summary>
        /// Gets all customer information.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CustomerEntity> GetAllCustomerInfo();

        /// <summary>
        /// Adds the textile list.
        /// </summary>
        /// <param name="TextileList">The textile list.</param>
        /// <returns>回傳是否成功</returns>
        bool AddCustomerList(IEnumerable<CustomerEntity> customerList);


    }
}
