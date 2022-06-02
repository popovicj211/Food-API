using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.DTO;
using Application.Interfaces;
using Application.Exceptions;
using DataAccess;
using Domain;
using Application.Commands.UserCommand;

namespace EFCommands.EFUserCommand
{
  public class EFAddUserCommand : EFBaseCommand, IAddUserCommand
    {

        public EFAddUserCommand(DatabaseContext context): base(context)
        {

        }

        public void Execute(UserAddDTO request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                throw new AlreadyExistException();
            }

            if (_context.Roles.Any(r => r.Id == request.RoleId))
            {

            }
            else
            {
                throw new NotFoundException();
            }

            _context.Users.Add(new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password),
                Active = request.Active,
                Token = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Email + request.Password),
                Address = request.Address,
                Tel = request.Tel,
                RoleId = request.RoleId
            });

            _context.SaveChanges();
        }

    }
}
