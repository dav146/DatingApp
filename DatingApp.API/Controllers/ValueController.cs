using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValueController:ControllerBase
    {
        private readonly DataContext _context;
        public ValueController(DataContext context)
        {
            _context = context;
        }
        //GET list
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        //GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.SingleOrDefaultAsync(x=>x.Id == id);
            return Ok(value);
        }
    }
}