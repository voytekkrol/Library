using Library.DataAccess.Data.Repository.IRepository;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DataAccess.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Book book)
        {
            var objFromDb = _db.Book.FirstOrDefault(s => s.Id == book.Id);

            objFromDb.Name = book.Name;
            objFromDb.Author = book.Author;
            objFromDb.PublishedDate = book.PublishedDate;
            objFromDb.Description = book.Description;

            _db.SaveChanges();
        }
    }
}
