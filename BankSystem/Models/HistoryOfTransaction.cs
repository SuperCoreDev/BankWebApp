﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class HistoryOfTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue("Standard trasaction")]
        public string Title { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public string BeneficiaryAccount { get; set; }

        // Many-to-one relationships with Accounts


        public string DollarAccountFK { get; set; }
        public DollarAccount DollarAcc { get; set; }

        public string PoundAccountFK { get; set; }
        public PoundAccount PoundAcc { get; set; }

        // One-to-one relationship with Transfers
        public int TransferFK { get; set; }
        public Transfer _Transfer { get; set; }
    }
}
