﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;
using WeShop.IRepository;
using WeShop.IService;

namespace WeShop.Service
{
    public class SortService : BaseService<Sort>,ISortService
    {
        public SortService(ISortRepository baseService) : base(baseService)
        {
        }
    }
}
