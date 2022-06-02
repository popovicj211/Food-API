using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order : Model
    {

        public decimal Total { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public int FoodId { get; set; }
        public int UserId { get; set; }
        public Food Food { get; set; }
        public User User { get; set; }


    }
}
