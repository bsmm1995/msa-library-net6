using InMemoryDB.Service.dto;

namespace InMemoryDB.Service
{
    public interface IBookService : IGenericService<BookDTO, int>
    {
    }
}