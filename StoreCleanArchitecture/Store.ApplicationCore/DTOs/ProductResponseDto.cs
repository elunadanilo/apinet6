using System;
using System.Collections.Generic;
using System.Text;

namespace Store.ApplicationCore.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
