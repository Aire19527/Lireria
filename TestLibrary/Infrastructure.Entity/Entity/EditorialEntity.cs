using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entity.Entity
{
    [Table("Editorial", Schema = "Library")]
    public class EditorialEntity
    {
        [Key]
        public int IdEditorial { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public ICollection<BookEntity> BookEntity { get; set; }
    }
}
