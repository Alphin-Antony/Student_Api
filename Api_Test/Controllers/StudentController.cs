using Api_Test.Database;
using Api_Test.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration _configuration;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost("Student")]
        public async Task<IActionResult> Student([FromBody] Student request)
        {
            try
            {

                if (request == null)
                    return BadRequest("Student data is invalid");
                if (string.IsNullOrWhiteSpace(request.Name))
                    return BadRequest("Name is required");
                if (string.IsNullOrWhiteSpace(request.Email))
                    return BadRequest("Email is required");

                if (await dbContext.Students.AnyAsync(x => x.Email == request.Email))
                {
                    return BadRequest(" already registered");
                }


                var studentnew = new Student
                {
                    Name = request.Name,
                    Email = request.Email,
                  


                };


                await dbContext.Students.AddAsync(studentnew);
                await dbContext.SaveChangesAsync();


                return Ok(new { message = "successful Add", stat = "200" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("StudentDetails")]
        public IActionResult SudentDetails()
        {

            try
            {
                var allEmployees = dbContext.Students.ToList();
                return Ok(allEmployees);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }




    }
}
