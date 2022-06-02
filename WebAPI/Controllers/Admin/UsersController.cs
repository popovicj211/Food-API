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
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IAddUserCommand _addUserCommand;
        private IDeleteUserCommand _deleteUserCommand;
        private IGetUserCommand _getUserCommand;
        private IEditUserCommand _editUserCommand;
        private IGetUsersCommand _getUsersCommand;




        public UsersController(IAddUserCommand addUserCommand, IDeleteUserCommand deleteUserCommand, IGetUserCommand getUserCommand, IEditUserCommand editUserCommand, IGetUsersCommand getUsersCommand /*, IEmailSender sender*/)
        {
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _getUserCommand = getUserCommand;
            _editUserCommand = editUserCommand;
            _getUsersCommand = getUsersCommand;
  
        }



        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get([FromQuery] BaseSearch request)
        {
           
            try
            {
                var users = _getUsersCommand.Execute(request);

               return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

  


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
