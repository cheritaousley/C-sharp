using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;

namespace bank_account.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int user_id { get; set; }
        public User User { get; set; }
    }
    public class TransactionViewModel : BaseEntity
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        // [Required, (ErrorMessage = "Name cannot be blank")]
        [MinLength(3)]
        public string Amount{ get; set; }

        [Required]
        // [Required, (ErrorMessage = "Date cannot be blank")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int user_id { get; set; }
    }
}
