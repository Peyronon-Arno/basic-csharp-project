using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bibliotheque.entity
{

    [Table("APP_FORMATION")]
    public class Formation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("FOR_ID")]
        public int Id { get; set; }

        [ForeignKey("Employe")]
        [Column("EMP_ID")]
        public int IdEmploye { get; set; }

        public Employe Employe { get; set; }

        [Column("FOR_INTITULE")]
        public string Intitule { get; set; }

        [Column("FOR_DATE")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Employe: {Employe}, Intitule: {Intitule}, Date: {Date}";
        }
    }
}
