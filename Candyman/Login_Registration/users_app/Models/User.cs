using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;

namespace users_app.Models
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
        public int age { get; set; }
 
        [Required]
        [EmailAddress]
        public string email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password")]
        // ErrorMessage="password does not match")
        public string confirm_password { get; set; }

        public User(string myFirstName, string myLastName, int myAge, string myEmail, string myPassword, string confirmPassword)
        {
            first_name = myFirstName;
            last_name = myLastName;
            age = myAge;
            email = myEmail;
            password = myPassword;
            confirm_password = confirmPassword;
        }
    }
    // public class Login
    // {
    //     [Required(ErrorMessage="Email already exists")]
    //     public string email { get; set; }

    //     [Required(ErrorMessage = "Field cannot be blank")]
    //     [DataType(DataType.Password)]
    //     public string password { get; set; }

    // }
    
}