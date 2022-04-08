using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using PracticeAPI.Business;
using PracticeAPI.Models;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_productManager.GetProducts());
        }

        [HttpGet]
        [Route("MostRecentProduct")]
        public IActionResult MostRecentProduct()
        {
            return Ok(_productManager.MostRecentProduct());
        }

        [HttpGet]
        [Route("FilterByKey")]
        public IActionResult FilterByKey(string key)
        {
            return Ok(_productManager.FilterByKey(key));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Product product)
        {
            return Ok(_productManager.CreateProduct(product));
        }

        [HttpPost]
        [Route("review")]
        public IActionResult ReviewProduct(Guid productId, int rating)
        {
            return Ok(_productManager.ReviewProduct(productId, rating));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateProduct(Guid id,[FromBody] Product product)
        {
            return Ok(_productManager.UpdateProduct(id, product));
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_productManager.DeleteProduct(id));
        }
    }
}
