using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.DTO;
using Application.Interfaces;
using Application.Exceptions;
using DataAccess;
using Domain;
using Application.Commands.UserCommand;
using Application.Helpers;

namespace EFCommands.EFUserCommand
{
   public class EFAuthUserCommand : EFBaseCommand, IAuthUserCommand
    {
        public EFAuthUserCommand(DatabaseContext context) : base(context)
        {
        }

        public LoggedUser Execute(UserAuthDTO request)
        {
            var user = _context.Users
                 .Include(u => u.Role)
                 .Where(u => u.Email == request.Email)
                 .Where(u => u.Password == request.Password)
                 .FirstOrDefault();

            if (user == null)
            {
                throw new NotFoundException();
            }
            return new LoggedUser
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                RoleName = user.Role.NameRole
            };
        }

    }
}
