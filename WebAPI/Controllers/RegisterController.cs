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
using Application.Commands.UserCommand;
using EFCommands.EFUserCommand;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IRegisterUserCommand _addUserCommand;
        private IEmailSender _sender;
        private readonly Encryption _enc;

        public RegisterController(IRegisterUserCommand addUserCommand,/* IEmailSender sender,*/ Encryption enc)
        {
            _addUserCommand = addUserCommand;
           // _sender = sender;
            _enc = enc;
        }

        [HttpPost]
        public ActionResult Register([FromForm] UserRegister request)
        {
            try
            {
                _addUserCommand.Execute(request);
            //    _sender.Subject = "Uspesno ste se registrovali";
         //       _sender.ToEmail = request.Email;
           //     _sender.Body = "Dobrodosli na Api restorana Pulse sada imate mogucnost da upisete Vas utisak ako ste nas posetili, ako niste sta cekate trk na rezervaciju vase dorucka,rucka ili romanticke vecere. Vidimo se!";
             //   _sender.Send();

                var stringObject = JsonConvert.SerializeObject(request);

                var encrypted = _enc.EncryptString(stringObject);

                //      var intArray = new[] { message = "User is succefuly registered" };




                /*  return new Object
                  {

                      Message = "User is succefuly registered",
                      Token
                  };

                  */
                //    return StatusCode(201, "User is succefuly registered");
                return StatusCode(201, encrypted);
            }

            catch (AlreadyExistException)
            {
                return StatusCode(422, "Email alredy exist");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }


    }
}
