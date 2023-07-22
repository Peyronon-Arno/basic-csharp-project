using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bibliotheque.entity
{
    [Table("APP_EXPERIENCE")]
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EXP_ID")]
        public int Id { get; set; }

        [Column("EMP_ID")]
        public int IdEmploye { get; set; }

        [Column("EXP_INTITULE")]
        public string Intitule { get; set; }

        [Column("EXP_DATE")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Intitule: {Intitule}, Date: {Date}";
        }
    }
}
