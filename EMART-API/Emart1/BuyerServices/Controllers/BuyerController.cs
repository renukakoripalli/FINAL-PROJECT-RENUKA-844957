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
        [HttpPost]
        [Route("BuyItem")]
        public IActionResult Buy(Purchase buy)
        {
            try
            {
                _repo.BuyItem(buy);
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
        [Route("get/{bid}")]
        public IActionResult Getprofile(string bid)
        {
            try
            {

                return Ok(_repo.GetProfile(bid));

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
        [Route("Search/{itemname}")]
        public IActionResult SearchItems(string itemname)
        {
            try
            {
                return Ok(_repo.search(itemname));


            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("History/{bid}")]
        public IActionResult TransactionHistory(string bid)
        {
            try
            {

                return Ok(_repo.PurchaseHistory(bid));

            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        //[HttpGet]
       // [Route("GetC/{categoryid}")]
       // public IActionResult GetCategory(string categoryid)
       // {
          //  try
           // {
               // return Ok(_repo.GetCategory(categoryid));



            //}
            //catch (Exception e)
            //{
            //    return NotFound(e.InnerException.Message);
            //}
        //}
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
        [HttpGet]
        [Route("Getallitems")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAllItems());
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("Searchbycategoryid/{categoryid}")]
        public IActionResult SearchByCategoryId(string categoryid)
        {
            try
            {
                return Ok(_repo.SearchByCategoryId(categoryid));
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("Getcategory")]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_repo.GetCategories());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
         [HttpPost]
        [Route("Addtocart")]
        public IActionResult AddToCart(Cart cart)
        {
            try
            {
               _repo.AddToCart(cart);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("Getcartitems")]
        public IActionResult GetCartItems()
        {
            try
            {
                return Ok(_repo.GetCartItems());
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("Removeitem/{Cartid}")]
        public IActionResult DeleteCartItem(string Cartid)
        {
            try
            {
                _repo.DeleteCartItem(Cartid);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("getcart/{Cartid}")]
        public IActionResult GetCartbyid(string Cartid)
        {
            try
            {
                return Ok(_repo.Getcartitembyid(Cartid));

            }
            catch(Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
    }
}
