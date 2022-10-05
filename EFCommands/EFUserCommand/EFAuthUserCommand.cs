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

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace EFCommands.EFUserCommand
{
   public class EFAuthUserCommand : EFBaseCommand, IAuthUserCommand
    {

     
        public EFAuthUserCommand(DatabaseContext context) : base(context)
        {

        }

        public LoggedUser? Execute(UserAuthDTO request)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(request.Password, 10);

            var validatePass = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, password);
      //      var psss = "$2a$10$VC.kKNBIjy5vHYbt84iJf.6i1zUbdEceFAynd/m5dLBPA252eMNP.";

            /*   if (!validatePass)
               {
                   throw new NotFoundException();
               }*/


            var user = _context.Users
           .Include(u => u.Role)
          .Where(u => u.Email == request.Email)
        //    .Where(u => u.Password == password)
            .FirstOrDefault();




            /*   if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
               {

               }*/

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new PasswordNotValidException();
            }


            if (user == null)
                {
                    throw new NotFoundException();
                }




                return new LoggedUser
                {

                    Id = user.Id,
                 //   Name = validatePass.ToString(),
                   //   Name = password,
                      Name = user.Name,
                    Email = user.Email,
                 //   Email = BCrypt.Net.BCrypt.Verify(request.Password, user.Password).ToString(),
                    RoleName = user.Role.NameRole

                };
            

           

        }

    


    }
}
