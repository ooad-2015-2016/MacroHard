using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShEM.BazaPodataka.Models
{
    public class DefaultKorisnik
    {
        public static void Initialize(KorisnikDBContext context)
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
        }
    }
}
