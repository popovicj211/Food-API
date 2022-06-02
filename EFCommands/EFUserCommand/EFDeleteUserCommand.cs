using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Interfaces;
using Application.Exceptions;
using DataAccess;
using Domain;
using Application.Commands.UserCommand;

namespace EFCommands.EFUserCommand
{
   public class EFDeleteUserCommand : EFBaseCommand, IDeleteUserCommand
    {
        public EFDeleteUserCommand(DatabaseContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                throw new NotFoundException();
            }

            if (user.IsDeleted == true)
            {
                throw new AlreadyExistException();
            }

            user.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
