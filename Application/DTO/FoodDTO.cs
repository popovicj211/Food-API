using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class FoodDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }


        public string ImagePath { get; set; }


        public string CategoryName { get; set; }

    }
}
