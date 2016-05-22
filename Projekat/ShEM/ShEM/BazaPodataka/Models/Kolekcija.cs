using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShEM.BazaPodataka.Models
{
    public class Kolekcija
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CollectionId { get; set; } //PK
        public string Name { get; set; }
        public byte[] CollectionPicture { get; set; }
      //  public List<Artikal> Elementi { get; set; }
        public int CreatorId { get; set; }
        public bool status { get; set; }
    }
}
