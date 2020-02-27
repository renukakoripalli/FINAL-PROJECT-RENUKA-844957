using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerServices.Models;
using BuyerServices.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyer _repo;
        public BuyerController(IBuyer repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult BuyItem(Purchase item)
        {
            try
            {
                _repo.BuyItem(item);
                return Ok();

            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpPut]
        [Route("Edit")]
        public IActionResult EditProfile(Buyer buyer)
        {
            try
            {
                _repo.Editprofile(buyer);
                return Ok();

            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("get/{Bid}")]
        public IActionResult Getprofile(string Bid)
        {
            try
            {

                return Ok(_repo.GetProfile(Bid));

            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            try
            {

                return Ok(_repo.Getall());

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("Search/{Iname}")]
        public IActionResult SearchItems(string Iname)
        {
            try
            {
                return Ok(_repo.search(Iname));


            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("History/{Bid}")]
        public IActionResult TransactionHistory(string Bid)
        {
            try
            {

                return Ok(_repo.PurchaseHistory(Bid));

            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetC")]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_repo.GetCategories());



            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetS/{categoryid}")]
        public IActionResult GetSubCategories(string categoryid)
        {
            try
            {
                return Ok(_repo.GetSubCategories(categoryid));


            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }

        }
    }
}
