using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WEB_API.DAL;
using WEB_API.Entities;
using WEB_API.Entities.Dtos.Colors;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ColorsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetColorDto>> GetById(int id)
        {
            var color = await _context.Colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            GetColorDto colorDto = _mapper.Map<GetColorDto>(color);

            return Ok(colorDto);
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<GetColorDto>>> GetAll()
        {
            var result = await _context.Colors.ToListAsync();
            if (result.Count == 0) { return NotFound(); }
            List<GetColorDto> colors = _mapper.Map<List<GetColorDto>>(result);
            return Ok(colors);
        }
        [HttpPost]
        public async Task<ActionResult> AddColors(CreateColorDto create)
        {
            Color color = _mapper.Map<Color>(create);
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateColorDto update)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            Color color = _mapper.Map<Color>(update);
            _context.Colors.Update(color);
            await _context.SaveChangesAsync();
            return Ok(color);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Colors.FindAsync(id);
            if (result is null) {  return NotFound(); }
            _context.Colors.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();

        }
        private bool ProductExists(int id)
        {
            return (_context.Colors?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
