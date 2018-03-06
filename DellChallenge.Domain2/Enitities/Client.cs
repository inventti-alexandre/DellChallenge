
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellChallenge.Domain.Enitities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Classification Classification { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime LastPurchase { get; set; }
        public User Seller { get; set; }
       
    }
}
