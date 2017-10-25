using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using Shop.IService;
using Shop.IRepository;

namespace Shop.Service
{
    class ProSortService : BaseService<ProSort>, IProSortService
    {
        public ProSortService(IBaseRepository<ProSort> ibaseRepositroy) : base(ibaseRepositroy)
        {
        }
    }
}
