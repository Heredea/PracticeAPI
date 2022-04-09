using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PracticeAPI.Context;
using PracticeAPI.Models;

namespace PracticeAPI.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product CreateProduct(Product product);
        Rating CreateRating(Rating rating);
        Product UpdateProduct(Guid id, Product product);
        string DeleteProduct(Guid id);
        Product MostRecentProduct();
        List<Product> FilterByKey(string key);
        List<Product> StoreByRatingAverageASC();
        List<Product> StoreByRatingAverageDESC();

    }
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Rating CreateRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
            return rating;
        }

        public string DeleteProduct(Guid id)
        {
            var result = _context.Products.FirstOrDefault(s => s.Id == id);

            if (result == null) return "No product with this id!";
            _context.Products.Remove(result);
            return "Product deleted succesfully!";
            
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Ratings).ToList();
        }

        public Product MostRecentProduct()
        {
            var result = _context.Products.OrderByDescending(s => s.CreatedOn).ToList();

            return result[0];
        }

        public Product UpdateProduct(Guid id, Product product)
        {
            var result = _context.Products.FirstOrDefault(s => s.Id == id);

            if (result != null)
            {
                if (product.Name != null)
                {
                    result.Name = product.Name;
                }
                if (product.Description != null)
                {
                    result.Description = product.Description;
                }
                if (product.Ratings != null)
                {
                    result.Ratings = product.Ratings;
                }

                _context.SaveChanges();

                return result;
            }
            else
            {
                return null;
            }
        }

        public List<Product> FilterByKey(string key)
        {
            return _context.Products.Where(s => s.Name.Contains(key)).ToList();
        }

        public List<Product> StoreByRatingAverageASC()
        {
            var result = _context.Products.ToList();

            result.OrderBy(o => RatingAverage(o.Ratings));

            return result;
        }

        public List<Product> StoreByRatingAverageDESC()
        {
            var result = _context.Products.ToList();

            result.OrderBy(o => RatingAverage(o.Ratings));

            result.Reverse();

            return result;
        }

        public int RatingAverage(ICollection<Rating> rating)
        {
            int sum = 0;
            int i = 1;

            foreach(var item in rating)
            {
                sum = +item.Value;
                i++;
            }

            return sum;
        }
    }
}
