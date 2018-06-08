using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Enums;
using ReefTankCore.Models.Users;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Controllers;
using ReefTankCore.Web.Models.Account;

namespace ReefTankCore.Web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ReefContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            foreach (var entity in context.References)
                context.References.Remove(entity);
            context.SaveChanges();

            foreach (var entity in context.Tags)
                context.Tags.Remove(entity);
            context.SaveChanges();

            foreach (var entity in context.Creatures)
                context.Creatures.Remove(entity);
            context.SaveChanges();

            foreach (var entity in context.Subcategories)
                context.Subcategories.Remove(entity);
            context.SaveChanges();

            foreach (var entity in context.Categories)
                context.Categories.Remove(entity);
            context.SaveChanges();

            context.Database.Migrate();

            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new[]
            {
                new Category() {Name = "Aquaria", Slug = "aquaria"},
                new Category() {Name = "Bivalves", Slug = "bivalves"},
                new Category() {Name = "Crustaceans", Slug = "crustaceans"},
                new Category() {Name = "Echinoderms", Slug = "echinoderms"},
                new Category() {Name = "Fish", Slug = "fish"},
                new Category() {Name = "Molluscs", Slug = "molluscs"},
                new Category() {Name = "Corals", Slug = "corals"},
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            #region Tags

            var tags = new[]
            {
                new Tag()
                {
                    Title = "Requires plenty of space",
                    Description = "This species likes swimming and requires an aquarium with plenty of open space.",
                    Slug = "requires-plenty-space",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Initially shy",
                    Description = "This species can be shy when they're first introduced into an aquarium." +
                                  "This species should be acclimitized before introducing more aggressive species.",
                    Slug = "shy",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Requires hiding places",
                    Description =
                        "This species needs good hiding places. Provide plenty of life rock (and corals) for this species to hide in.",
                    Slug = "hiding-places",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Can be aggressive",
                    Description = "",
                    Slug = "can-be-aggressive",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Can coexist with its own species",
                    Description = "",
                    Slug = "coexist-with-own-species",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Aggressive towards similar species",
                    Description = "",
                    Slug = "aggressive-similar-species",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Can coexist as a pair",
                    Description = "This species can coexist as a pair when they're introduced simultaneously.",
                    Slug = "coexist-as-pair",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Number of fish",
                    Description = "This species can live with multiple of its own kind if plenty of space is provided.",
                    Slug = "number-of-fish",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Hides amongst stony corals",
                    Description = "",
                    Slug = "hides-amongst-stony-corals",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Hides amongst soft corals",
                    Description = "",
                    Slug = "hides-amongst-soft-corals",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Hermaphroditic",
                    Description = "This species can change gender, male to female.",
                    Slug = "hermaphroditic",
                    TagType = TagType.Information,
                },
                new Tag()
                {
                    Title = "Algae eaters",
                    Description = "The primary diet of this species should consist out of algae based foods.",
                    Slug = "algae-eaters",
                    TagType = TagType.Information,
                },
            };

            foreach (var tag in tags)
            {
                context.Tags.Add(tag);
            }
            var caution = new[]
                {
                new Tag()
                {
                    Title = "Can coexist as a shoal",
                    Description = "",
                    Slug = "coexist-as-school",
                    TagType = TagType.Caution,
                },
                new Tag()
                {
                    Title = "Frequent feeding",
                    Description =
                        "This species requires feeding several times per day. If the aquarium has sufficient natural food available it will require less feeding.",
                    Slug = "frequent-feeding",
                    TagType = TagType.Caution,
                },
                new Tag()
                {
                    Title = "Sensitive",
                    Description = "This species is sensitive for transport and acclimitizing into an aquarium.",
                    Slug = "sensitive-transport",
                    TagType = TagType.Caution,
                },
                new Tag()
                {
                    Title = "Deep sandy substrate",
                    Description =
                        "This species requires a deep sandy substrate with a minimum of 2 inches (5 cm) of sand. This species will dig itself in when afraid or requiring sleep.",
                    Slug = "deep-sandy-substrate",
                    TagType = TagType.Caution,
                },
                new Tag()
                {
                    Title = "Live food",
                    Description = "Greater chance of succes if the species is provided with live food.",
                    Slug = "live-food",
                    TagType = TagType.Caution,
                },
                new Tag()
                {
                    Title = "Requires aquarium with algae",
                    Description =
                        "This species should be kept in a well established aquarium where they can feed on algae from rocks and stones." +
                        "If there are insufficient algae available the diet can be supplemented with algae rich food.",
                    Slug = "algae-aquarium",
                    TagType = TagType.Caution,
                },
                new Tag()
                {
                    Title = "Acclimitize as a juvenile",
                    Description =
                        "This species will acclimitize beter to your aquarium if they are introduced when young.",
                    Slug = "acclimitize-juvenile",
                    TagType = TagType.Caution,
                },
            };

            foreach (var warning in caution)
            {
                context.Tags.Add(warning);
            }

            var warnings = new[]
                {
                new Tag()
                {
                    Title = "Jumps out of open aquarium",
                    Description = "This species can jump out of open aquariums. This can be caused by bullying tankmates, predators, bad water quality, too few hiding places or loud sounds nearby the aquarium.",
                    Slug = "jumps-out-of-aquarium",
                    TagType = TagType.Warning,
                },
                new Tag()
                {
                    Title = "Difficult to keep alive",
                    Description = "This species is difficult to keep alive due to special requirements.",
                    Slug = "difficult-to-keep-alive",
                    TagType = TagType.Warning,
                },
                new Tag()
                {
                    Title = "Threat towards crustaceans",
                    Description = "This species can sometimes be a threat to shrimps, crabs and other crustaceans, which are relatively small compared to the fish.",
                    Slug = "threat-towards-crustaceans",
                    TagType = TagType.Warning,
                },
                new Tag()
                {
                    Title = "Can nibble at clams",
                    Description = "This species sometimes nibbles at clams such as the Tridacna species.",
                    Slug = "nibbles-at-clams",
                    TagType = TagType.Warning,
                },
                new Tag()
                {
                    Title = "Insufficient information",
                    Description = "There is little information available about this species.",
                    Slug = "insufficient-information",
                    TagType = TagType.Warning,
                },
                new Tag()
                {
                    Title = "Eats worms, bivalves and crustaceans",
                    Description = "This species likes to eat worms, bivalves (e.g. clams/mussels) and small crustaceans.",
                    Slug = "eats-worm-bivalve-crustacean",
                    TagType = TagType.Warning,
                },
                new Tag()
                {
                    Title = "Aggressive",
                    Description = "This species can be very aggressive towards other fish." +
                                  "Be careful when keeping this species with more docile or peaceful fish." +
                                  "Plenty of hiding places, plenty of space and more frequent feeding can sometimes alleviate this aggressive behaviour by some degree.",
                    Slug = "insufficient-information",
                    TagType = TagType.Warning,
                },
                new Tag()
                {
                    Title = "High water quality",
                    Description = "This species required a high water quality. Frequent testing and water changes may be required.",
                    Slug = "water-quality-high",
                    TagType = TagType.Warning
                },
                new Tag()
                {
                    Title = "Territorial",
                    Description = "This species likes to have its own territory and is very aggressive towards most approaching fish.",
                    Slug = "territorial",
                    TagType = TagType.Caution,
                },
            };
            foreach (var warning in warnings)
            {
                context.Tags.Add(warning);
            }

            #endregion

            #region Subs

            var crustaceans = new[]
                {
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "crustaceans"),
                    Description = "",
                    CommonName = "Hermit crabs",
                    ScientificName = "Paguroidea",
                    Slug = "hermit-crabs"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "crustaceans"),
                    Description = "",
                    CommonName = "Spider crabs",
                    ScientificName = "Majoidea",
                    Slug = "spider-crabs"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "crustaceans"),
                    Description = "",
                    CommonName = "Shrimps",
                    ScientificName = "Caridea",
                    Slug = "shrimps"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "crustaceans"),
                    Description = "",
                    CommonName = "Mantis shrimp",
                    ScientificName = "Stomatopoda",
                    Slug = "mantis-shrimps"
                },
            };

            var echinoderms = new[]
            {
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "echinoderms"),
                    Description = "",
                    CommonName = "Sea cucumbers",
                    ScientificName = "Holothuroidea",
                    Slug = "sea-cucumbers"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "echinoderms"),
                    Description = "",
                    CommonName = "Sea stars",
                    ScientificName = "Asteroidea",
                    Slug = "sea-stars"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "echinoderms"),
                    Description = "",
                    CommonName = "Sea urchins",
                    ScientificName = "Echinoidea",
                    Slug = "sea-urchins"
                },
            };

            var fish = new[]
            {
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "fish"),
                    Description = "",
                    CommonName = "Clownfish/Damselfish",
                    ScientificName = "Pomacentridae",
                    Slug = "damselfish"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "fish"),
                    Description = "",
                    CommonName = "Cardinalfish",
                    ScientificName = "Apogonidae",
                    Slug = "cardinalfish"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "fish"),
                    Description = "",
                    CommonName = "Surgeonfish (Tang)",
                    ScientificName = "Acanthuridae",
                    Slug = "surgeonfish"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "fish"),
                    Description = "",
                    CommonName = "Butterflyfish",
                    ScientificName = "Chaetodontidae",
                    Slug = "butterflyfish"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "fish"),
                    Description = "",
                    CommonName = "Angelfish",
                    ScientificName = "Pomacanthidae",
                    Slug = "angelfish"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "fish"),
                    Description = "",
                    CommonName = "Goby",
                    ScientificName = "Gobiidae",
                    Slug = "gobies"
                },
            };

            var molluscs = new[]
            {
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "molluscs"),
                    Description = "",
                    CommonName = "Sea snails",
                    ScientificName = "Gastropoda",
                    Slug = "sea-snails"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "molluscs"),
                    Description = "",
                    CommonName = "Nudibranch",
                    ScientificName = "Nudibranchia",
                    Slug = "nudibranch"
                },
            };

            var corals = new[]
            {
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "corals"),
                    Description = "",
                    CommonName = "Soft Corals",
                    ScientificName = "Alcyonacea",
                    Slug = "soft-corals"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "corals"),
                    Description = "",
                    CommonName = "Stony Corals",
                    ScientificName = "Scleractinia",
                    Slug = "stony-corals"
                },
                new Subcategory()
                {
                    Category = categories.First(x => x.Slug == "corals"),
                    Description = "",
                    CommonName = "Sea anemones",
                    ScientificName = "Actiniaria ",
                    Slug = "anemones"
                },
            };

            foreach (var subcategory in crustaceans)
            {
                context.Subcategories.Add(subcategory);
            }
            foreach (var subcategory in echinoderms)
            {
                context.Subcategories.Add(subcategory);
            }
            foreach (var subcategory in fish)
            {
                context.Subcategories.Add(subcategory);
            }
            foreach (var subcategory in molluscs)
            {
                context.Subcategories.Add(subcategory);
            }
            foreach (var subcategory in corals)
            {
                context.Subcategories.Add(subcategory);
            }

            #endregion

            var creatures = new[]
           {
                new Creature()
                {
                    Genus = "Chrysiptera",
                    Species = "hemicyanea",
                    CommonName = "Azure Damselfish",
                    Description = "The Damselfish, also known as the Half-blue Damselfish, is a two-tone, darting marine fish. The front portion of the body is bright blue. The posterior portion, anal fin, and tail are yellow. There is a species variation in the amount of yellow on the body of the fish. (Some call C. parasema the Azure Damselfish, however, in the aquarium trade, the Azure Damselfish is considered to be this fish, C. hemicyanea.)" +
                                  "A 30 gallon aquarium or larger with plenty of rockwork and décor is ideal. Because it can tolerate substandard water parameters, it is a popular fish among beginning hobbyists. A small group of juvenile Azure Damsels will add color and drama to most marine aquariums. Maintain this species with other semi-aggressive fish, as they can become territorial as they mature. In larger reef aquariums, this is normally not a problem if plenty of hiding places are provided." +
                                  "The Azure Damselfish diet should consist of quality flake foods, frozen meaty foods such as brine or mysis shrimp and occasionally dried seaweed offered on a feeding clip.",
                    Origin = "Indo-Pacific",
                    SpecialRequirements = SpecialRequirements.None,
                    Length = 10.0,
                    ReefCompatability = ReefCompatability.Always,
                    Temperament = Temperament.SemiAgressive,
                    Volume = 125,
                    Difficulty = Difficulty.Beginner,
                    Diet = "Omnivore",
                    Subcategory = fish.First(x => x.Slug == "damselfish")
                },
                new Creature()
                {
                    Genus = "Chrysiptera",
                    Species = "cyanea",
                    CommonName = "Blue Damselfish",
                    Description = "The Blue Damselfish is probably the best selling marine fish in the United States. Beginning hobbyists relish its hardiness and small size, while advanced aquarists praise the color and activity this member of the Pomacentridae family brings to the aquarium. Female Blue Damselfish are completely blue. Males, on the other hand, have an orange tail and are commonly called the Orangetail Blue Damselfish or Blue Devil Damselfish." +
                                  "Native to reefs across the Indo-Pacific, Chrysiptera cyanea is usually busy defending a small territory. Interestingly, the Blue Damselfish has the ability to hide in a hole or crevice and darken to an almost black color. This usually happens when it is threatened. After the perceived threat is gone, the Blue Damselfish will return to its electric blue color in a matter of seconds." +
                                  "The Blue Damselfish is somewhat aggressive, so its housing should be large enough to easily accommodate multiple specimens. It is a good fish for beginners and makes an ideal companion fish for saltwater aquariums of over 30 gallons. The Blue Damselfish is also a great choice for reef aquariums with invertebrates. As the Blue Damselfish matures, it may demonstrate pronounced territorial behavior towards future additions to the aquarium. If keeping the Blue Damselfish with other damselfish, provide multiple hiding places to break up territories and decrease aggression." +
                                  "The diet of the Blue Damselfish should consist of flaked and frozen foods, and herbivore preparations.",
                    Origin = "Indonesia, Solomon Islands",
                    SpecialRequirements = SpecialRequirements.None,
                    Length = 5.0,
                    ReefCompatability = ReefCompatability.Always,
                    Temperament = Temperament.SemiAgressive,
                    Volume = 125,
                    Difficulty = Difficulty.Beginner,
                    Diet = "Omnivore",
                    Subcategory = fish.First(x => x.Slug == "damselfish")
                },
                new Creature()
                {
                    Genus = "Chrysiptera",
                    Species = "springeri",
                    CommonName = "Blue Sapphire Damselfish",
                    Description = "The Blue Sapphire Damselfish originates within the Solomon Islands, and is a brilliant blue coloration with black outlined fins. This species can quickly turn completely black when stressed which allows them to evade predators. Like many of the other damselfish within the Chrysiptera genus, it can become aggressive towards slower moving tank mates. Be sure the aquarium has plenty of live rock for territories and hiding." +
                                  "The Blue Sapphire Damselfish is hardy and is a good fish for beginners. They also make an ideal companion fish for a saltwater aquarium of over 30 gallons, and are safe with corals and invertebrates. As the fish matures it may become aggressive, causing problems with the selection of other species of fish added to the aquarium. If keeping with other damselfish, provide plenty of live rock with multiple hiding places to break up territories and decrease aggression." +
                                  "The Blue Sapphire Damselfish\'s diet should consist of quality flake foods, frozen meaty foods such as brine or mysis shrimp and occasionally dried seaweed offered on a feeding clip.",
                    Origin = "Solomon Islands",
                    SpecialRequirements = SpecialRequirements.None,
                    Length = 9,
                    ReefCompatability = ReefCompatability.Always,
                    Temperament = Temperament.Peaceful,
                    Volume = 125,
                    Difficulty = Difficulty.Beginner,
                    Diet = "Carnivore",
                    Subcategory = fish.First(x => x.Slug == "damselfish")
                },
                new Creature()
                {
                    Genus = "Chrysiptera",
                    Species = "springeri",
                    CommonName = "Fiji Blue Devil Damselfish",
                    Description = "Fiji Blue Devil Damselfish, also known as the South Seas Devil Damselfish or Village Belle, is blue with a yellow belly. " +
                                  "It is considered aggressive and should not be mixed with its own species or passive fish. It does better with larger fish in aquariums 30 gallons or larger." +
                                  " The South Seas Devil Damselfish feeds on a variety of meaty items, herbivore preparations, and flaked foods.",
                    Origin = "Solomon Islands",
                    SpecialRequirements = SpecialRequirements.None,
                    Length = 7.5,
                    ReefCompatability = ReefCompatability.Always,
                    Temperament = Temperament.Peaceful,
                    Volume = 125,
                    Difficulty = Difficulty.Beginner,
                    Diet = "Carnivore",
                    Subcategory = fish.First(x => x.Slug == "damselfish")
                },
            };

            var a = new Creature()
            {
                Genus = "Chrysiptera",
                Species = "parasema",
                CommonName = "Yellowtail Damselfish",
                Description =
                    "The Yellowtail Damselfish is extremely hardy and gorgeously colored. In fact, Chrysiptera parasema is considered by many aquarists, both beginning and advanced, to be the ultimate damselfish. This is partly because its jewel-blue body is contrasted by an energizing yellow tail. This color combination looks stunning against any backdrop of corals and live rock. But what pleases aquarists most is that the Yellowtail Damsel is less aggressive and does not need as large of an aquarium as other Damsels." +
                    "Native to the reefs of the Indo-Pacific, this member of the Pomacentridae family prefers multiple hiding places and peaceful tankmates. Though most Yellowtail Damselfish will ignore other fish, invertebrates, or corals, some may be territorial towards its own kind or similar-sized fish. The Yellowtail Damsel is best kept in small groups of odd numbered fish in suitably sized systems." +
                    "Also known as the Yellowtail Blue Damselfish or Yellowtail Demoiselle, and sometimes confused with the Azure Damselfish, C. parasema feeds on zooplankton and algae in the aquarium. For best care, it should also be fed a varied diet of meaty foods, such as mysis and vitamin-enriched shrimp. It is best to feed several small meals throughout the day.",
                Origin = "Indo-Pacific",
                SpecialRequirements = SpecialRequirements.None,
                Length = 7.5,
                ReefCompatability = ReefCompatability.Always,
                Temperament = Temperament.SemiAgressive,
                Volume = 125,
                Difficulty = Difficulty.Beginner,
                Diet = "Omnivore",
                Subcategory = fish.First(x => x.Slug == "damselfish"),
            };

            context.Creatures.Add(a);

            foreach (var inhabitant in creatures)
            {
                context.Creatures.Add(inhabitant);
            }
            context.SaveChanges();
        }
    }
}
