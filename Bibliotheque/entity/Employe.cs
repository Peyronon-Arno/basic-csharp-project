using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bibliotheque.entity
{
    [Table("APP_EMPLOYE")]

    public class Employe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EMP_ID")]
        public int Id { get; set; }

        [Column("EMP_NOM")]
        public string Nom { get; set; }

        [Column("EMP_DATE")]
        public string Prenom { get; set; }

        [Column("EMP_DATENAISSANCE")]
        public DateTime DateNaissance { get; set; }

        [Column("EMP_ANCIENNETE")]
        public int Anciennete { get; set; }


        [Column("EMP_BIOGRAPHIE")]
        public string Biographie { get; set; }

        [Column("EMP_DIPLOME")]
        public string Diplome { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nom: {Nom}, Prénom: {Prenom}, Date de naissance: {DateNaissance}, Ancienneté: {Anciennete}, Biographie: {Biographie}";
        }
     }
}
