using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallenge.Domain.Enitities
{
    public class City
    {
        private int v;

        public City(int id)
        {
            Id = id;
        }

        public City(int id, string desc)
        {
            Id = id;
            Description = desc;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}

