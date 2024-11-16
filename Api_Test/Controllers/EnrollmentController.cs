using Api_Test.Database;
using Api_Test.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration _configuration;

        public EnrollmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost("Enrollment")]
        public async Task<IActionResult> Enroll([FromBody] Enrollment request)
        {
            try
            {

                if (request == null)
                    return BadRequest(" data is invalid");
               
                if (await dbContext.Enroll.AnyAsync(x => x.Id == request.Id))
                {
                    return BadRequest(" already Enrolled");
                }


                var studentnew = new Enrollment
                {
                    CourseId = request.CourseId,
                    EnrollmentDate = request.EnrollmentDate,
                   
                    StudentId = request.StudentId,
                };


                await dbContext.Enroll.AddAsync(studentnew);
                await dbContext.SaveChangesAsync();


                return Ok(new { message = "successful Register", stat = "200" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("EnrollmentDetails")]
        public IActionResult SudentDetails()
        {

            try
            {
                var allEmployees = dbContext.Enroll.ToList();
                return Ok(allEmployees);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
