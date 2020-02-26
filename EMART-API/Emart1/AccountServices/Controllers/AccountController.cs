using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountServices.Models;
using AccountServices.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository conn;
        public AccountController(IAccountRepository con)
        {
            conn = con;
        }
        [HttpPost]
        [Route("addb")]
        public IActionResult addb(Buyer item)
        {
            try
            {
                conn.addb(item);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpPost]
        [Route("adds")]
        public IActionResult adds(Seller items)
        {
            try
            {
                conn.adds(items);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("loginb/{name}/{pass}")]
        public IActionResult loginb(string name, string pass)
        {
            try
            {

                return Ok(conn.loginb(name, pass));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("login/{name}/{pass}")]
        public IActionResult logins(string name, string pass)
        {
            try
            {

                return Ok(conn.logins(name, pass));
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
    }
}