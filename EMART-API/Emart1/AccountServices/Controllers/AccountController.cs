using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AccountServices.Models;
using AccountServices.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AccountServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        private readonly IConfiguration configuration;
        public AccountController(IAccountRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            this.configuration = configuration;
        }
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
        private Token GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role,username)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var response = new Token
            {
                username = username,
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }

    }
}