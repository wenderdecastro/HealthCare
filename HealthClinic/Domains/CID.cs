using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.Domains
{
    [Table("CID")]
    public class CID
    {
        [Key]
        public string Codigo { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Nome { get; set; }

    }
}
