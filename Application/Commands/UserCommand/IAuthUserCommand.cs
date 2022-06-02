using System;
using System.Collections.Generic;
using System.Text;
using Application.Helpers;
using Application.Interfaces;
using Application.DTO;

namespace Application.Commands.UserCommand
{
   public interface IAuthUserCommand : ICommand<UserAuthDTO, LoggedUser>
    {
    }
}
