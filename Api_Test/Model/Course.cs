using System.ComponentModel.DataAnnotations;

namespace Api_Test.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

       
    }
}
