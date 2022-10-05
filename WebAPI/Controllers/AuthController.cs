using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Application.Searchs;
using Application.Helpers;
using Application.Commands.UserCommand;
using EFCommands.EFUserCommand;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using WebAPI.Helpers;





namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthUserCommand _authUserCommand;
        //  private readonly JwtManager _jwtManager;
        private readonly Encryption _enc;

        public AuthController(IAuthUserCommand authUserCommand, Encryption enc)
        {
            _authUserCommand = authUserCommand;
            _enc = enc;

        }

        [HttpPost]
        public ActionResult Login([FromForm] UserAuthDTO request)
        {
            try
            {
             //   _authUserCommand.Execute(request);

                /* var stringObjekat = JsonConvert.SerializeObject(user);

                 var encrypted = _enc.EncryptString(stringObjekat);

                 return Ok(new { token = encrypted });*/

                var user = _authUserCommand.Execute(request);

                var stringObject = JsonConvert.SerializeObject(user);

                var encrypted = _enc.EncryptString(stringObject);


                   return Ok(new {User =  user , Token = encrypted });
        
            }

            catch (AlreadyExistException)
            {
                return StatusCode(422, "Email alredy exist");
            }
           /* catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }*/
        }



        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Replace("\u000e", "");
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }


    }
}
