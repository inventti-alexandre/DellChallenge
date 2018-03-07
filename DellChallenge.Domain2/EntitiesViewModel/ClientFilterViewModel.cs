
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellChallenge.Domain.EntitiesViewModel
{
    public class ClientFilterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int ClassificationId { get; set; }
        public int SellerId { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime LastPurchase { get; set; }
        public DateTime LastPurchaseUntil { get; set; }
        public List<ClientResultViewModel> Clients { get; set; }

    }
}
