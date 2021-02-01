using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using TestORMCodeFirst.Entities;

namespace TestORMCodeFirst.Entities
{
    [Table("COURS")]
    public class Cours
    {
        //Propriétés
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar(10)")]
        public string CodeCours { get; set; }
        
        [Required]
        [Column(TypeName ="varchar(15)")]
        public string NomCours { get; set; }

        //Propriétés de navigation
        public virtual ICollection<InscriptionCours> Inscriptions { get; set; }
    }
}
