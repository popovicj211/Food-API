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




        public UsersController(IAddUserCommand addUserCommand, IDeleteUserCommand deleteUserCommand, IGetUserCommand getUserCommand, IEditUserCommand editUserCommand, IGetUsersCommand getUsersCommand)
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
        public ActionResult<IEnumerable<UserDTO>> Get(int id)
        {

            try
            {
                var user = _getUserCommand.Execute(id);

                return Ok(user);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] UserAddDTO request)
        {
     

            try
            {
                _addUserCommand.Execute(request);

                return StatusCode(201, "User is succesfully created.");
            }
            catch (NotFoundException)
            {
                return StatusCode(404, "RoleId is not found");
            }
            catch (AlreadyExistException)
            {
                return StatusCode(422, "Email already exist");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }



        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserEditDTO request)
        {
            try
            {
                _editUserCommand.Execute(request);
                return NoContent();
            }
            catch (AlreadyExistException)
            {
                return StatusCode(422, "Email or Role or Password already exist");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteUserCommand.Execute(id);
                return StatusCode(204, "User is deleted");
            }
            catch (AlreadyExistException)
            {
                return Conflict("User is alredy deleted");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }

        }
    }
}
