﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        ICompanyRepository Catagory { get; }
        ICoverTypeRepository coverType { get; }
        IProductRepository Product { get; }

        IComapanyRepository Comapany { get; }

        IApplicationUserRepository ApplicationUser { get; }


        ISP_Call SP_Call { get; }
        void Save();
    }
}
