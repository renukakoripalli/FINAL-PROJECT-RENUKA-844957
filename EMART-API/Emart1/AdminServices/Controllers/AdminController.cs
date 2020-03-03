using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminServices.Models;
using AdminServices.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _conn;
        public AdminController(IAdminRepository con)
        {
            _conn = con;
        }
        [HttpPost]
        [Route("AddCategories")]
        public IActionResult AddCategories(Category cat)
        {
            try
            {
                _conn.AddCategories(cat);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("Deletecategory/{categoryid}")]
        public IActionResult DeleteCategory(string categoryid)
        {
            try
            {
                _conn.DeleteCategory(categoryid);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_conn.GetCategories()
                );
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("Deletesubcategory/{subcategoryid}")]
        public IActionResult DeleteSubCategory(string subcategoryid)
        {
            try
            {
                _conn.DeleteSubCategory(subcategoryid);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("AddSubCategories")]
        public IActionResult AddSubCategories(Subcategory scat)
        {
            try
            {
                _conn.AddSubCategories(scat);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("Viewcategory")]
        public IActionResult Viewcategory()
        {
            try
            {
                return Ok(_conn.ViewCategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("Viewsubcategory")]
        public IActionResult Viewsubcategory()
        {
            try
            {
                return Ok(_conn.ViewSubCategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}