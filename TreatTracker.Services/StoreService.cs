﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;

namespace TreatTracker.Services
{
    public class StoreService
    {
        private readonly Guid _userId;
        public StoreService(Guid userId)
        {
            _userId = userId;
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
            using(var ctx = new ApplicationDbContext())
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
                       LocationName = e.LocationName,
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
                    .Drinks // step into the Drink DbSey
                    .Single(e => e.DrinkId == id) //
                    .Stores // step into ICollection of stores
                    .Select
                    (e =>
                   new StoreListItem
                   {
                       StoreId = e.StoreId,
                       LocationName = e.LocationName,
                   }

                        );
                return allStores.ToArray();

            }
        }

        //public IEnumerable<Store_CandyListItem> GetAllCandyByStore(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Stores
        //            .Select(
        //                e =>
        //                new Store_CandyListItem
        //                {
        //                    StoreId = e.StoreId,
        //                    LocationName = e.LocationName,
        //                    CandyId = e.CandyId,
        //                    TreatName = e.TreatName,
        //                    Quantity = e.Quantity
        //                }

        //                );
        //        return query.ToArray();
        //    }
        //}

        //public IEnumerable<Store_DrinkListItem> GetAllDrinkByFactory(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Stores
        //            .Select(
        //                e =>
        //                new Store_DrinkListItem
        //                {
        //                    StoreId = e.StoreId,
        //                    LocationName = e.LocationName,
        //                    DrinkId = e.DrinkId,
        //                    TreatName = e.TreatName,
        //                    Quantity = e.Quantity
        //                }

        //                );
        //        return query.ToArray();
        //    }
        //}

    }
}

    
