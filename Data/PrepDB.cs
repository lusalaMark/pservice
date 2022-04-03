using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data");

                context.Platforms.AddRange(
                    new models.Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new models.Platform() { Name = "Sql Server", Publisher = "Microsoft", Cost = "Free" },
                    new models.Platform() { Name = "Kubernetes", Publisher = "Cloud Native Compture Foundation", Cost = "Free" },
                    new models.Platform() { Name = "Windows", Publisher = "Microsoft", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have Data ");
            }

        }
    }
}