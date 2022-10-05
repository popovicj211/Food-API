using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
   public class UserDataTokenResponse
    {
        public LoggedUser Data { get; set; }
        public string Token { get; set; }
    }
}
