using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace boilerplate.Models
{
    public class Connection
    {
        [Key]
        public int ConnectionId { get; set; }
        
        [ForeignKey("User")]
        public int LeftId { get; set; }
        public User Left { get; set; } //sending
        
        [ForeignKey("User")]
        public int RightId { get; set; }
        public User Right { get; set; } //accepting
        
        public bool Status { get; set; }
        public Connection()
        {
            Status = false; //automatically happens when make a new connection
        }
    }
    public class ConnectionViewModel : BaseEntity
    {
        [Key]
        public int ConnectionId { get; set; }

        [Required]
        [MinLength(3)]
        public string first_name { get; set; }

        [Required]
        [MinLength(3)]
        public string last_name { get; set; }

        [Required]
        public int UserId { get; set; } //This is how i am calling on the User's id, I am calling it 'user_id' in this table, and by using object 'User' itknows to grab the id out that table and call it 'user_id' over in this table//This name does not have to match the name in the User table
        public User User { get; set; }
    }
    // public class ConnectionUserViewModel : BaseEntity
    // {
    //     public ConnectionViewModel invitationVM { get; set; } //adding these two models in a wrapper allows me to see all the data on the same page
        
    // }
}
