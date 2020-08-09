using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data
{
    public class TuinDbInitializer
    {
        private readonly TuinDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public TuinDbInitializer(TuinDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
        }

        public async Task InitializeData()
        {
            Console.WriteLine("Removing existing gardens.");
            _dbContext.Database.EnsureDeleted();
            Console.WriteLine("Making final touches to the gardens.");
            if(_dbContext.Database.EnsureCreated())
            {
                Console.WriteLine("Admiring the finished gardens after a long hot day of digging soil.");
                Console.WriteLine();
                Console.WriteLine("Searching for gardeners.");
                Gebruiker gebruiker = new Gebruiker { Email = "tuinmaster@hogent.be", FirstName = "Glenn", LastName = "Beeckman" };
                _dbContext.Add(gebruiker);

                await CreateGebruiker(gebruiker.Email, "P@ssword1234");
                Console.WriteLine("Found one");
                Console.WriteLine();
                Console.WriteLine("User: tuinmaster@hogent.be");
                Console.WriteLine("Password: P@ssword1234");

                Gebruiker student = new Gebruiker { Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
                _dbContext.Add(student);

                student.AddFavoriteTuin(_dbContext.Tuinen.First());

                await CreateGebruiker(student.Email, "P@ssword1234");
                Console.WriteLine();
                Console.WriteLine("Found another");
                Console.WriteLine("User: student@hogent.be");
                Console.WriteLine("Password: P@ssword1234");
                Console.WriteLine();
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateGebruiker(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
