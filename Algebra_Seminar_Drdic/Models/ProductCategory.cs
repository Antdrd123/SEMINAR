﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra_Seminar_Drdic.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }


        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
