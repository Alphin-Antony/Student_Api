using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Test.Model
{
    public class Enrollment
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

      

    }
}
