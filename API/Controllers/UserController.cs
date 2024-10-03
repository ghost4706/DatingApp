using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
// [ApiController]
// [Route("api/[controller]")] //  /api/user

[Authorize]
public class UserController(IUserRepository userRepository,IMapper mapper) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync(); 

        return Ok(users);
    }

    
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>>GetUser(string username)
    {
        var user = await userRepository.GetMemberAsync(username);
        if(user == null) return NotFound();
        return user;
    }
}
