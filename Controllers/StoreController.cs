using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using PracticeAPI.Business;
using PracticeAPI.Models;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IStoreManager _storeManager;
        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_storeManager.GetStores());
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_storeManager.GetStoreById(id));
        }

        [HttpGet]
        [Route("getbyCountry/{country}")]
        public IActionResult GetByCountry(string country)
        {
            return Ok(_storeManager.GetByCountry(country));
        }

        [HttpGet]
        [Route("getbyCity/{city}")]
        public IActionResult GetByCity(string city)
        {
            return Ok(_storeManager.GetByCity(city));
        }

        [HttpGet]
        [Route("getAllStoredByMonthlyIncome")]
        public IActionResult GetSortedByMonthlyIncome()
        {
            return Ok(_storeManager.GetStoresSortedByMonthlyIncome());
        }

        [HttpGet]
        [Route("oldestStore")]
        public IActionResult OldestStore()
        {
            return Ok(_storeManager.OldestStore());
        }

        [HttpGet]
        [Route("filterByKey")]
        public IActionResult FilterByKey(string key)
        {
            return Ok(_storeManager.FilterByKey(key));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Store store)
        {
            return Ok(_storeManager.CreateStore(store));
        }

        [HttpPut]
        [Route("update")]
        public  IActionResult Update(Guid id, [FromBody] Store store)
        {
            return Ok(_storeManager.UpdateStore(id, store));
        }

        [HttpPut]
        [Route("transferNames/{id1}&{id2}")]
        public IActionResult TransferNames(Guid id1, Guid id2)
        {
            return Ok(_storeManager.TransferNames(id1,id2));
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_storeManager.DeleteStore(id));
        }

    }
}
