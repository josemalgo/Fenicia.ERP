﻿using System;
using System.Collections.Generic;

namespace Fenicia.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Product()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
