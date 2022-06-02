using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Food : Model
    {
        public string Name { get; set; }

        public decimal Price { get; set; }


        public int ImageId { get; set; }
        
        public Image Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<FoodIngredient> FoodIngredients { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
