using BackendAPI.Models;
using BackendAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace BackendAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BodyStylesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BodyStylesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bodyStyles = await _context.BodyStyles.ToListAsync();
            return Ok(bodyStyles);
        }



    }


}
