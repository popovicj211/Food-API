using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
   public class UserRegister
    {
        [Required(ErrorMessage = "Name is required"),
      MinLength(3, ErrorMessage = "Minimum length for name is 3"),
       MaxLength(75, ErrorMessage = "Maximum length for name is 75")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required"),
       MinLength(10, ErrorMessage = "Minimum length for email is 10"),
        MaxLength(50, ErrorMessage = "Maximum length for email is 50")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required"),
   MinLength(8, ErrorMessage = "Minimum length for password is 8"),
   MaxLength(25, ErrorMessage = "Maximum length for password is 25")]
        public string Password { get; set; }

#nullable enable
        public string? Address { get; set; }
        public string? Tel { get; set; }
#nullable disable

    }
}
