using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searchs
{
   public class BaseSearch
    {

        public int? Id { get; set; }
        public bool? IsDeleted { get; set; }
        public int PerPage { get; set; } = 6;
        public int PageNumber { get; set; } = 1;
        public string Name { get; set; }
    }
}
