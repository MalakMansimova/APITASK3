using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.DAL;
using WEB_API.Entities.Dtos.Cars;
using WEB_API.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarDto>> GetById(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            GetCarDto carDto = _mapper.Map<GetCarDto>(car);

            return Ok(carDto);
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<GetCarDto>>> GetAll()
        {
          if(_context.Cars == null)return NotFound();
            var result = await _context.Cars.ToListAsync();
            List<GetCarDto> carDtos = _mapper.Map<List<GetCarDto>>(result);
            return carDtos;
        }

        [HttpPost]
        public async Task<ActionResult> AddCars([FromBody]CreateCarDto create)
        {


            Car car = _mapper.Map<Car>(create);

            car.ModelYear = DateTime.UtcNow;
        
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id ,UpdateCarDto update)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            Car car = _mapper.Map<Car>(update);
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return Ok(car);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Cars.FindAsync(id);
            if (result is null) { return NotFound(); }
            _context.Cars.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();

        }

        private bool ProductExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
