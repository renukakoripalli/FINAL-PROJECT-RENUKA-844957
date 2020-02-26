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
        [Route("DeleteItem/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _repo.DeleteItem(id);
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
        [Route("ViewItems/{sid}")]


        public IActionResult ViewItems(string sid)
        {
            try
            {

                return Ok(_repo.ViewItems(sid));
               
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }


    }
}