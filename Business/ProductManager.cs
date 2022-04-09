using System;
using System.Collections.Generic;
using PracticeAPI.Models;
using PracticeAPI.Repositories;

namespace PracticeAPI.Business
{
    public interface IProductManager
    {
        List<Product> GetProducts();
        Product CreateProduct(Product product);
        Rating ReviewProduct(Guid productId, int rating);
        Product UpdateProduct(Guid id, Product product);
        string DeleteProduct(Guid id);
        Product MostRecentProduct();
        List<Product> FilterByKey(string key);
        List<Product> StoreByRatingAverageASC();
        List<Product> StoreByRatingAverageDESC();

    }

    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public string DeleteProduct(Guid id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public List<Product> FilterByKey(string key)
        {
            return _productRepository.FilterByKey(key);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product MostRecentProduct()
        {
            return _productRepository.MostRecentProduct();
        }

        public Rating ReviewProduct(Guid productId, int ratingValue)
        {
            Rating rating = new Rating { ProductId = productId, Value = ratingValue };
            _productRepository.CreateRating(rating);
            return rating;
        }

        public List<Product> StoreByRatingAverageASC()
        {
            return _productRepository.StoreByRatingAverageASC();
        }

        public List<Product> StoreByRatingAverageDESC()
        {
            return _productRepository.StoreByRatingAverageDESC();
        }

        public Product UpdateProduct(Guid id, Product product)
        {
            return _productRepository.UpdateProduct(id, product);
        }
    }

}
