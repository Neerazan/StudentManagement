using System.ComponentModel.DataAnnotations;

namespace Infomax.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student's name is required")]
        public string Name { get; set; }
        [Required, MinLength(10), MaxLength(15)]
        public string Phone { get; set; }
        [Required, RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        public Gender Gender { get; set; }

    }
}