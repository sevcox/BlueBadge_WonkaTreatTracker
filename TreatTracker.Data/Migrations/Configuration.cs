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
                   new Factory() { LocationName = "Willy Wonka's Chocolate Factory", Address = "1445 W. Norwood Avenue, Itasca,Illinois 60143", PhoneNumber = "(945) 599-6652", Manager = "Willy Wonka" },
                   new Factory() { LocationName = "Charlie's Chocolate Factory", Address = "9999 N. Bucket Shack, Munich,Germany 80331", PhoneNumber = "(246) 265-2831", Manager = "Charlie Bucket" },
                   new Factory() { LocationName = "Slugworth's Chocolate Factory", Address = "911911 S. Gobstopper Way, WonkaVille, California, 90231", PhoneNumber = "(426) 845-5426", Manager = "Arthur Slugworth" }
               );
            context.SaveChanges();

            context.Stores.AddOrUpdate(x => x.StoreId,
                new Store() { LocationName = "Walmart SuperCenter", Address = "4650 S. Emerson Avenue, Indianapolis, Indiana 46203", PhoneNumber = "(317) 783-0950" },
                new Store() { LocationName = "Rocket Fizz", Address = "55 Monument Circle #52, Indianapolis, Indiana 46204", PhoneNumber = "(317) 822-3499" },
                new Store() { LocationName = "Augustus’s Famous Chocolates", Address = "1011 Truffle Lane, Dusselheim, Germany 81314", PhoneNumber = "(890) 765-4936" },
                new Store() { LocationName = "Russell Sperka’s Extremely Sour Candies", Address = "545 Dunder Lane, Zionsville, Indiana 46077", PhoneNumber = "(317) 599-5944" },
                new Store() { LocationName = "Albanese Candy", Address = "5441 East Lincoln Hwy, Merrillville, Indiana 46410", PhoneNumber = "(855) 272-3227" }
            );
            context.SaveChanges();

            context.Rooms.AddOrUpdate(x => x.RoomId,
                new Room() { Theme = "Chocolate Room", Description = "The home of the one and only Chocolate Waterfall. No other factor in the world has a chocolate waterfall quite like ours. The waterfall mixes the chocolate so it's light and frothy.", FactoryId = 1 },
                new Room() { Theme = "Fizzy Lifting Room", Description = "The most recent addition to our sellable treats is the fizzy lifting sodas. They allow for you to soar high up in the sky with a simple drink and then a slow fall with each burp. This room contains testing for these drinks, beware of bubbles.", FactoryId = 1 },
                new Room() { Theme = "Inventing Room", Description = "Willy Wonka's favorite and most secret room that holds all of his newest inventions and candy that still needs testing like the Everlasting Gobstoppers and Three Course Dinner Chewing Gum", FactoryId = 1 },
                new Room() { Theme = "Wonka Vision Room", Description = "The WonkaVision room is a room within Willy Wonka’s in which items sizes can be manipulated, small things made big, and big things made small.", FactoryId = 1 },
                new Room() { Theme = "Juicing Room", Description = "The room that contains our special ingredients that are in need of juicing in order to deliver a special sauce for our treats. Beware... We once juiced a human...", FactoryId = 1 },
                new Room() { Theme = "Egg Room", Description = "The Egg room is where Willy Wonka’s geese lay golden eggs which fall on an indicator to determine whether the egg is a good egg or a bad egg.", FactoryId = 1 },
                new Room() { Theme = "Cotton Candy Sheep Room", Description = "All of our sheep grow the finest cotton candy on this side of the world, no other place has sheep that grow this amazing Wool that is absolutely scrumptious", FactoryId = 1 },
                new Room() { Theme = "Exploding Candy Room", Description = "The fun room for Oompa Loompas, where we get to fire different exploding candies and many different moving targets.", FactoryId = 1 }
            );
            context.SaveChanges();

            context.Characters.AddOrUpdate(x => x.CharacterId,
                new Character() { Name = "Grandpa Joe", DateOfBirth = new DateTime(1867, 01, 07), RoomId = 2, Weakness = "Mobility" },
                new Character() { Name = "Mike Teavee", DateOfBirth = new DateTime(2009, 12, 20), RoomId = 4, Weakness = "Television" },
                new Character() { Name = "Veruca Salt", DateOfBirth = new DateTime(2007, 02, 14), RoomId = 6, Weakness = "Greed" },
                new Character() { Name = "Violet Beauregarde", DateOfBirth = new DateTime(2008, 05, 15), RoomId = 5, Weakness = "Gum and Pride" },
                new Character() { Name = "Augustus Gloop", DateOfBirth = new DateTime(2006, 11, 23), RoomId = 1, Weakness = "Gluttony" }
            );
            context.SaveChanges();

            context.Candies.AddOrUpdate(x => x.CandyId,
                new Candy() { CandyType = TypeOfCandy.Chocolate, FactoryId = 1, TreatName = "Banana Split Bar", Description = "Chocolate Bar filled with banana split toppings", SecretIngredient = "Bananas and Strawberries", Price = 1.25m, Quantity = 450, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Chocolate, FactoryId = 1, TreatName = "Scrumdiddlyumptious Bar", Description = "Chocolate bar filled with cookie, toffee, and nuts", SecretIngredient = "Crispy cookie pieces", Price = 1.50m, Quantity = 450, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Chocolate, FactoryId = 1, TreatName = "WonkaBar", Description = "Rich dark chocolate bar", SecretIngredient = "75% Cocao", Price = 1.25m, Quantity = 680, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Chocolate, FactoryId = 1, TreatName = "WonkaBar", Description = "Rich dark chocolate bar", SecretIngredient = "75% Cocao", Price = 1.25m, Quantity = 1, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Chocolate, FactoryId = 3, TreatName = "Scrumdiddlyumptious Bar", Description = "Chocolate Bar filled with cookie, toffee, and nuts", SecretIngredient = "Crispy Cookie Pieces", Price = 1.50m, Quantity = 1, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Chocolate, FactoryId = 3, TreatName = "Banana Split Bar", Description = "Chocolate Bar that tastes like your favorite dessert", SecretIngredient = "Bananas and Strawberries", Price = 1.25m, Quantity = 1, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Hard, FactoryId = 2, TreatName = "Nerds", Description = "Candy for Coders", SecretIngredient = "Creative Knowledge", Price = 0.75m, Quantity = 750, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Hard, FactoryId = 1, TreatName = "Fun Dip", Description = "Delicious candy flavored powder that is a little bit sweet", SecretIngredient = "Sugar sticks", Price = 1.25m, Quantity = 200, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Hard, FactoryId = 2, TreatName = "Bottle Caps", Description = "Candy with some fizz", SecretIngredient = "Carbonated Powder", Price = 2.50m, Quantity = 470, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Candy() { CandyType = TypeOfCandy.Hard, FactoryId = 3, TreatName = "ShockTarts", Description = "So sour they can make your tongue bleed", SecretIngredient = "Citric acid", Price = 2.50m, Quantity = 780, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" }
            );
            context.SaveChanges();

            context.Drinks.AddOrUpdate(x => x.DrinkId,
                new Drink() { Flavor = "Lemonade", FactoryId = 1, TreatName = "Fizzy Lifting Lemonade", Description = "Lemonade that will send you over the moon", SecretIngredient = "Fresh Squeezed Lemons", Price = 2.25m, Quantity = 350, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Blue Raspberry", FactoryId = 2, TreatName = "Fizzy Lifting BlueRazz", Description = "Refreshing Raspberry drink", SecretIngredient = "Blue Raspberries picked from Oompa Mountain", Price = 2.25m, Quantity = 450, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Root Beer", FactoryId = 1, TreatName = "Fizzy Root Beer", Description = "Root beer with an extra punch of beer", SecretIngredient = "Beer and special spice blend", Price = 2.25m, Quantity = 600, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Orange", FactoryId = 2, TreatName = "Fizzy Lifting Orange", Description = "Who doesn't love orange soda? Especially when it picks you up!", SecretIngredient = "Real Florida oranges", Price = 2.25m, Quantity = 375, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Artificial Preservatives", FactoryId = 1, TreatName = "Fizzy Artificial Preservatives", Description = "Have you ever wondered what soda tasted like without flavor?", SecretIngredient = "Artificial Preservatives", Price = 2.25m, Quantity = 450, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Pickle", FactoryId = 3, TreatName = "Fizzy Pickle", Description = "Pickle drink that will tingle the tongue", SecretIngredient = "Clausen’s Pickle Juice", Price = 2.25m, Quantity = 567, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Coffee", FactoryId = 3, TreatName = "Fizzy Coffee", Description = "Cold Brew with an extra punch to wake you up in the morning", SecretIngredient = "Dark Roast Coffee Beans", Price = 2.25m, Quantity = 350, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Maple syrup", FactoryId = 1, TreatName = "Fizzy maple syrup soda", Description = "The best breakfast soda,enjoy with some hotcakes", SecretIngredient = "Real maple syrup", Price = 2.25m, Quantity = 100, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Bacon", FactoryId = 2, TreatName = "Bacon soda pop", Description = "In what form is bacon not good?", SecretIngredient = "Bacon grease", Price = 2.25m, Quantity = 300, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" },
                new Drink() { Flavor = "Ginger", FactoryId = 1, TreatName = "Fizzy Ginger Beer", Description = "Spicy ginger ale that clears your sinuses", SecretIngredient = "Real ginger", Price = 2.25m, Quantity = 135, CreatedUtc = DateTimeOffset.Now, UserCreated = "wonkaIsTheMan@wonka.com" }
            );
            context.SaveChanges();
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

