using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;
using TreatTracker.Models.StoreModels;

namespace TreatTracker.Services
{
    public class StoreService
    {
        public StoreService()
        {
        }

        public IEnumerable<StoreListItem> GetStores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Stores
                    .Select(
                        e =>
                    new StoreListItem
                    {
                        StoreId = e.StoreId,
                        LocationName = e.LocationName
                    }

                    );

                return query.ToArray();
            }
        }

        public StoreDetail GetStoreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Stores
                    .Single(e => e.StoreId == id);
                return
                new StoreDetail
                {
                    StoreId = entity.StoreId,
                    LocationName = entity.LocationName,
                    Address = entity.Address,
                    PhoneNumber = entity.PhoneNumber
                };

            }
        }
        public IEnumerable<StoreListItem> GetStoresByCandyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allStores =
                    ctx
                    .Candies
                    .Single(e => e.CandyId == id)
                    .Stores
                    .Select
                    (e =>
                    new StoreListItem
                    {
                        StoreId = e.StoreId,
                        LocationName = e.LocationName
                    }
                        );
                return allStores.ToArray();
            }
        }
        public IEnumerable<StoreListItem> GetStoresByDrinkId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allStores =
                    ctx
                    .Drinks
                    .Single(e => e.DrinkId == id)
                    .Stores
                    .Select
                    (e =>
                    new StoreListItem
                    {
                        StoreId = e.StoreId,
                        LocationName = e.LocationName
                    }
                        );
                return allStores.ToArray();
            }
        }

        public StoreInvoice GetStoreInvoice(int id, StoreShipping model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var store =
                    ctx
                    .Stores
                    .Single(s => s.StoreId == id);
                var isShipping = model.IsShipping;
                return
                    new StoreInvoice
                    {
                        StoreId = id,
                        AmountofTreats = GetCandyQuantity(id) + GetDrinkQuantity(id),
                        TotalCost = GetCandyCost(id, isShipping) + GetDrinkCost(id, isShipping)
                    };
            }
        }

        public decimal? GetCandyCost(int id, bool isShipping)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var candies =
                    ctx
                    .Stores
                    .Single(s => s.StoreId == id)
                    .Candies;
                decimal? treatCost = 0;
                foreach (var candy in candies)
                {
                    decimal? cost = candy.Price;
                    int quantity = candy.Quantity;
                    var candyCost = cost * quantity;
                    treatCost += candyCost;

                }
                var totalCost = treatCost + GetShippingCost(isShipping, treatCost);
                return totalCost;
            }
        }
        public int GetCandyQuantity(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var candies =
                    ctx
                    .Stores
                    .Single(s => s.StoreId == id)
                    .Candies;
                int totalQuantity = 0;
                foreach (var candy in candies)
                {
                    int quantity = candy.Quantity;
                    totalQuantity += quantity;
                }

                return totalQuantity;
            }
        }
        public decimal? GetDrinkCost(int id, bool isShipping)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var drinks =
                    ctx
                    .Stores
                    .Single(s => s.StoreId == id)
                    .Drinks;
                decimal? treatCost = 0;
                foreach (var drink in drinks)
                {
                    decimal? cost = drink.Price;
                    int quantity = drink.Quantity;
                    var drinkCost = cost * quantity;
                    treatCost += cost;
                }

               var totalCost = treatCost + GetShippingCost(isShipping, treatCost);
                return totalCost;
            }
        }
        public int GetDrinkQuantity(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var drinks =
                    ctx
                    .Stores
                    .Single(s => s.StoreId == id)
                    .Drinks;
                int totalQuantity = 0;
                foreach (var drink in drinks)
                {
                    int quantity = drink.Quantity;
                    totalQuantity += quantity;
                }

                return totalQuantity;
            }
        }
        public decimal? GetShippingCost (bool isShipping, decimal? totalCost)
        {
            if(isShipping == true)
            {
                var tax = totalCost * 0.08m;
                var shippingRate = totalCost * 0.05m;
                var totalShipping = tax + shippingRate;
                return totalShipping;
            }
            var treatTax = totalCost * 1.08m;
            return treatTax;
        }
    }
}



