using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Alt { get; set; }

        public ICollection<Food> Foods { get; set; }

    }
}
