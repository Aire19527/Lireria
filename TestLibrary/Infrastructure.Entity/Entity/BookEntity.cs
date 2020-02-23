using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entity.Entity
{
    [Table("Book", Schema = "Library")]
    public class BookEntity
    {
        [Key]
        public int IdBook { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }


        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Costo")]
        public long Cost { get; set; }

        [Display(Name = "Precio Sugerido")]
        public long SuggestedPrice { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [ForeignKey("Editorial")]
        public int IdEditorial { get; set; }

        public EditorialEntity Editorial { get; set; }
    }
}
