using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using Shop.IRepository;

namespace Shop.Repository
{
    class BannerRepository:BaseRepository<Banner>,IBannerRepository
    {
        //要同时实现BaseRepository<Banner>,IBannerRepository
        //
    }
}
