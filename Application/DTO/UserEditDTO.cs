using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
   public class UserEditDTO
    {
        public int Id { get; set; }

      [MinLength(3, ErrorMessage = "Minimum length for name is 3"),
       MaxLength(75, ErrorMessage = "Maximum length for name is 75")]
        public string Name { get; set; }

       [MinLength(10, ErrorMessage = "Minimum length for email is 10"),
        MaxLength(50, ErrorMessage = "Maximum length for email is 50")]
        public string Email { get; set; }

   [MinLength(8, ErrorMessage = "Minimum length for password is 8"),
   MaxLength(25, ErrorMessage = "Maximum length for password is 25")]
        public string Password { get; set; }

        public bool Active { get; set; }


#nullable enable
        public string? Address { get; set; }
        public string? Tel { get; set; }
#nullable disable
        public int RoleId { get; set; }

        public bool IsDeleted { get; set; }


    }
}
