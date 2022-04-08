using System;
using System.Collections.Generic;

namespace PracticeAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
