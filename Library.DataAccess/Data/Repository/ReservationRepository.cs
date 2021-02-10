using Library.DataAccess.Data.Repository.IRepository;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess.Data.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _db;

        public ReservationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
