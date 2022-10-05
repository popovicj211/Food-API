﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
   public class PasswordNotValidException : Exception
    {
        public PasswordNotValidException(string message) : base(message)
        {

        }

        public PasswordNotValidException() : base("Password is not valid.")
        {

        }
    }
}
