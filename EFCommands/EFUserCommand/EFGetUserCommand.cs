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

namespace EFCommands.EFUserCommand
{
   public class EFGetUserCommand : EFBaseCommand, IGetUserCommand
    {
        public EFGetUserCommand(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<UserDTO> Execute(int id)
        {
            var query = _context.Users.AsQueryable();

            if (_context.Users.Any(u => u.Id == id))
            {
                query = query.Where(u => u.Id == id);
            }
            else
            {
                throw new NotFoundException();
            }

            return query
                .Include(r => r.Role)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Address = u.Address,
                    Tel = u.Tel,
                    RoleName = u.Role.NameRole,
                    IsDeleted = u.IsDeleted
                });
        }
    }
}
