using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;


namespace boilerplate.Models
{
    public class Bidder
    {
        public int BidderId { get; set; }
        public int bidAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
    }
    public class BidderViewModel : BaseEntity
    {
        [Key]
        public int BidderId { get; set; }
        public int bidAmount { get; set; }
    }
}
