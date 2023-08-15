using InMemoryDB.Data;
using InMemoryDB.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InMemoryDB.Repository.impl
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApiContext _context;

        public AuthorRepository(ApiContext apiContext)
        {
            _context = apiContext;
        }

        public List<Author> GetAll()
        {
            var list = _context.Authors
                .Include(a => a.Books)
                .ToList();
            return list;
        }

        public Author GetById(int id)
        {
            var author = _context.Authors
                .Include(a => a.Books)
                .FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                throw new ApplicationException("No existe el registro con id " + id);
            }

            return author;
        }

        public Author Create(Author data)
        {
            EntityEntry<Author> result = _context.Authors.Add(data);
            _context.SaveChanges();
            return result.Entity;
        }

        public Author Update(Author data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return data;
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}