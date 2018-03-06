using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellChallenge.Domain.Enitities
{
    public class Classification
    {

        public Classification(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
