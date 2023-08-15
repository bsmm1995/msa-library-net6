using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InMemoryDB.Repository.Entity
{
    [Table("BOOK", Schema = "dbo")]
    public class Book
    {
        [Key] public int Id { get; set; } = default;
        public string Title { get; set; }
        public Author Author { get; set; }
    }
}