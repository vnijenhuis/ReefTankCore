using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReefTankCore.Models.Inhabitants;

namespace ReefTankCore.Web.Data
{
    public static class DbInitializer
    {
        //public static void Initialize(ReefContext context)
        //{
        //    context.Database.EnsureCreated();

        //    // Look for any inhabitants.
        //    if (context.Inhabitants.Any())
        //    {
        //        return;   // DB has been seeded
        //    }

        //    var family = new Family()
        //    {
        //        Name = "Pomacentridae",
        //        Description = "Pomacentridae is a family of perciform fish, comprising the damselfishes and clownfishes. " +
        //                      "They are primarily marine, while a few species inhabit freshwater and brackish environments " +
        //                      "(e.g., Neopomacentrus aquadulcis, N. taeniurus, Pomacentrus taeniometopon, Stegastes otophorus)." +
        //                      "They are noted for their hardy constitutions and territoriality. Many are brightly colored, so they are popular in aquaria." +
        //                      "Around 385 species are classified in this family, in about 29 genera. Of these, members of two genera, Amphiprion and Premnas (subfamily Amphiprioninae), " +
        //                      "are commonly called clownfish or anemonefish, while members of other genera (e.g., Pomacentrus) are commonly called damselfish." +
        //                      " The members of this family are classified in four subfamilies: Amphiprioninae, Chrominae, Lepidozyginae, and Pomacentrinae."
        //    };

        //    var genus = new Genus()
        //    {
        //        Family = family,
        //        Name = "Chrysiptera",
                    
        //    };
        //    family.Genus = new List<Genus>() {genus};

        //    context.Families.Add(family);
        //    context.Genuses.Add(genus);

        //    var inhabitants = new Inhabitant[]
        //    {
        //        new Inhabitant()
        //        {
        //            Name = "Yellowtail Damselfish",
        //            Species = "parasema",
        //            Length = 10,
        //            Volume = 150,
        //            Genus = genus,
        //            Hardiness = Hardiness.Hardy,
        //            ReefSafety = ReefSafety.Always,
        //            Suitability = Suitability.Suitable,
        //            Temperament = Temperament.SemiAgressive,
        //            Description = "Though most Yellowtail Damselfish will ignore other fish, invertebrates, or corals, some may be territorial towards its own kind or similar-sized fish.",
        //            Tags = new List<Tag>(),
        //            References = new List<Reference>(),
        //        },
        //        new Inhabitant()
        //        {
        //            Name = "Azure Damselfish",
        //            Species = "hemicyanea",
        //            Length = 10,
        //            Volume = 150,
        //            Genus = genus,
        //            Hardiness = Hardiness.Hardy,
        //            ReefSafety = ReefSafety.Always,
        //            Suitability = Suitability.Suitable,
        //            Temperament = Temperament.SemiAgressive,
        //            Description = "The Azure Damselfish diet should consist of quality flake foods, frozen meaty foods such as brine or mysis shrimp and occasionally dried seaweed offered on a feeding clip.",
        //            Tags = new List<Tag>(),
        //            References = new List<Reference>(),
        //        },
        //    };
        //    foreach (var s in inhabitants)
        //    {
        //        context.Inhabitants.Add(s);
        //    }
        //    context.SaveChanges();
        //}
    }
}
