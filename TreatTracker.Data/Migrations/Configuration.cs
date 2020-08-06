namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TreatTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Factories.AddOrUpdate(x => x.FactoryId,
                   new Factory() { FactoryId = 1, LocationName = "Willy Wonka's Chocolate Factory", Address = "1445 W. Norwood Avenue, Itasca,Illinois 60143", PhoneNumber = "(945) 599-6652", Manager = "Willy Wonka" },
                   new Factory() { FactoryId = 2, LocationName = "Charlie's Chocolate Factory", Address = "9999 N. Bucket Shack, Munich,Germany 80331", PhoneNumber = "(246) 265-2831", Manager = "Charlie Bucket" },
                   new Factory() { FactoryId = 3, LocationName = "Slugworth's Chocolate Factory", Address = "911911 S. Gobstopper Way, WonkaVille, California, 90231", PhoneNumber = "(426) 845-5426", Manager = "Arthur Slugworth" }
               );

            context.Stores.AddOrUpdate(x => x.StoreId,
                new Store() { StoreId = 1, LocationName = "Walmart SuperCenter", Address = "4650 S. Emerson Avenue, Indianapolis, Indiana 46203", PhoneNumber = "(317) 783-0950" },
                new Store() { StoreId = 2, LocationName = "Rocket Fizz", Address = "55 Monument Circle #52, Indianapolis, Indiana 46204", PhoneNumber = "(317) 822-3499" },
                new Store() { StoreId = 3, LocationName = "Augustus’s Famous Chocolates", Address = "1011 Truffle Lane, Dusselheim, Germany 81314", PhoneNumber = "(890) 765-4936" },
                new Store() { StoreId = 4, LocationName = "Russell Sperka’s Extremely Sour Candies", Address = "545 Dunder Lane, Zionsville, Indiana 46077", PhoneNumber = "(317) 599-5944" },
                new Store() { StoreId = 5, LocationName = "Albanese Candy", Address = "5441 East Lincoln Hwy, Merrillville, Indiana 46410", PhoneNumber = "(855) 272-3227" }
            );

            context.Rooms.AddOrUpdate(x => x.RoomId,
                new Room() { RoomId = 1, Theme = "Chocolate Room", Description = "The home of the one and only Chocolate Waterfall. No other factor in the world has a chocolate waterfall quite like ours. The waterfall mixes the chocolate so it's light and frothy.", FactoryId = 1 },
                new Room() { RoomId = 2, Theme = "Fizzy Lifting Room", Description = "The most recent addition to our sellable treats is the fizzy lifting sodas. They allow for you to soar high up in the sky with a simple drink and then a slow fall with each burp. This room contains testing for these drinks, beware of bubbles.", FactoryId = 1 },
                new Room() { RoomId = 3, Theme = "Inventing Room", Description = "Willy Wonka's favorite and most secret room that holds all of his newest inventions and candy that still needs testing like the Everlasting Gobstoppers and Three Course Dinner Chewing Gum", FactoryId = 1 },
                new Room() { RoomId = 4, Theme = "Wonka Vision Room", Description = "The WonkaVision room is a room within Willy Wonka’s in which items sizes can be manipulated, small things made big, and big things made small.", FactoryId = 1 },
                new Room() { RoomId = 5, Theme = "Juicing Room", Description = "The room that contains our special ingredients that are in need of juicing in order to deliver a special sauce for our treats. Beware... We once juiced a human...", FactoryId = 1 },
                new Room() { RoomId = 6, Theme = "Egg Room", Description = "The Egg room is where Willy Wonka’s geese lay golden eggs which fall on an indicator to determine whether the egg is a good egg or a bad egg.", FactoryId = 1 },
                new Room() { RoomId = 7, Theme = "Cotton Candy Sheep Room", Description = "All of our sheep grow the finest cotton candy on this side of the world, no other place has sheep that grow this amazing Wool that is absolutely scrumptious", FactoryId = 1 },
                new Room() { RoomId = 8, Theme = "Exploding Candy Room", Description = "The fun room for Oompa Loompas, where we get to fire different exploding candies and many different moving targets.", FactoryId = 1 }
            );

            context.Characters.AddOrUpdate(x => x.CharacterId,
                new Character() { CharacterId = 1, Name = "Grandpa Joe", DateOfBirth = new DateTime(1867, 01, 07), RoomId = 2, Weakness = "Mobility" },
                new Character() { CharacterId = 2, Name = "Mike Teavee", DateOfBirth = new DateTime(2009, 12, 20), RoomId = 4, Weakness = "Television" },
                new Character() { CharacterId = 3, Name = "Veruca Salt", DateOfBirth = new DateTime(2007, 02, 14), RoomId = 6, Weakness = "Greed" },
                new Character() { CharacterId = 4, Name = "Violet Beauregarde", DateOfBirth = new DateTime(2008, 05, 15), RoomId = 5, Weakness = "Gum and Pride" },
                new Character() { CharacterId = 5, Name = "Augustus Gloop", DateOfBirth = new DateTime(2006, 11, 23), RoomId = 1, Weakness = "Gluttony" }
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
