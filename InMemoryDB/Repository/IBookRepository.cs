using InMemoryDB.Repository.Entity;

namespace InMemoryDB.Repository
{
    public interface IBookRepository : IGenericRepository<Book, int>
    {
    }
}