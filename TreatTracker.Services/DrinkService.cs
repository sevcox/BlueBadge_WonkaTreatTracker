using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;
using TreatTracker.Models.DrinkModels;
using TreatTracker.Models.StoreModels;

namespace TreatTracker.Services
{
    public class DrinkService
    {
        private readonly string _userName;

        public DrinkService(string userName)
        {
            _userName = userName;
        }
        public bool CreateDrink(DrinkCreate model)
        {
            var entity =
                new Drink()
                {
                    TreatName = model.TreatName,
                    Flavor = model.Flavor,
                    Description = model.Description,
                    SecretIngredient = model.SecretIngredient,
                    FactoryId = model.FactoryId,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    CreatedUtc = DateTimeOffset.Now,
                    UserCreated = _userName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Drinks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool ConnectDrinkWithStore(int drinkId, OnlyStoreId model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var drink =
                ctx
                .Drinks
                .Single(d => d.DrinkId == drinkId);

                var store =
                    ctx
                    .Stores
                    .Single(s => s.StoreId == model.StoreId);

                drink.Stores.Add(store);

                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<DrinkListItem> GetDrinks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drinks
                        .Select(
                            e =>
                                new DrinkListItem
                                {
                                    DrinkId = e.DrinkId,
                                    TreatName = e.TreatName,
                                    Flavor = e.Flavor,
                                    Quantity = e.Quantity,
                                    FactoryId = e.FactoryId,
                                }
                        );

                return query.ToArray();
            }
        }
        public DrinkDetail GetDrinkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == id);
                return
                    new DrinkDetail
                    {
                        DrinkId = entity.DrinkId,
                        TreatName = entity.TreatName,
                        Flavor = entity.Flavor,
                        Description = entity.Description,
                        SecretIngredient = entity.SecretIngredient,
                        Price = entity.Price,
                        Quantity = entity.Quantity,
                        CreatedUtc = entity.CreatedUtc,
                        UserCreated = entity.UserCreated,
                        ModifiedUtc = entity.ModifiedUtc,
                        UserModified = entity.UserModified
                    };
            }
        }
        public bool UpdateDrink(DrinkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == model.DrinkId);
                entity.TreatName = model.TreatName;
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.UserModified = _userName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDrink(int drinkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == drinkId);

                ctx.Drinks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Factory_DrinkListItem> GetDrinksByFactoryId(int factoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Factories
                     .Single(e => e.FactoryId == factoryId)
                     .Drinks
                     .Select
                     (e =>
                     new Factory_DrinkListItem
                     {
                         DrinkId = e.DrinkId,
                         TreatName = e.TreatName,
                         Flavor = e.Flavor,
                         Quantity = e.Quantity,
                         FactoryId = e.FactoryId,
                         LocationName = e.Factory.LocationName
                     }
                     );
                return query.ToArray();
            }
        }
        public IEnumerable<DrinkListItem> GetDrinksByStoreId(int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allDrinks =
                    ctx
                    .Stores
                    .Single(e => e.StoreId == storeId)
                    .Drinks
                    .Select
                    (e =>
                        new DrinkListItem
                        {
                            DrinkId = e.DrinkId,
                            TreatName = e.TreatName,
                            Flavor = e.Flavor,
                            Quantity = e.Quantity,
                            FactoryId = e.FactoryId
                        }
                    );
                return allDrinks.ToArray();
            }
        }
    }
}
