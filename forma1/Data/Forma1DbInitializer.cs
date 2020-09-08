using forma1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forma1.Data
{
    public class Forma1DbInitializer
    {
        // Fills the db on given context with some example teams and an admin user
        public static void Initialize(Forma1DbContext context)
        {
            context.Database.EnsureCreated();

            // If there are no teams, we create some
            if (!context.Teams.Any())
            {
                var teams = new Team[]
                {
                new Team{Name="McLaren",YearFounded=1963,WorldChampionshipsWon=12,PaidEntryFee=true},
                new Team{Name="Scuderia Ferrari",YearFounded=1929,WorldChampionshipsWon=238,PaidEntryFee=false}
                };
                foreach (Team t in teams)
                {
                    context.Teams.Add(t);
                }
            }

            // If there is no user, we create one
            if (!context.Users.Any())
            {
                User user = new User();
                user.UserName = "admin";
                user.NormalizedUserName = "ADMIN";
                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, "f1test2018");
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
