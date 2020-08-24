using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Catagory { get; }
        ICoverTypeRepository coverType { get; }

        ISP_Call SP_Call { get; }
        void Save();
    }
}
