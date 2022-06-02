using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
   public class FoodAddDTO
    {
        [Required(ErrorMessage = "Name is required"),
       MinLength(3, ErrorMessage = "Minimum length for name is 3"),
       MaxLength(100, ErrorMessage = "Maximum length for name is 100")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Ingredient is required")]
        public int IngredientId { get; set; }
    }
}
