using System;
using EMart.AccountService.Repositories;
using EMart.AccountService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMart.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        public AccountController(IAccountRepository rep)
        {
            _repo = rep;
        }
        [HttpPost]
        [Route("RegBuyer")]
        public IActionResult BuyerRegister(Buyer obj)
        {
            try
            {
                _repo.BuyerRegister(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpPost]
        [Route("RegSeller")]
        public IActionResult SellerRegister(Seller obj)
        {
            try
            {
                _repo.SellerRegister(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("BuyerLogin/{username}/{password}")]
        public IActionResult BuyerLogin(string username, string password)
        {
            try
            {
                return Ok(_repo.BuyerLogin(username, password));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("SellerLogin/{username}/{password}")]
        public IActionResult SellerLogin(string username, string password)
        {
            try
            {
                return Ok(_repo.SellerLogin(username, password));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

    }
}