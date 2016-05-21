using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShEM.BazaPodataka.Models
{
    public abstract class Artikal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ArticleID { get; set; } //PK
        public string Name { get; set; }
        public string Genre { get; set; }
        public byte[] ArticlePicture { get; set; }
    }
}
