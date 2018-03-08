using DellChallenge.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallenge.Domain.Enitities
{
    public class Region
    { 
        public Region(int regionId)
        {
            Id = regionId;
        }

        public Region(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public Region(int regionId, City city)
        {
            Id = regionId;
            City = city;
        }

        public Region(int id, string description, City city)
        {
            Id = id;
            Description = description;
            City = city;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
    }
}
