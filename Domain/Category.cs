using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Category : Model
    {
        public string Name { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
