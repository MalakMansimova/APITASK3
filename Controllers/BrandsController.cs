using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API.DAL;
using WEB_API.Entities;
using WEB_API.Entities.Dtos.Brand;
using WEB_API.Entities.Dtos.Cars;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BrandsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBrandDto>> GetById(int id)
        {
            var color = await _context.Brands.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            GetBrandDto brandDto = _mapper.Map<GetBrandDto>(color);


            return Ok(brandDto);
        }
        [HttpGet]

        public async Task<ActionResult<GetBrandDto>> GetAll()
        {
            var result = await _context.Brands.ToListAsync();
            if (result.Count == 0) { return NotFound(); }
            List<GetBrandDto> brandDtos = _mapper.Map<List<GetBrandDto>>(result);

            return Ok(brandDtos);
        }
        [HttpPost]
        public async Task<ActionResult> AddBrands([FromBody] CreateBrandDto create)
        {
            Brand brand = _mapper.Map<Brand>(create);
          
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id ,UpdateBrandDto update)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            Brand brand = _mapper.Map<Brand>(update);
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return Ok(brand);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Brands.FindAsync(id);
            if (result is null) { return NotFound(); }
            _context.Brands.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();

        }
        private bool ProductExists(int id)
        {
            return (_context.Brands?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
