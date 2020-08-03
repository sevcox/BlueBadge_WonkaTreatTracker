﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;
using TreatTracker.Models.CandyModels;

namespace TreatTracker.Services
{
    public class CandyService
    {
        private readonly Guid _userId;

        public CandyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCandy(CandyCreate model)
        {
                var entity =
                new Candy()
                {
                    TreatName = model.TreatName,
                    CandyType = model.CandyType,
                    Description = model.Description,
                    SecretIngredient = model.SecretIngredient,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    CreatedUtc = DateTimeOffset.Now,
                    UserCreated = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Candies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public void ConnectCandyWithStore(int candyId, int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Candy candy = new Candy { CandyId = candyId };
                ctx.Candies.Add(candy);
                ctx.Candies.Attach(candy);

                Store store = new Store { StoreId = storeId };
                ctx.Stores.Add(store);
                ctx.Stores.Attach(store);

                candy.Stores.Add(store);

                ctx.SaveChanges();
                    
            }
        }
        public IEnumerable<CandyListItem> GetCandies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Candies
                        .Select(
                            e =>
                                new CandyListItem
                                {
                                    CandyId = e.CandyId,
                                    TreatName = e.TreatName,
                                    CandyType = e.CandyType,
                                    Quantity = e.Quantity,
                                    CreatedUtc = e.CreatedUtc,
                                    UserCreated = e._userId
                                }
                        );

                return query.ToArray();
            }
        }
        public CandyDetail GetCandyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Candies
                        .Single(e => e.CandyId == id);
                return
                    new CandyDetail
                    {
                        CandyId = entity.CandyId,
                        TreatName = entity.TreatName,
                        CandyType = entity.CandyType,
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
        public bool UpdateCandy(CandyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Candies
                        .Single(e => e.CandyId == model.CandyId);
                entity.TreatName = model.TreatName;
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.UserModified = _userId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCandy(int candyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Candies
                        .Single(e => e.CandyId == candyId);

                ctx.Candies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<Candy> GetCandiesByStore(int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allCandies =
                    ctx
                    .Stores
                    .Single(s => s.StoreId == storeId);
                //foreach (var candy in allCandies)
                //{
                //    foreach(var thing in candy)
                //    {

                //    }
                //    new CandyListItem
                //    {
                //        CandyId = candy.CandyId,
                //        TreatName = e.TreatName,
                //        CandyType = e.CandyType,
                //        Quantity = e.Quantity,
                //        CreatedUtc = e.CreatedUtc,
                //        UserCreated = e._userId
                //    }
                //}
                return allCandies.Candies;
                //var query =
                //    ctx
                //        .Stores
                //        .Where(e => e.StoreId == storeId)
                //        .Select(e => e.Candies);
                //List<Candy> candies = new List<Candy>();
            }
        }
    }
}