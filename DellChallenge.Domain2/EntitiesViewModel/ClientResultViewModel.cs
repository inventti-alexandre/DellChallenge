
using System;

namespace DellChallenge.Domain.EntitiesViewModel
{
    public class ClientResultViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Classification { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime LastPurchase { get; set; }

    }
}
