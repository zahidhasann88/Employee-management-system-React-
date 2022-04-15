using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapi2.DTOs;

namespace testapi2
{
    public class AmarClass1
    {
        public int? AmarId { get; set; }
        //public int? Id { get; set; }
    }
    public class AmarClass2
    {
        public int? AmarId { get; set; }
        public string AmarName { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        //    private readonly PostgresContext _context;

        //    public CountriesController(PostgresContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/Countries
        //    [HttpGet]
        //    public async Task<ActionResult<ResponseDto>> GetCountries()
        //    {
        //        List<Country> countries = await _context.Countries.ToListAsync();

        //        //bool isRowCountValid = countries.Count > 0;
        //        //return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto
        //        //{
        //        //    Message = isRowCountValid ? "Amar country list" : "kono country nai",
        //        //    Success = isRowCountValid,
        //        //    Payload = isRowCountValid ? countries : null
        //        //});

        //        if (countries.Count > 0)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, new ResponseDto
        //            {
        //                Message = "Amar country list",
        //                Success = true,
        //                Payload = countries
        //            });
        //        }

        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
        //        {
        //            Message = "kono country nai",
        //            Success = false,
        //            Payload = null
        //        });

        //    }
        //    //public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        //    //{
        //    //    return await _context.Countries.ToListAsync();
        //    //}

        //    // GET: api/Countries/5
        //    [HttpPost("GetCountryById")]
        //    public async Task<ActionResult<ResponseDto>> GetCountry([FromBody] AmarClass1 input)
        //    {
        //        if (input.AmarId == null)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
        //            {
        //                Message = "id vul ase",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        var country = await _context.Countries.Where(VALK => VALK.Id == input.AmarId).FirstOrDefaultAsync();

        //        if (country == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
        //            {
        //                Message = "kono country nai",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        return StatusCode(StatusCodes.Status200OK, new ResponseDto
        //        {
        //            Message = " country info",
        //            Success = true,
        //            Payload = country
        //        });
        //    }

        //    // PUT: api/Countries/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost("UpdateCounty")]
        //    public async Task<ActionResult<ResponseDto>> PutCountry([FromBody] AmarClass2 input)
        //    {
        //        if (input.AmarId == null)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
        //            {
        //                Message = " id null ase",
        //                Success = false,
        //                Payload = null
        //            });
        //        }
        //        if (input.AmarName == null)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
        //            {
        //                Message = " name null ase",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        //old 
        //        Country country = await _context.Countries.Where(i => i.Id == input.AmarId).FirstOrDefaultAsync();
        //        if (country == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
        //            {
        //                Message = "db te country nai",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        //new
        //        country.Names = input.AmarName;
        //        _context.Countries.Update(country);
        //        bool isSaved = await _context.SaveChangesAsync() > 0;

        //        if (isSaved == false)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
        //            {
        //                Message = "update kora jaassey na",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        return StatusCode(StatusCodes.Status200OK, new ResponseDto
        //        {
        //            Message = "update kora sesh",
        //            Success = true,
        //            Payload = null
        //        });
        //    }

        //    // POST: api/Countries
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost("CreateCountry")]
        //    public async Task<ActionResult<ResponseDto>> PostCountry([FromBody] Country input)
        //    {
        //        if (input.Id == null)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
        //            {
        //                Message = " id null ase",
        //                Success = false,
        //                Payload = null
        //            });
        //        }
        //        if (input.Names == null)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
        //            {
        //                Message = " name null ase",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        //old 
        //        //Country country = await _context.Countries.Where(i => i.Id == input.Id).FirstOrDefaultAsync();
        //        //if (country != null)
        //        //{
        //        //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto
        //        //    {
        //        //        Message = "db te already assey",
        //        //        Success = false,
        //        //        Payload = null
        //        //    });
        //        //}


        //        _context.Countries.Add(input);
        //        bool isSaved = await _context.SaveChangesAsync() > 0;

        //        if (isSaved == false)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
        //            {
        //                Message = "create kora jaassey na",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        return StatusCode(StatusCodes.Status200OK, new ResponseDto
        //        {
        //            Message = "create kora sesh",
        //            Success = true,
        //            Payload = new { input.Id } // optional, can be null too like update
        //        });
        //    }

        //    // DELETE: api/Countries/5
        //    [HttpPost("DeleteCountry")]
        //    public async Task<ActionResult<ResponseDto>> DeleteCountry([FromBody] AmarClass1 input)
        //    {
        //        if (input.AmarId == null)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
        //            {
        //                Message = " id null ase",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        Country country = await _context.Countries.Where(i => i.Id == input.AmarId).FirstOrDefaultAsync();
        //        if (country == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
        //            {
        //                Message = "db te country nai",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        _context.Countries.Remove(country);
        //        bool isSaved = await _context.SaveChangesAsync() > 0;

        //        if (isSaved == false)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
        //            {
        //                Message = "delete kora jaassey na",
        //                Success = false,
        //                Payload = null
        //            });
        //        }

        //        return StatusCode(StatusCodes.Status200OK, new ResponseDto
        //        {
        //            Message = "delete kora sesh",
        //            Success = true,
        //            Payload = new { input.AmarId } // optional, can be null too like update
        //        });
        //    }

        //    private bool CountryExists(int? id)
        //    {
        //        return _context.Countries.Any(e => e.Id == id);
        //    }












        //}
    }
}
