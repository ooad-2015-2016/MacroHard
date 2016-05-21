using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShEM.BazaPodataka.Models
{
    public class Pjesma : Artikal
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Musician { get; set; }
        public double Length { get; set; }
        public string Album { get; set; }
    }
}
