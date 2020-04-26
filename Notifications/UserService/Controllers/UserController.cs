using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Repositories;


namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserDetails user)
        {
            try
            {
                _repo.UserRegister(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("Login/{uname}/{pwd}")]
        public IActionResult Login(string uname, string pwd)
        {
            try
            {
                UserDetails user = _repo.UserLogin(uname, pwd);
                if (user == null)
                    return Ok("Invalid User");
                else
                    return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(UserDetails user)
        {
            try
            {
                _repo.UpdateProfile(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("ViewProfile/{id}")]
        public IActionResult GetProfile(string id)
        {
            try
            {

                return Ok(_repo.ViewProfile(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}