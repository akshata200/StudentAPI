using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Models
{
    public class Student
    {
        // primary key should be named as Id or classnameId, else specify if with annotation
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; } // CS IT Mech ENTC Elec

        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; } // First Second Third Fourth

        [Required(ErrorMessage = "Phone No. is required")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Enter a valid Email Address")]
        public string Email { get; set; }

    }

    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
    }
}
