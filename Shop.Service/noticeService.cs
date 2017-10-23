using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.IRepository;
using Shop.Model;
using Shop.IService;

namespace Shop.Service
{
   public  class noticeService : BaseService<Notice>, InoticeService
    {
        public noticeService(IBaseRepository<Notice> ibaseRepositroy) : base(ibaseRepositroy)
        {
        }
    }
}
