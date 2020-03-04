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
        private readonly IAccountRepository conn;
        private readonly IConfiguration configuration;
        public AccountController(IAccountRepository con, IConfiguration configuration)
        {
            conn = con;
            this.configuration = configuration;
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
        [Route("logins/{username}/{pass}")]
        
        public IActionResult SellerLogin(string username, string pass)
        {
            Token token = null;
            try
            {
                Seller seller = conn.logins(username,pass);
                if (seller != null)
                {
                    token = new Token() { SellerId = seller.Sid, token = GenerateJwtToken(username), msg = "Success" };
                }

                else
                {
                    token = new Token() { token = "", msg = "Unsuccess" };
                }
                return Ok(token);
                //return Ok(_repo.BuyerLogin(uname,pwd));
            }

            catch (Exception e)
            {
                return NotFound(e.Message);

            }

        }
        [HttpGet]
        [Route("loginb/{username}/{pass}")]
        public IActionResult BuyerLogin(string username, string pass)
        {
            Token token = null;
            try
            {
                Buyer buyer = conn.BuyerLogin(username, pass);
                if (buyer != null)
                {
                    token = new Token() {Bid = buyer.Bid, token = GenerateJwtToken(username), msg = "Success" };
                }

                else
                {
                    token = new Token() { token = "", msg = "Unsuccess" };
                }
                return Ok(token);
                //return Ok(_repo.BuyerLogin(uname,pwd));
            }

            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);

            }

        }
        private string GenerateJwtToken(string username)
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

            //var response = new Token
            //{
            //    username = username,
            //    token = new JwtSecurityTokenHandler().WriteToken(token)
            //};
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}