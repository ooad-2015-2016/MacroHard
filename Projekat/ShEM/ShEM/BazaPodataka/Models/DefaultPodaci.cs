using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShEM.BazaPodataka.Models
{
    public class DefaultPodaci
    {
        public static void Initialize(DBContext context)
        {
            if (!context.korisnici.Any())
            {
                context.korisnici.AddRange(
                    new Korisnik()
                    {
                        username = "johndoe",
                        email = "john.doe@gmail.com",
                        name = "john",
                        lName = "doe",
                        //picture = 
                        numberOfCollections = 0
                    }
                    
                );
                context.SaveChanges();
            }
            if (!context.Komentari.Any())
            {
                context.Komentari.AddRange(
                    new Komentar()
                    {
                        Text = "le dosada prava",

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
