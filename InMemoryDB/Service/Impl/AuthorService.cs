using InMemoryDB.Repository;
using InMemoryDB.Repository.Entity;
using InMemoryDB.Service.dto;

namespace InMemoryDB.Service.impl
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<AuthorDTO> GetAll()
        {
            var list = _authorRepository.GetAll().ToList();
            List<AuthorDTO> authors = new List<AuthorDTO>();
            foreach (var element in list)
            {
                authors.Add(new AuthorDTO
                {
                    Id = element.Id,
                    FirstName = element.FirstName,
                    LastName = element.LastName,
                    Books = MapBooksToDto(element.Books)
                });
            }

            return authors;
        }

        public AuthorDTO GetById(int id)
        {
            var author = _authorRepository.GetById(id);

            return new AuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = MapBooksToDto(author.Books)
            };
        }

        public AuthorDTO Create(AuthorDTO data)
        {
            Author author = new Author
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Books = MapBooksToEntity(data.Books)
            };
            author = _authorRepository.Create(author);
            return new AuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = MapBooksToDto(author.Books)
            };
        }

        public AuthorDTO Update(int id, AuthorDTO data)
        {
            Author author = _authorRepository.GetById(id);
            author.FirstName = data.FirstName;
            author.LastName = data.LastName;
            author = _authorRepository.Update(author);
            return new AuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = MapBooksToDto(author.Books)
            };
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }

        private List<BookDTO> MapBooksToDto(List<Book> list)
        {
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

        private List<Book> MapBooksToEntity(List<BookDTO> list)
        {
            List<Book> books = new List<Book>();
            foreach (var element in list)
            {
                books.Add(new Book
                {
                    Title = element.Title
                });
            }

            return books;
        }
    }
}