using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Book { get; }
        IUserRepository User { get; }
        IReservationRepository Reservation { get; }

        void Save();
    }
}
