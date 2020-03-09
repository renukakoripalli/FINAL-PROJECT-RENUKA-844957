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
        [HttpGet]
        [Route("Getbycatid/{categoryid}")]
        public IActionResult GetCat(string categoryid)
        {
            try
            {
                return Ok(_conn.Getbycatid(categoryid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("Getbyscatid/{subcategoryid}")]
        public IActionResult GetSubcat(string subcategoryid)
        {
            try
            {
                return Ok(_conn.Getbyscatid(subcategoryid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("EditCategory")]
        public IActionResult Editcategory(Category category)
        {
            try
            {
                _conn.EditCategory(category);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpPut]
        [Route("EditSubcategory")]
        public IActionResult Editsubcategory(Subcategory subcategory)
        {
            try
            {
                _conn.EditSubcategory(subcategory);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
    }
}