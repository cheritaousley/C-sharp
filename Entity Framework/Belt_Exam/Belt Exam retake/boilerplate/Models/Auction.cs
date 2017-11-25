using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace boilerplate.Models
{
    public class Auction : BaseEntity
    {
        [Key]
        public int AuctionId { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public DateTime date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Bidder> Bidder { get; set; }
        public Auction()
        {
            Bidder = new List<Bidder>();
        }

    }
    public class AuctionViewModel : BaseEntity
    {
        [Key]
        public int AuctionId { get; set; }

        [Required]
        [MinLength(3)]
        public string product_name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string description { get; set; }

        [Required]
        [Range(1, 1000)]
        public double price { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User{ get; set; }
       
    }
    // public class AuctionUserViewModel : BaseEntity
    // {
    //     public AuctionViewModel invitationVM { get; set; } //adding these two models in a wrapper allows me to see all the data on the same page
        
    // }
}
