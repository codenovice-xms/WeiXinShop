using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;

namespace WeShop.Repository
{
    public class DbContextFactory
    {
        public static WeShopDb GetIntance()
        {
            var _dbContext = CallContext.GetData("dbContext") as WeShopDb;
            if (_dbContext == null)
            {
                _dbContext = new WeShopDb();
                CallContext.SetData("dbContext", _dbContext);
            }
            return _dbContext;
        }
    }
}
