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
   public class EFEditUserCommand : EFBaseCommand, IEditUserCommand
    {
        public EFEditUserCommand(DatabaseContext context) : base(context)
        {
        }

        public void Execute(UserEditDTO request)
        {
            var user = _context.Users.Find(request.Id);

            if (user == null)
            {
                throw new NotFoundException();
            }

            if (request.Email != null)
            {
                if (!_context.Users.Any(u => u.Email == request.Email))
                {
                    user.Email = request.Email;
                }
                else
                {
                    throw new AlreadyExistException();
                }
            }

            if (request.Name != null)
            {
                    user.Name = request.Name;
                
            }


            if (request.Password != null)
            {
                    user.Password = request.Password;
            }

            if (request.RoleId != 0)
            {
                if (user.RoleId != request.RoleId)
                {
                    if (_context.Roles.Any(r => r.Id == request.Id))
                    {
                        user.RoleId = request.RoleId;
                    }
                    else
                    {
                        throw new NotFoundException();
                    }
                }
                else
                {
                    throw new AlreadyExistException();
                }
            }



            if (user.IsDeleted != request.IsDeleted)
            {
                user.IsDeleted = request.IsDeleted;
            }


            _context.SaveChanges();



        }
    }
}
