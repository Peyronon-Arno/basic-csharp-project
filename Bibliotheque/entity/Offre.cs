using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bibliotheque.entity
{
    [Table("APP_OFFRE")]
    public class Offre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OFF_ID", Order = 0)]
        public int Id { get; set; }
        [Column("OFF_INTITULE")]
        public string Intitule { get; set; }
        [Column("OFF_DATE")]
        public DateTime Date { get; set; }
        [Column("OFF_SALAIRE")]
        public int Salaire { get; set; }
        [Column("OFF_DESCRIPTION")]
        public string Description { get; set; }

        [ForeignKey("IdStatut")]
        public Statut Statut { get; set; }
        [Column("STA_ID")]
        public int IdStatut { get; set; }

        [Column("OFF_RESPONSABLE")]
        public string Responsable { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Intitule: {Intitule}, Date: {Date}, Salaire: {Salaire}, Description: {Description}, Responsable: {Responsable}";
        }
    }
}
