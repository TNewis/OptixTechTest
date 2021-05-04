using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptixTechTest.Models
{
    public class Deck
    {
        public ICollection<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }
    }
}
