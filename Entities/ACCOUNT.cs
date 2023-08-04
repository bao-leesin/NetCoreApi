using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetCoreApi.Entities
{
    public class ACCOUNT
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(8)]
        public string USERNAME { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(8)]
        public string PASSWORD { get; set; }
    }
}
