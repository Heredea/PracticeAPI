using System;
using System.Collections.Generic;
using PracticeAPI.Models;
using PracticeAPI.Repositories;

namespace PracticeAPI.Business
{
    public interface IStoreManager
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

    public class StoreManager : IStoreManager
    {
        private readonly IStoreRepository _storeRepository;
        public StoreManager(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Store CreateStore(Store store)
        {
            return _storeRepository.CreateStore(store);
        }

        public List<Store> GetStores()
        {
            return _storeRepository.GetStores();
        }

        public Store GetStoreById(Guid id)
        {
            return _storeRepository.GetStoreById(id);
        }

        public Store UpdateStore(Guid id, Store store)
        {
            return _storeRepository.UpdateStore(id, store);
        }

        public string DeleteStore(Guid id)
        {
            return _storeRepository.DeleteStore(id);
        }
        public List<Store> GetByCountry(string country)
        {
            return _storeRepository.GetByCountry(country);
        }
        public List<Store> GetByCity(string city)
        {
            return _storeRepository.GetByCity(city);
        }
        public List<Store> GetStoresSortedByMonthlyIncome()
        {
            return _storeRepository.GetStoresSortedByMonthlyIncome();
        }

        public List<Store> TransferNames(Guid id1, Guid id2)
        {
            return _storeRepository.TransferNames(id1, id2);
        }

        public Store OldestStore()
        {
            return _storeRepository.OldestStore();
        }

        public List<Store> FilterByKey(string key)
        {
            return _storeRepository.FilterByKey(key);
        }
    }
}
