using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using System.Runtime.Remoting.Messaging;

namespace Shop.Repository
{
    /// <summary>
    /// 工厂类，用来获取上下文对象  线程单例模式（查询）
    /// </summary>
  public   class DbContextFactory
    {
        public static WeShop CreateDbContext()
        {
            WeShop dBContext = CallContext.GetData("DbContext") as WeShop;
            if(dBContext==null)
            {
                dBContext = new WeShop();
                CallContext.SetData("DbContext", dBContext);
            }
            return dBContext;
        }
    }
}
