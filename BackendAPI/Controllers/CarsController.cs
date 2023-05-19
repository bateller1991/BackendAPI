using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{bodyStyleId}")]
        public async Task<IActionResult> GetByBodyStyle(int bodyStyleId)
        {
            var cars = await _context.Cars.Where(c => c.BodyStyleID == bodyStyleId).ToListAsync();
            return Ok(cars);
        }

    }

}
