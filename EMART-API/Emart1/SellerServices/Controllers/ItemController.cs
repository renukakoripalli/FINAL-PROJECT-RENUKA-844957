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
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository rep)
        {
            _repo = rep;
        }
        [HttpPost]
        [Route("AddItem")]
        public IActionResult Post(Items obj)
        {
            try
            {
                _repo.AddItem(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteItem/{Iid}")]
        public IActionResult Delete(string Iid)
        {
            try
            {
                _repo.DeleteItem(Iid);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }

        }
        [HttpPut]
        [Route("Update")]
        public IActionResult put(Items obj)
        {
            try
            {
                _repo.UpdateItem(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetItems/{Iid}")]
        public IActionResult GetItems(string Iid)
        {
            try
            {
                return Ok(_repo.GetItems(Iid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("Viewitems/{id}")]
        public IActionResult ViewItems(string id)
        {
            try
            {
                return Ok(_repo.Viewitems(id));
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("Getsubcategory/{categoryid}")]
        public IActionResult Getsubcategory(string categoryid)
        {
            try
            {
                return Ok(_repo.GetSubCagegory(categoryid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("Getcategory")]
        public IActionResult Getcategory()
        {
            try
            {
                return Ok(_repo.GetCategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


    }
}