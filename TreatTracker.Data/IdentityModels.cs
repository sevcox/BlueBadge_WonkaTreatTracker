using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;

namespace TreatTracker.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class TreatTrackerDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var factories = new List<Factory>
                {
                    new Factory {LocationName = "Willy Wonka's Chocolate Factory", Address = "1445 W. Norwood Avenue, Itasca,Illinois 60143", PhoneNumber = "(945) 599-6652", Manager = "Willy Wonka"},
                    new Factory {LocationName = "Charlie's Chocolate Factory",Address = "9999 N. Bucket Shack, Munich,Germany 80331",PhoneNumber = "(246) 265-2831",Manager = "Charlie Bucket"},
                    new Factory{LocationName = "Slugworth's Chocolate Factory",Address = "911911 S. Gobstopper Way, WonkaVille, California, 90231",PhoneNumber = "(426) 845-5426",Manager = "Arthur Slugworth"}
                };
            factories.ForEach(f => context.Factories.Add(f));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store{LocationName ="Walmart SuperCenter", Address = "4650 S. Emerson Avenue, Indianapolis, Indiana 46203", PhoneNumber = "(317) 783-0950"},
                new Store{LocationName ="Rocket Fizz", Address = "55 Monument Circle #52, Indianapolis, Indiana 46204", PhoneNumber = "(317) 822-3499"},
                new Store{LocationName ="Augustus’s Famous Chocolates", Address = "1011 Truffle Lane, Dusselheim, Germany 81314", PhoneNumber="(890) 765-4936"},
                new Store{LocationName ="Russell Sperka’s Extremely Sour Candies", Address = "545 Dunder Lane, Zionsville, Indiana 46077", PhoneNumber="(317) 599-5944"},
                new Store{LocationName ="Albanese Candy", Address = "5441 East Lincoln Hwy, Merrillville, Indiana 46410", PhoneNumber="(855) 272-3227"}
            };
            stores.ForEach(s => context.Stores.Add(s));
            context.SaveChanges();

            var rooms = new List<Room>
            {
                new Room{Theme ="Chocolate Room",Description ="The home of the one and only Chocolate Waterfall. No other factor in the world has a chocolate waterfall quite like ours. The waterfall mixes the chocolate so it's light and frothy.",FactoryId = 1},
                new Room{Theme ="Fizzy Lifting Room",Description ="The most recent addition to our sellable treats is the fizzy lifting sodas. They allow for you to soar high up in the sky with a simple drink and then a slow fall with each burp. This room contains testing for these drinks, beware of bubbles.",FactoryId = 1},
                new Room{Theme ="Inventing Room",Description = "Willy Wonka's favorite and most secret room that holds all of his newest inventions and candy that still needs testing like the Everlasting Gobstoppers and Three Course Dinner Chewing Gum",FactoryId = 1},
                new Room{Theme ="Wonka Vision Room",Description = "The WonkaVision room is a room within Willy Wonka’s in which items sizes can be manipulated, small things made big, and big things made small.",FactoryId = 1},
                new Room{Theme ="Juicing Room",Description = "The room that contains our special ingredients that are in need of juicing in order to deliver a special sauce for our treats. Beware... We once juiced a human...",FactoryId = 1},
                new Room{Theme ="Egg Room",Description = "The Egg room is where Willy Wonka’s geese lay golden eggs which fall on an indicator to determine whether the egg is a good egg or a bad egg.",FactoryId = 1},
                new Room{Theme ="Cotton Candy Sheep Room",Description = "All of our sheep grow the finest cotton candy on this side of the world, no other place has sheep that grow this amazing Wool that is absolutely scrumptious",FactoryId = 1},
                new Room{Theme ="Exploding Candy Room",Description = "The fun room for Oompa Loompas, where we get to fire different exploding candies and many different moving targets.",FactoryId = 1}
            };
            rooms.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();

            var characters = new List<Character>
            {
                new Character{Name = "Grandpa Joe", DateOfBirth = new DateTime(1867,01,07) , RoomId = 2, Weakness = "Mobility"},
                new Character{Name = "Mike Teavee", DateOfBirth = new DateTime(2009, 12, 20) , RoomId = 4, Weakness = "Television"},
                new Character{Name = "Veruca Salt", DateOfBirth = new DateTime(2007, 02, 14) , RoomId = 6, Weakness = "Greed"},
                new Character{Name = "Violet Beauregarde", DateOfBirth = new DateTime(2008, 05, 15), RoomId = 5, Weakness = "Gum and Pride"},
                new Character{Name = "Augustus Gloop", DateOfBirth = new DateTime(2006, 11, 23), RoomId = 1, Weakness = "Gluttony"}
            };
            characters.ForEach(c => context.Characters.Add(c));
            context.SaveChanges();
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new TreatTrackerDBInitializer());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Candy> Candies { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<GoldenTicket> Tickets { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Character> Characters { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
            .Conventions
            .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }

    }
}