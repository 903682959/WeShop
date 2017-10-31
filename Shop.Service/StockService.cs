﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using Shop.IService;
using Shop.IRepository;

namespace Shop.Service
{
    class StockService : BaseService<Stock>, IStockService
    {
        public StockService(IBaseRepository<Stock> ibaseRepositroy) : base(ibaseRepositroy)
        {
        }
    }
}
