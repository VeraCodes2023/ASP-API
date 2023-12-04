using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Services.UserServices.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private static List<User> _users = new List<User>();

        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        // private static GetUserDto ConvertToGetUserDto(User user)
        // {
        //     return new GetUserDto
        //     {
        //         Id = user.Id,
        //         Name= user.Name,
        //         Role= user.Role,
        //         Email =user.Email,
        //         Password =user.Password,
        //         Avatar = user.Avatar
        //     };
        // }
        private int GetNextId()
        {
            int maxId = _users.Any() ? _users.Max(c => c.Id) : 0;
            return maxId+1;
        }

        public async Task< ServiceResponse<List<GetUserDto>> > DeleteUser(int id)
        {  
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var dbUsers = await _context.Users.ToListAsync();
                var targetUser = dbUsers.Find(u => u.Id == id);
                _users.Remove(targetUser!);
                serviceResponse.Data=dbUsers.Select(u=> _mapper.Map<GetUserDto>(u)).ToList();;
               
            }
            catch(Exception e)
            {
                serviceResponse.Success= false;
                serviceResponse.Message = e.Message;
            }
            
            return serviceResponse;
            
        }

        public async Task< ServiceResponse<List<GetUserDto>> >GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var dbUsers = await _context.Users.ToListAsync();
                serviceResponse.Data=dbUsers.Select(u=> _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success =false;
                serviceResponse.Message = e.Message;
            }
           
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto> > GetSingleUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var dbUsers = await _context.Users.ToListAsync();
                
                var targetUser =dbUsers.FirstOrDefault(u=>u.Id ==id);
                if(targetUser is null)
                {
                    throw new Exception($"User with id {id} is not found.");
                }
                serviceResponse.Data= _mapper.Map<GetUserDto>(targetUser);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
           
           
            return serviceResponse;
        }

        public async Task< ServiceResponse<List<GetUserDto>> > UpdateUser(int id, UpdateUserDto user)
        {
           var serviceResponse = new ServiceResponse<List<GetUserDto>>();
           try
           {
                var dbUsers = await _context.Users.ToListAsync();
                var targetUser=dbUsers.FirstOrDefault(u=>u.Id ==id);
                if (targetUser is null)
                throw new Exception($"User with id {id} is not found.");
                serviceResponse.Success = false;
                _mapper.Map<User>(user);
                targetUser.Name =user.Name;
                targetUser.Email = user.Email;
                targetUser.Password =user.Password;
                targetUser.Avatar =user.Avatar;
                serviceResponse.Data=dbUsers.Select(u=> _mapper.Map<GetUserDto>(u)).ToList();
                
               
           }
           catch(Exception e)
           {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
           }
            return serviceResponse;
        }

        public async Task < ServiceResponse<List<GetUserDto>> > AddUser(AddUserDto user)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
               var dbUsers = await _context.Users.ToListAsync();
                if(user is null)
                throw new Exception("Please input user info");
                var newUser = _mapper.Map<User>(user);
                newUser.Id = GetNextId();
                dbUsers.Add(_mapper.Map<User>( newUser));
                serviceResponse.Data=dbUsers.Select(u=> _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
        
            return serviceResponse;
        }

    }
}