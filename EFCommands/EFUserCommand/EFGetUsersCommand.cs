using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.DTO;
using Application.Interfaces;
using Application.Exceptions;
using Application.Searchs;
using DataAccess;
using Domain;
using Application.Commands.UserCommand;

namespace EFCommands.EFUserCommand
{
   public class EFGetUsersCommand : EFBaseCommand, IGetUsersCommand
    {
        public EFGetUsersCommand(DatabaseContext context) : base(context)
        {
        }

        public Pagination<UserDTO> Execute(BaseSearch request)
        {
            var query = _context.Users.AsQueryable();

            if (request.Name != null)
            {
                var name = request.Name.ToLower();
                query = query.Where(u => u.Name.ToLower()
                .Contains(name)
                && u.IsDeleted == false);
            }

       

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new Pagination<UserDTO>
            {

                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pageCount,
                Data = query.Include(r => r.Role)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Address = u.Address,
                    Tel = u.Tel,
                    RoleName = u.Role.NameRole,
                    IsDeleted = u.IsDeleted
                })

            };
            return response;
        }
    }
}
