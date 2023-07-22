using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotheque.entity
{
    [Table("APP_POSTULATION")]

    public class Postulation
    {
        [Key]
        [Column("POS_ID", Order=0)]
        public int Id { get; set; }

        [Key, ForeignKey("Offre")]
        [Column("OFF_ID", Order = 1)]
        public int IdOffre { get; set; }

        [Key, ForeignKey("Employe")]
        [Column("EMP_ID", Order = 2)]
        public int IdEmploye { get; set; }

        public Offre Offre { get; set; }

        public Employe Employe { get; set; }

        [Column("POS_DATE")]
        public DateTime Date { get; set; }

        [Column("POS_STATUT")]
        public int Statut { get; set; }

        public override string ToString()
        {
            return $"IdOffre: {IdOffre}, IdEmploye: {IdEmploye}, Date: {Date}, Statut: {Statut}";
        }

    }
}
