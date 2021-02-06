using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess.Data.Repository.IRepository
{
    interface IUnitOfWork : IDisposable
    {
        IBookRepository Book { get; }
        void Save();
    }
}
