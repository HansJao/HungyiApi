using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Textile;
using Hungyi.DataAccess.Textile;
using System.Linq;
using Microsoft.Extensions.Configuration;

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
                if(this._textileDao == null)
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
        public IEnumerable<AllTextile> GetAllTextileInfo()
        {
            var allTextile = TextileDao.GetAllTextile().GroupBy(a => a.TextileName);

            var result = new List<AllTextile>();
            foreach (var i in allTextile)
            {
                result.Add(new AllTextile
                {
                    TextileName = i.Key,
                    ProductID = i.Select(a=>a.ProductID).FirstOrDefault(),
                    TextileInfo = i.GroupBy(d=>d.TextileColor).Select(a => new TextileInfo
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

        public IEnumerable<TextileEntity> GetTextileInfoByID(int ProductID)
        {
            var textileByProductID = TextileDao.GetTextileInfoByID(ProductID);
            return textileByProductID;
        }
    }
}
