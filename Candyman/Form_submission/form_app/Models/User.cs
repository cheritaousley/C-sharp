using System.ComponentModel.DataAnnotations;
// using form_app.Models;

namespace form_app.Models
{
    public class User
    
    {
        [Required]
        [MinLength(3)]
        public string first_name { get; set; }

        [Required]
        [MinLength(3)]
        public string last_name { get; set; }

        [Required]
        [Range(18,64)]
        public int Age { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User(string fname, string lname, int age, string email, string password)
        {
            first_name = fname;
            last_name = lname;
            Age = age;
            Email = email;
            Password = password;
        }
    }
    
}