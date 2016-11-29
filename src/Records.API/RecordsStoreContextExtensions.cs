using Records.API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Records.API
{
    public static class RecordsStoreContextExtensions
    {
        public static void EnsureSeedDataForContext(this RecordsStoreContext context)
        {
            if (context.Bands.Any())
            {
                return;
            }

            var bands = new List<Band>()
            {
                new Band {
                    Name = "Iron Mask",
                    Records = new List<Record>() {
                        new Record {
                            Title = "Diabolica",
                            ReleaseYear = 2016,
                            Price = 20
                        },
                        new Record {
                            Title = "Black As Death",
                            ReleaseYear = 2012,
                            Price = 20
                        }
                    }
                },
                new Band {
                    Name = "Primal Fear",
                    Records = new List<Record>() {
                        new Record {
                            Title = "Diabolica",
                            ReleaseYear = 2016,
                            Price = 20
                        },
                        new Record {
                            Title = "Black As Death",
                            ReleaseYear = 2012,
                            Price = 20
                        }
                    }
                },
                new Band {
                    Name = "Rhapsody",
                    Records = new List<Record>() {
                        new Record {
                            Title = "Legendary Tales",
                            ReleaseYear = 1997,
                            Price = 20
                        },
                        new Record {
                            Title = "Power Of The Dragon Flame",
                            ReleaseYear = 2002,
                            Price = 20
                        }
                    }
                },
                new Band {
                    Name = "HammerFall",
                    Records = new List<Record>() {
                        new Record {
                            Title = "Renegade",
                            ReleaseYear = 2001,
                            Price = 20
                        },
                        new Record {
                            Title = "Legacy Of Kings",
                            ReleaseYear = 1998,
                            Price = 20
                        }
                    }
                },
                new Band {
                    Name = "Megadeth",
                    Records = new List<Record>() {
                        new Record {
                            Title = "Dystopia",
                            ReleaseYear = 2016,
                            Price = 20
                        },
                        new Record {
                            Title = "Rust In Peace",
                            ReleaseYear = 1990,
                            Price = 20
                        }
                    }
                }
            };

            context.Bands.AddRange(bands);
            context.SaveChanges();
        }
    }
}
