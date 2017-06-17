using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Customer;
using Hungyi.DataAccess.Customer;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Hungyi.Core.Customer
{
    public class CustomerModule : ICustomerModule
    {
        private ICustomerDao _customerDao;
        private IConfiguration _configuration;
        public CustomerModule(IConfiguration configuration)
        {
            this._configuration = configuration;
            //this._textileDao = new TextileDao(configuration.GetValue<string>("DBInfo:ConnectionString"));
        }

        protected ICustomerDao CustomerDao
        {
            get
            {
                if (this._customerDao == null)
                {
                    this._customerDao = new CustomerDao(_configuration.GetValue<string>("DBInfo:ConnectionString"));
                }
                return this._customerDao;
            }
            set
            {
                this._customerDao = value;
            }
        }

        /// <summary>
        /// Gets all customer information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerEntity> GetAllCustomerInfo()
        {
            return CustomerDao.GetAllCustomer();
        }

        /// <summary>
        /// Adds the customer list.
        /// </summary>
        /// <param name="customerList"></param>
        /// <returns>
        /// 回傳是否成功
        /// </returns>
        public bool AddCustomerList(IEnumerable<CustomerEntity> customerList)
        {
            var result = _customerDao.InsertCustomer(customerList);
            return customerList.Count() == result;
        }
    }
}
