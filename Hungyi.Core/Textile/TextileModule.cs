using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Textile;
using Hungyi.DataAccess.Textile;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Hungyi.DataClass.Product;
using Hungyi.DataClass.Request.Textile;

namespace Hungyi.Core.Textile
{
    public class TextileModule : ITextileModule
    {
        private ITextileDao _textileDao;
        private IConfiguration _configuration;
        public TextileModule(IConfiguration configuration)
        {
            this._configuration = configuration;
            //this._textileDao = new TextileDao(configuration.GetValue<string>("DBInfo:ConnectionString"));
        }

        protected ITextileDao TextileDao
        {
            get
            {
                if (this._textileDao == null)
                {
                    this._textileDao = new TextileDao(_configuration.GetValue<string>("DBInfo:ConnectionString"));
                }
                return this._textileDao;
            }
            set
            {
                this._textileDao = value;
            }
        }

        /// <summary>
        /// Adds the textile list.
        /// </summary>
        /// <param name="TextileList">The textile list.</param>
        /// <returns>
        /// 回傳是否成功
        /// </returns>
        public bool AddTextileList(IEnumerable<TextileAddInfo> TextileList)
        {
            var textileEntityList = new List<TextileEntity>();
            foreach (var textile in TextileList)
            {
                var weightArray = textile.Weight.Split(',');
                foreach (var weight in weightArray)
                {
                    textileEntityList.Add(new TextileEntity
                    {
                        ProductID = textile.ProductID,
                        TextileName = textile.TextileName,
                        TextileColor = textile.TextileColor,
                        TextileSpecification = textile.TextileSpecification,
                        Cost = textile.Cost,
                        Weight = float.Parse(weight),
                        Stored = textile.Stored,
                        Remark = textile.Remark,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                    });
                }
            }
            var succesCount = TextileDao.InsertTextile(textileEntityList);
            return true;
        }

        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns>
        /// 回傳所有商品資料
        /// </returns>
        public IEnumerable<ProductEntity> GetAllProduct()
        {
            var result = TextileDao.GetAllProduct();
            return result;
        }

        /// <summary>
        /// Gets all textile information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AllTextile> GetAllTextileInfo()
        {
            var allTextile = TextileDao.GetAllTextile().GroupBy(a => a.TextileName);

            var result = new List<AllTextile>();
            foreach (var i in allTextile)
            {
                result.Add(new AllTextile
                {
                    TextileName = i.Key,
                    ProductID = i.Select(a => a.ProductID).FirstOrDefault(),
                    TextileInfo = i.GroupBy(d => d.TextileColor).Select(a => new TextileInfo
                    {
                        TextileColor = a.Key,
                        Amount = i.Count(b => b.TextileColor == a.Key)
                    })
                    //new List<TextileInfo>
                    //{
                    //    new TextileInfo
                    //    {
                    //        TextileColor = i.Select(a=>a.TextileColor).FirstOrDefault(),
                    //        Amount = i.Count()
                    //    }
                    //}
                });
            }

            return result;
        }

        public IEnumerable<TextileEntity> GetTextileByListProductID(IEnumerable<int> productID)
        {
            return TextileDao.GetTextileByListProductID(productID);
        }

        /// <summary>
        /// Gets the textile information by identifier.
        /// </summary>
        /// <param name="ProductID">The product identifier.</param>
        /// <returns></returns>
        public IEnumerable<TextileEntity> GetTextileInfoByID(int ProductID)
        {
            var textileByProductID = TextileDao.GetTextileInfoByID(ProductID);
            return textileByProductID;
        }

        public bool UpdateTextile(IEnumerable<TextileEntity> TextileList)
        {
            var successCount = TextileDao.UpdateTextile(TextileList);
            return successCount == TextileList.Count();
        }
    }
}
