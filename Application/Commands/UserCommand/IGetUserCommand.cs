using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Interfaces;

namespace Application.Commands.UserCommand
{
   public interface IGetUserCommand : ICommand<int, IEnumerable<UserDTO>>
    {
    }
}
