using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;

namespace Shop.IRepository
{
    public interface IBannerRepository:IBaseRepository<Banner>
    {
        //查询，通过数据库中查询出Banner表中的数据
        //只需要实现IBaseRepository的接口即可

    }


}
