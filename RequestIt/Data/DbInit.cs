using RequestIt.Models;
using System.Linq;

namespace RequestIt.Data
{
    public class DbInit
    {
        public static void Init(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            //eventueel opvulling van de database. Redelijk moeilijk voor users? 

            if (context.Status.Any())
            {
                return;
            }

            var statussen = new Status[]
            {
                new Status { Naam = "Verstuurd", Omschrijving = "Status is verstuurd en wacht op ontvangst" },
                new Status { Naam = "Ontvangen", Omschrijving = "Aanvraag is onvangen en wordt z.s.m toegewezen" },
                new Status { Naam = "Toegewezen", Omschrijving = "Aanvraag is toegewezen aan een behandelaar" },
                new Status { Naam = "In Behandeling", Omschrijving = "Aanvraag is in behandeling" },
                new Status { Naam = "Wacht op goedkeuring", Omschrijving = "Aanvraag is klaar en wacht op goedkeuring klant" },
                new Status { Naam = "Klaar", Omschrijving = "Aanvraag is in behandeling" },
                new Status { Naam = "Afgesloten", Omschrijving = "Aanvraag afgehandeld" }
            };
            foreach (Status s in statussen)
            {
                context.Status.Add(s);
            }
            context.SaveChanges();

        }
    }
}
