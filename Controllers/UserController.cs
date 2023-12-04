global using API.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Models;
using API.Services.UserServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            
            this._userService = userService;
        }

        [HttpGet("getAll")]
        public async Task< ActionResult<ServiceResponse<List<GetUserDto>> > > Get()
        {
            return Ok( await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto> >> GetSingle(int id)
        {
            return Ok(await _userService.GetSingleUserById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>> >>  DeleteUser( int id)
        {
       
            return Ok(await _userService.DeleteUser(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>> >>AddUser(AddUserDto user)
        {
            
            return Ok(await _userService.AddUser(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>> >> UpdateUser(int id, UpdateUserDto user)
        {
            var response = await _userService.UpdateUser(id,user);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}