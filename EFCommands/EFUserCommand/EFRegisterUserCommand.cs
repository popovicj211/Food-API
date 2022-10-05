using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommand;
using Application.Exceptions;
using DataAccess;
using Domain;
using System.Linq;
using Application.DTO;

namespace EFCommands.EFUserCommand
{
   public class EFRegisterUserCommand : EFBaseCommand, IRegisterUserCommand
    {

        public EFRegisterUserCommand(DatabaseContext context) : base(context)
        {

        }

        public void Execute(UserRegister request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                throw new AlreadyExistException();
            }

            else
            {
                throw new NotFoundException();
            }

            var password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            

            _context.Users.Add(new User
            {
                Name = request.Name,
                Email = request.Email,
               //      Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password),
                Password = password,
                Token = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Email + request.Password),
                Address = request.Address,
                Tel = request.Tel,
            });

            _context.SaveChanges();
        }
    }
}
