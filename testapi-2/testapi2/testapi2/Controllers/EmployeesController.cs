using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapi2.DTOs;

namespace testapi2
{

    public class MyempClass
    {
        public int? EmpId { get; set; }
        //public int? Id { get; set; }
    }
    public class EmpClass2
    {
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly PostgresContext _context;

        public EmployeesController(PostgresContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetEmployees()
        {
            List<Employee> employees = await _context.Employees.ToListAsync();


            if (employees.Count > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto
                {
                    Message = "Employee List",
                    Success = true,
                    Payload = employees
                });
            }

            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
            {
                Message = "No Employee",
                Success = false,
                Payload = null
            });

        }

        // GET: api/employee/5
        [HttpPost("GetEmployeeById")]
        public async Task<ActionResult<ResponseDto>> GetEmployees([FromBody] MyempClass input)
        {
            if (input.EmpId == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "id error",
                    Success = false,
                    Payload = null
                });
            }

            var employee = await _context.Employees.Where(VALK => VALK.Id == input.EmpId).FirstOrDefaultAsync();

            if (employee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "No Employee",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = " employee info",
                Success = true,
                Payload = employee
            });
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<ResponseDto>> PutEmployee([FromBody] Employee input)
        {
            if (input.Id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = " id is null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Emp_name == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = " emp_name is null",
                    Success = false,
                    Payload = null
                });
            }

            //old 
            Employee employee = await _context.Employees.Where(i => i.Id == input.Id).FirstOrDefaultAsync();
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "this employee not listed your db",
                    Success = false,
                    Payload = null
                });
            }

            //new
            employee.Emp_name = input.Emp_name;
            employee.Dep_name = input.Dep_name;
            employee.Phone_number = input.Phone_number;
            employee.Email = input.Email;
            employee.Address = input.Address;
            employee.Birthdate = input.Birthdate;
            employee.Remarks = input.Remarks;
            employee.Photo = input.Photo; 
            _context.Employees.Update(employee);
            bool isSaved = await _context.SaveChangesAsync() > 0;

            if (isSaved == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Message = "updating Unsuccesfull",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "updating complete",
                Success = true,
                Payload = null
            });
        }

        //// POST: api/Countries
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<ResponseDto>> PostEmployee([FromBody] Employee input)
        {
            if (input.Emp_name == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = " name is null",
                    Success = false,
                    Payload = null
                });
            }

            //old
            Employee country = await _context.Employees.Where(i => i.Id == input.Id).FirstOrDefaultAsync();
            if (country != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto
                {
                    Message = "already exist",
                    Success = false,
                    Payload = null
                });
            }


            _context.Employees.Add(input);
            bool isSaved = await _context.SaveChangesAsync() > 0;

            if (isSaved == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Message = "creating error",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "creating done",
                Success = true,
                Payload = new { input.Id } // optional, can be null too like update
            });
        }

        // DELETE: api/Countries/5
        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<ResponseDto>> DeleteEmployee([FromBody] MyempClass input)
        {
            if (input.EmpId == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = " id is null",
                    Success = false,
                    Payload = null
                });
            }

            Employee employee = await _context.Employees.Where(i => i.Id == input.EmpId).FirstOrDefaultAsync();
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "not exist your db",
                    Success = false,
                    Payload = null
                });
            }

            _context.Employees.Remove(employee);
            bool isSaved = await _context.SaveChangesAsync() > 0;

            if (isSaved == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Message = "deleting error",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "deleted",
                Success = true,
                Payload = new { input.EmpId } // optional, can be null too like update
            });
        }

        private bool EmployeeExists(int? id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }












    }
}
