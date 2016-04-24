using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShEM.BazaPodataka.Models
{
    public class Komentar
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CommentId { get; set; } //PK
         public string Text { get; set; }       
        public byte[] CreatorPicture { get; set; }
        public int CreatorId { get; set; } 
        public int CollectionID { get; set; }
    }
}
