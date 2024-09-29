using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")] //  /api/user
public class UserController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        return users;
    }


    [HttpGet("{Id:int}")]
    public async Task<ActionResult<AppUser>>GetUser(int Id)
    {
        var user = await context.Users.FindAsync(Id);
        if(user == null) return NotFound();
        return user;
    }
}
