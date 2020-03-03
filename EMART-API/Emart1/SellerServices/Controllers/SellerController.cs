using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellerServices.Models;
using SellerServices.Repositories;

namespace SellerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _repo;
        public SellerController(ISellerRepository rep)
        {
            _repo = rep;
        }
        [HttpPut]
        [Route("EditProfile")]
        public IActionResult EditProfile(Seller obj)
        {
            try
            {
                _repo.EditProfile(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetProfile/{sid}")]
        public IActionResult GetProfile(string sid)
        {
            try
            {
                return Ok(_repo.GetProfile(sid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }


    }
}