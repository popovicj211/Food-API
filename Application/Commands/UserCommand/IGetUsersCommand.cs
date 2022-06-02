using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Interfaces;
using Application.Searchs;

namespace Application.Commands.UserCommand
{
   public interface IGetUsersCommand : ICommand<BaseSearch, Pagination<UserDTO>>
    {
    }
}
