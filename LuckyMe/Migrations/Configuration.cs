using System.Collections.ObjectModel;
using LuckyMe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LuckyMe.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LuckyMe.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LuckyMe.Models.ApplicationDbContext context)
        {

            var sorteio = new Category {Name = "Sorteio"};
            var raspadinha = new Category {Name = "Raspadinha"};

            context.Categories.AddOrUpdate(p => p.Name,
                sorteio,
                raspadinha);

            context.Games.AddOrUpdate(p => p.Name,
                new Game { Name = "Euromilh�es", IsActive = true, BasePrice = 2, Category = sorteio },
                new Game { Name = "Totoloto", IsActive = true, BasePrice = .9m, Category = sorteio },
                new Game { Name = "Totobola", IsActive = true, BasePrice = .4m, Category = sorteio },
                new Game { Name = "Super P� de Meia", IsActive = true, BasePrice = 5, ImageUrl = "https://www.jogossantacasa.pt/Game/images/raspadinha/Imagem_286.png", Category = raspadinha },
                new Game { Name = "P� de Meia", IsActive = true, BasePrice = 3, Category = raspadinha },
                new Game { Name = "Mini P� de Meia", IsActive = true, BasePrice = 1, Category = raspadinha },
                new Game { Name = "F�rias", IsActive = true, BasePrice = 1, Category = raspadinha },
                new Game { Name = "Grande Sorte", IsActive = true, BasePrice = 2, ImageUrl = "https://www.jogossantacasa.pt/Game/images/raspadinha/Imagem_341.png", Category = raspadinha },
                new Game { Name = "Zod�aco da Sorte", IsActive = true, BasePrice = 2, ImageUrl = "https://www.jogossantacasa.pt/Content/images/uploadedImages/content/pjmc/gc/cont/11123/Raspadinha237.jpg", Category = raspadinha },
                new Game { Name = "20x", IsActive = true, BasePrice = 2, ImageUrl = "https://www.jogossantacasa.pt/Content/images/uploadedImages/content/pjmc/gc/cont/8388/Raspadinha216.jpg", Category = raspadinha },
                new Game { Name = "50x", IsActive = true, BasePrice = 5, ImageUrl = "https://www.jogossantacasa.pt/Content/images/uploadedImages/content/pjmc/gc/cont/11386/Raspadinha234.jpg", Category = raspadinha },
                new Game { Name = "100x", IsActive = true, BasePrice = 10, ImageUrl = "https://www.jogossantacasa.pt/Content/images/uploadedImages/content/pjmc/gc/cont/12369/Raspadinha242.jpg", Category = raspadinha }
                );

            if (!(context.Roles.Any(u => u.Name == "Admin")))
            {
                var roleStore = new RoleStore<CustomRole, Guid, CustomUserRole>(context);
                var roleManager = new RoleManager<CustomRole, Guid>(roleStore);
                roleManager.Create(new CustomRole("Admin"));
            }

            if (!(context.Users.Any(u => u.UserName == "joao@kspace.pt")))
            {
                var userStore = new CustomUserStore(context);
                var userManager = new ApplicationUserManager(userStore);
                var userToInsert = new ApplicationUser { UserName = "joao@kspace.pt", Email = "joao@kspace.pt" };
                var result = userManager.CreateAsync(userToInsert, "Password@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Admin");
                }
            }
        }
    }
}
