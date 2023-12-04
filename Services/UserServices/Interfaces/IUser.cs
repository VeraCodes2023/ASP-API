global using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.User;


namespace API.Services.UserServices.Interfaces
{
    public interface IUserService
    {
        Task < ServiceResponse<List<GetUserDto>> > GetAllUsers();
        Task < ServiceResponse<GetUserDto> > GetSingleUserById(int id);
        Task< ServiceResponse<List<GetUserDto>> >DeleteUser(int id);
        Task < ServiceResponse<List<GetUserDto>> > AddUser(AddUserDto user);
        Task < ServiceResponse<List<GetUserDto>> > UpdateUser(int id, UpdateUserDto user);
    }
}