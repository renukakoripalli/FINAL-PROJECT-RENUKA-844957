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
        [Route("AddCategoires")]
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
                return NotFound(e.InnerException.Message);
            }
        }
    }
}