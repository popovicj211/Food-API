using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
   public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
