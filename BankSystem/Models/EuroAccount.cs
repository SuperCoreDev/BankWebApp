﻿using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class EuroAccount : IAccount
    {
        [Key]
        [RegularExpression("^[0-9]*$")]
        public string AccountNumber { get; set; }

        [Required]
        public double Funds { get; set; }

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public string IDnumberFK { get; set; }

        // One-to-many relationship with EuroAccountHistory
        public List<EuroAccountHistory> EuroTransaction { get; set; }

        // One-to-many relationship with Transfers
        public List<Transfer> Transfers { get; set; }
    }
}
