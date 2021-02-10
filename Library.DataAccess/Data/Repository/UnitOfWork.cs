using Library.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Book = new BookRepository(_db);
            User = new UserRepository(_db);
            Reservation = new ReservationRepository(_db);
        }

        public IBookRepository Book { get; private set; }
        public IUserRepository User { get; private set; }
        public IReservationRepository Reservation { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
