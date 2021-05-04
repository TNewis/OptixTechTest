using OptixTechTest.Models;
using OptixTechTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptixTechTest.Services
{
    public class DealerService : IDealerService
    {
        private Deck Deck { get; set; }

        public DealerService()
        {
            this.Deck = new Deck();
            NewDeck();
        }

        public Deck NewDeck()
        {
            this.Deck.Cards.Clear();

            foreach(EnumSuit suit in Enum.GetValues(typeof(EnumSuit)))
            {
                foreach (EnumValue value in Enum.GetValues(typeof(EnumValue)))
                {
                    this.Deck.Cards.Add(new Card { Suit=suit, Value= value });
                }
            }

            return Deck;
        }

        public Deck GetCurrentDeck()
        {
            return Deck;
        }
    }
}
