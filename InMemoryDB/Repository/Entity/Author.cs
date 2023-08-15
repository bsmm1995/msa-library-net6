using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InMemoryDB.Repository.Entity
{
    [Table("AUTHOR", Schema = "dbo")]
    public class Author
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "varchar(75)"),]
        [Display(Name = "FIRST_NAME")]
        [Required(ErrorMessage = "El campo nombres es obligatorio")]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = default!;
    }
}