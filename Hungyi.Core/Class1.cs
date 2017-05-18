using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;
namespace Hungyi.Core
{
    public class Class1
    {
        private string connectionString;
        public Class1(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }
    }
}
