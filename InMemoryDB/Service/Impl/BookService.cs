using InMemoryDB.Repository;
using InMemoryDB.Repository.Entity;
using InMemoryDB.Service.dto;

namespace InMemoryDB.Service.impl
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookDTO> GetAll()
        {
            var list = _bookRepository.GetAll().ToList();
            List<BookDTO> books = new List<BookDTO>();
            foreach (var element in list)
            {
                books.Add(new BookDTO
                {
                    Id = element.Id,
                    Title = element.Title
                });
            }

            return books;
        }

        public BookDTO GetById(int id)
        {
            var book = _bookRepository.GetById(id);

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title
            };
        }

        public BookDTO Create(BookDTO data)
        {
            Book book = new Book
            {
                Title = data.Title
            };
            book = _bookRepository.Create(book);
            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title
            };
        }

        public BookDTO Update(int id, BookDTO data)
        {
            Book book = _bookRepository.GetById(id);
            book.Title = data.Title;
            book = _bookRepository.Update(book);
            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title
            };
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}