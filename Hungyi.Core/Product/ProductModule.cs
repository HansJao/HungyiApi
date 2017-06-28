using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Product;
using Hungyi.DataAccess.Product;
using Microsoft.Extensions.Configuration;

namespace Hungyi.Core.Product
{
    public class OrderModule : IProductModule
    {
        private IProductDao _productDao;
        private IConfiguration _configuration;
        public OrderModule(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        protected IProductDao ProductDao
        {
            get
            {
                if (this._productDao == null)
                {
                    this._productDao = new ProductDao(_configuration.GetValue<string>("DBInfo:ConnectionString"));
                }
                return this._productDao;
            }
            set
            {
                this._productDao = value;
            }
        }
        public IEnumerable<ProductEntity> GetAllProduct()
        {
            var result = ProductDao.GetAllProduct();
            return result;
        }

        public int InsertProduct(IEnumerable<ProductEntity> productData)
        {
            var result = ProductDao.InsertProduct(productData);
            return result;
        }
    }
}
