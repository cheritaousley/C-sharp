using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace boilerplate.Models
{

    public class User : BaseEntity

    {
        [Key]
        public int UserId { get; set; }
        public string first_name { get; set; }

        public string last_name { get; set; }

        public string username { get; set; }

        public int age { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public int wallet { get; set; }
        
        public List<Bidder> Auction { get; set; }
        public User()
        {
            wallet = 1000;
            Auction = new List<Bidder>();
        }
    }
    //<------------------------------------------------------------------------------------------->//
    public class RegisterViewModel : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(3)]
        public string first_name { get; set; }

        [Required]
        [MinLength(3)]
        public string last_name { get; set; }

        [Required]
        [MinLength(3)]
        public string username { get; set; }

        [Required]
        [Range(18, 64)]
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
        public int wallet { get; set; }

        public string created_at { get; set; }
        public string updated_at { get; set; }

    }
    //<------------------------------------------------------------------------------------------->//
    public class LoginViewModel : BaseEntity
    {
        [Required]
        public string loginEmail { get; set; }  // will later change this to username
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
        public string loginPassword { get; set; }
    }
    //<------------------------------------------------------------------------------------------->//

    //This is a WRAPPER! Includes both view models
    public class LoginRegViewModel : BaseEntity
    {
        public LoginViewModel loginVM { get; set; }
        public RegisterViewModel registerVM { get; set; }
        
    }

}