using Api_Test.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Data.Common;

namespace Api_Test.Database
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enroll { get; set; }
        public DbSet<Course> CourseDetail { get; set; }



    }
}
