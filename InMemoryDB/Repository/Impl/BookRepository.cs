using InMemoryDB.Data;
using InMemoryDB.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InMemoryDB.Repository.impl
{
    public class BookRepository : IBookRepository
    {
        private readonly ApiContext _context;

        public BookRepository(ApiContext apiContext)
        {
            _context = apiContext;
        }

        public List<Book> GetAll()
        {
            var list = _context.Books
                .Include(a => a.Author)
                .ToList();
            return list;
        }

        public Book GetById(int id)
        {
            var book = _context.Books
                .Include(a => a.Author)
                .FirstOrDefault(a => a.Id == id);
            if (book == null)
            {
                throw new ApplicationException("No existe el registro con id " + id);
            }

            return book;
        }

        public Book Create(Book data)
        {
            EntityEntry<Book> result = _context.Books.Add(data);
            _context.SaveChanges();
            return result.Entity;
        }

        public Book Update(Book data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return data;
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}