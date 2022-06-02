using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FoodIngredient : Model
    {
        public int FoodId { get; set; }
        public int IngreId { get; set; }
        public Food Food { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
