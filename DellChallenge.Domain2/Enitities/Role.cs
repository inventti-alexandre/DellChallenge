using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallenge.Domain.Enitities
{
    public class Role
    {
        public Role(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
