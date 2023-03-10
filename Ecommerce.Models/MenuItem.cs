using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Decription { get; set; }
        public string ImagePath { get; set; }
        [Range(1, 1000, ErrorMessage = "Price should be between R1 and R1000")]
        public double Price { get; set; }
        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]
        public FoodType FoodType { get; set; }
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
