using Api_Test.Database;
using Api_Test.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration _configuration;

        public CourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost("CourseList")]
        public async Task<IActionResult> Enroll([FromBody] Course request)
        {
            try
            {

                if (request == null)
                    return BadRequest(" data is invalid");
                if (await dbContext.CourseDetail.AnyAsync(x => x.Title == request.Title))
                {
                    return BadRequest(" already Enrolled");
                }


                var studentnew = new Course
                {
                    Title = request.Title,
                    Description = request.Description,
                   
                };


                await dbContext.CourseDetail.AddAsync(studentnew);
                await dbContext.SaveChangesAsync();


                return Ok(new { message = "successful Added Please Refresh Page", stat = "200" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("CourseDetails")]
        public IActionResult SudentDetails()
        {

            try
            {
                var allEmployees = dbContext.CourseDetail.ToList();
                return Ok(allEmployees);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
