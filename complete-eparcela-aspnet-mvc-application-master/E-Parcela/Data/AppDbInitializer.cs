using E_Parcela.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace E_Parcela.Data
{
    public class AppDbInitializer
    {
        public static void Seed (IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();


                context.Database.EnsureCreated();

                //Suradnici
                if(!context.Suradnici.Any())
                {
                    context.Suradnici.AddRange(new List<Suradnici>()
                    {
                        new Suradnici()
                        {
                            Name = "Suradnik 1",
                            Logo = "https://i.pinimg.com/474x/e1/22/7c/e1227ce7840704a60fc4da9e6a35f5b3--brand-logo-design-design-logos.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Suradnici()
                        {
                            Name = "Suradnik 2",
                            Logo = "https://i.pinimg.com/550x/35/86/ef/3586ef60199e9d0574b04c0af13c99af.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Suradnici()
                        {
                            Name = "Suradnik 3",
                            Logo = "https://5.imimg.com/data5/ANDROID/Default/2021/3/UB/MU/FT/12539658/product-jpeg-250x250.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Suradnici()
                        {
                            Name = "Suradnik 4",
                            Logo = "https://5.imimg.com/data5/SELLER/Default/2023/1/DN/SS/RQ/1485072/grocery-billing-software-250x250.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        
                    });
                    context.SaveChanges();
                }
                //Sadnice
                if (!context.Sadnice.Any())
                {
                    context.Sadnice.AddRange(new List<Sadnice>()
                    {
                        new Sadnice()
                        {
                            FUllName = "Sadnice 1",
                            ProfilePictureURL = "https://i.pinimg.com/474x/e1/22/7c/e1227ce7840704a60fc4da9e6a35f5b3--brand-logo-design-design-logos.jpg",
                            Bio = "This is the description of the first cinema",
                            Price = 20
                        },
                        new Sadnice()
                        {
                            FUllName = "Sadnice 2",
                            ProfilePictureURL = "https://i.pinimg.com/550x/35/86/ef/3586ef60199e9d0574b04c0af13c99af.jpg",
                            Bio = "This is the description of the first cinema",
                            Price = 20
                        },
                        new Sadnice()
                        {
                            FUllName = "Sadnice 3",
                            ProfilePictureURL = "https://5.imimg.com/data5/ANDROID/Default/2021/3/UB/MU/FT/12539658/product-jpeg-250x250.jpg",
                            Bio = "This is the description of the first cinema",
                            Price = 20
                        },
                        new Sadnice()
                        {
                            FUllName = "Sadnice 4",
                            ProfilePictureURL = "https://5.imimg.com/data5/SELLER/Default/2023/1/DN/SS/RQ/1485072/grocery-billing-software-250x250.jpg",
                            Bio = "This is the description of the first cinema",
                            Price = 20
                        },

                    }); ;
                    context.SaveChanges();
                }
                //Zaposlenici
                if (!context.Zaposlenici.Any())
                {
                    context.Zaposlenici.AddRange(new List<Zaposlenici>()
                    {
                        new Zaposlenici()
                        {
                            FullName = "Zaposlenici 1",
                            ProfilePictureURL = "https://i.pinimg.com/474x/e1/22/7c/e1227ce7840704a60fc4da9e6a35f5b3--brand-logo-design-design-logos.jpg",
                            Bio = "This is the description of the first cinema"
                        },
                        new Zaposlenici()
                        {
                            FullName = "Zaposlenici 2",
                            ProfilePictureURL = "https://i.pinimg.com/550x/35/86/ef/3586ef60199e9d0574b04c0af13c99af.jpg",
                            Bio = "This is the description of the first cinema"
                        },
                        new Zaposlenici()
                        {
                            FullName = "Zaposlenici 3",
                            ProfilePictureURL = "https://5.imimg.com/data5/ANDROID/Default/2021/3/UB/MU/FT/12539658/product-jpeg-250x250.jpg",
                            Bio = "This is the description of the first cinema"
                        },
                        new Zaposlenici()
                        {
                            FullName = "Zaposlenici 4",
                            ProfilePictureURL = "https://5.imimg.com/data5/SELLER/Default/2023/1/DN/SS/RQ/1485072/grocery-billing-software-250x250.jpg",
                            Bio = "This is the description of the first cinema"
                            
                        },

                    }); ;
                    context.SaveChanges();
                }
                //Parcele
                if (!context.Parcele.Any())
                {
                    context.Parcele.AddRange(new List<Parcele>()
                    {
                        new Parcele()
                        {
                          Name = "Parcela 1",
                          Description = "Jabuke",
                          ImageURL = "https://5.imimg.com/data5/UM/DM/MY-43685925/organic-apple-250x250.jpg",
                          StartDate = "1.1.2023",
                          EndDate = "1.1.2025",
                          SuradniciID = 1,
                          ZaposleniciID = 2,
                          ParcelaCategory = Enums.ParcelaCategory.Voce
                        },
                        new Parcele()
                        {
                          Name = "Parcela 2",
                          Description = "Jabuke",
                          ImageURL = "https://5.imimg.com/data5/UM/DM/MY-43685925/organic-apple-250x250.jpg",
                          StartDate = "1.1.2023",
                          EndDate = "1.1.2025",
                          SuradniciID = 1,
                          ZaposleniciID = 2,
                          ParcelaCategory = Enums.ParcelaCategory.Voce
                        },
                        new Parcele()
                        {
                          Name = "Parcela 3",
                          Description = "Jabuke",
                          ImageURL = "https://5.imimg.com/data5/UM/DM/MY-43685925/organic-apple-250x250.jpg",
                          StartDate = "1.1.2023",
                          EndDate = "1.1.2025",
                          SuradniciID = 1,
                          ZaposleniciID = 2,
                          ParcelaCategory = Enums.ParcelaCategory.Voce
                        },
                        new Parcele()
                        {
                          Name = "Parcela 4",
                          Description = "Jabuke",
                          ImageURL = "https://5.imimg.com/data5/UM/DM/MY-43685925/organic-apple-250x250.jpg",
                          StartDate = "1.1.2023",
                          EndDate = "1.1.2025",
                          SuradniciID = 1,
                          ZaposleniciID = 2,
                          ParcelaCategory = Enums.ParcelaCategory.Voce

                        },

                    });
                    context.SaveChanges();
                }
                //Sadnice i Parcele
                if (!context.Sadnice_Parcele.Any())
                {
                    context.Sadnice_Parcele.AddRange(new List<Sadnice_Parcele>()
                    {
                    new Sadnice_Parcele()
                    {
                        SadniceID = 1,
                        ParceleID = 1
                    },

                    new Sadnice_Parcele()
                    {
                        SadniceID = 2,
                        ParceleID = 2
                    },

                    new Sadnice_Parcele()
                    {
                        SadniceID = 3,
                        ParceleID = 3
                    },

                    new Sadnice_Parcele()
                    {
                        SadniceID = 4,
                        ParceleID = 4
                    },

                    });
                }
            }
        }
    }
}
