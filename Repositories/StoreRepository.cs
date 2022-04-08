using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PracticeAPI.Context;
using PracticeAPI.Models;

namespace PracticeAPI.Repositories
{
    public interface IStoreRepository
    {
        List<Store> GetStores();
        Store CreateStore(Store store);
        Store UpdateStore(Guid id, Store store);
        string DeleteStore(Guid id);
        Store GetStoreById(Guid id);
        List<Store> GetByCountry(string country);
        List<Store> GetByCity(string city);
        List<Store> GetStoresSortedByMonthlyIncome();
        List<Store> TransferNames(Guid id1, Guid id2);
        Store OldestStore();
        List<Store> FilterByKey(string key);
    }
    public class StoreRepository : IStoreRepository
    {
        private readonly DatabaseContext _context;
        public StoreRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Store CreateStore(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
            return store;
        }

        public List<Store> GetStores()
        {
            return _context.Stores.ToList();
        }

        public Store GetStoreById(Guid id)
        {
            return _context.Stores.FirstOrDefault(s => s.Id == id);
        }

        public Store UpdateStore(Guid id, Store store)
        {
            var result = _context.Stores.FirstOrDefault(s => s.Id == id);

            if(result != null)
            {
                if(store.Name != null)
                {
                    result.Name = store.Name;
                }
                if(store.Country != null)
                {
                    result.Country = store.Country;
                }
                if(store.City != null)
                {
                    result.City = store.City;
                }
                if(store.MonthlyIncome != 0)
                {
                    result.MonthlyIncome = store.MonthlyIncome;
                }
                if(store.OwnerName != null)
                {
                    result.OwnerName = store.OwnerName;
                }
                if(result.ActiveSince != store.ActiveSince)
                {
                    result.ActiveSince = store.ActiveSince;
                }

                _context.SaveChanges();

                return result;
            }
            else
            {
                return null;
            }
        }

        public string DeleteStore(Guid id)
        {
            var result = _context.Stores.FirstOrDefault(s => s.Id == id);

            _context.Stores.Remove(result);

            _context.SaveChanges();

            return "Store with id '" + result.Id + "' was deleted succesfully!";
        }

        public List<Store> GetByCountry(string country)
        {
            return _context.Stores.Where(s => s.Country == country).ToList();
        }
        public List<Store> GetByCity(string city)
        {
            return _context.Stores.Where(s => s.City == city).ToList();
        }

        public List<Store> GetStoresSortedByMonthlyIncome()
        {
            var result = _context.Stores.OrderBy(s => s.MonthlyIncome).ToList();

            return result;
        }

        public List<Store> TransferNames(Guid id1, Guid id2)
        {
            string intermediar = null;
            var store1 = _context.Stores.FirstOrDefault(s => s.Id == id1);
            var store2 = _context.Stores.FirstOrDefault(s => s.Id == id2);

            intermediar = store1.Name;
            store1.Name = store2.Name;
            store2.Name = intermediar;

            _context.SaveChanges();

            return new List<Store>
            {
                store1,
                store2
            };
                
        }

        public Store OldestStore()
        {
            var result = _context.Stores.OrderBy(s => s.ActiveSince).ToList();

            return result[0];
        }

        public List<Store> FilterByKey(string key)
        {
            return _context.Stores.Where(s => s.Name.Contains(key)).ToList();
        }
    }

}
