using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShEM.BazaPodataka.Models
{
    public class Korisnik
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int userID { get; set; } //PK
        public string username { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string lName { get; set; }
        public byte[] picture { get; set; }
        public int numberOfCollections { get; set; }
    }
}
