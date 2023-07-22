using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bibliotheque.entity
{
    [Table("APP_STATUT")]

    public class Statut
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("STA_ID")]
        public int Id { get; set; }
        [Column("STA_LIBELLE")]
        public string Libelle { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Libelle: {Libelle}";
        }
     }
}
