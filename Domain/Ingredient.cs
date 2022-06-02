using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
  public class Ingredient : Model
    {
        public string Name { get; set; }
        public ICollection<FoodIngredient> FoodIngredients { get; set; }
    }
}
