using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1_Multigame_Card
{
    public class Card
    {
        string rank;
        string suit;
        bool faceUp;

        public Card(string rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
            faceUp = false;
        }
        // String property
        public string Rank
        {
            get { return rank; }
        }
        // String propertie
        public string Suit
        {
            get { return suit; }
        }
        // bool property
        public bool FaceUp
        {
            get { return faceUp; }
        }
        // Function to flip card over
        public void FlipOver()
        {
            faceUp = !faceUp;
        }

        public int getCardValue()
        {
            return ((int)System.Enum.Parse(typeof(Rank), Rank) + 1);
        }
    }
}
