using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskking.Interfaces;
using Taskking.Models;

namespace Taskking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase

    {
    readonly IUserService UserService;
    public UserController(IUserService UserService)
    {
        this.UserService = UserService;
    }
//to get all users - only admin
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return UserService.GetAll();
    }



    [HttpPost]
    public IActionResult Post(User newUser)
    {
        var newId = UserService.Post(newUser);
        return CreatedAtAction(nameof(Post), new { id = newId }, newUser);
    }


    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {

        UserService.Delete(id);
        return Ok();
    }
    }
}
