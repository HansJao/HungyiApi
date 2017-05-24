using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Textile;
using Hungyi.DataAccess.Textile;
using System.Linq;

namespace Hungyi.Core.Textile
{
    public class TextileModule : ITextileModule
    {
        private ITextileDao _textileDao;
        public TextileModule(ITextileDao textileDao)
        {
            this._textileDao = textileDao;
        }
        public IEnumerable<AllTextile> GetAllTextileInfo()
        {
            var allTextile = _textileDao.GetAllTextile().GroupBy(a => a.TextileName);

            var result = new List<AllTextile>();
            foreach (var i in allTextile)
            {
                result.Add(new AllTextile
                {
                    TextileName = i.Key,
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

            throw new NotImplementedException();
        }
    }
}
