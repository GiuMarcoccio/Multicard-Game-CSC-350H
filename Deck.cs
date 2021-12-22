using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1_Multigame_Card
{
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank.ToString(), suit.ToString()));
                }
            }
        }

        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return topCard;
            }
            else
            {
                return null;
            }
        }

        public void Shuffle()
        {
            Card temp;
            Random rand = new Random();

            for (int i = cards.Count - 1; i >= 0; i--)
            {
                int randNumber = rand.Next(0, i);
                temp = cards[i];
                cards[i] = cards[randNumber];
                cards[randNumber] = temp;
            }
        }

        public int CardListCount()
        {
            return cards.Count;
        }

        public int CardListCount(List<Card> list)
        {
            return list.Count;
        }

        public Card Cut(int index)
        {
            if (cards.Count > 0)
            {
                List<Card> halfDeck1 = new List<Card>();
                List<Card> halfDeck2 = new List<Card>();

                for (int i = 0; i <= index; i++)
                    halfDeck1.Add(cards[i]);

                Console.WriteLine("\nFirst half of Deck at given index:\n");
                PrintDeck(halfDeck1);

                for (int i = index + 1; i < cards.Count; i++)
                    halfDeck2.Add(cards[i]);

                Console.WriteLine("\nSecond half of Deck at given index:\n");
                PrintDeck(halfDeck2);

            }

            else
                Console.WriteLine("\nFAILURE! DECK IS EMPTY\n");
            return null;
        }

        public void PrintDeck()
        {
            for (int i = 0; i < cards.Count; i++)
                Console.WriteLine("Card #" + (i + 1) + " rank and suit are " + cards[i].Rank + ", " + cards[i].Suit);
        }

        public void PrintDeck(List<Card> cardList)
        {
            for (int i = 0; i < cardList.Count; i++)
                Console.WriteLine("Card #" + (i + 1) + " rank and suit are " + cardList[i].Rank + ", " + cardList[i].Suit);
        }

        public void RemoveTJQK()
        {
             
            for (int i = 0; i < cards.Count; i++)
            {
                if (    cards[i].Rank == "Ten" ||
                        cards[i].Rank == "Jack"||
                        cards[i].Rank == "Queen"||
                        cards[i].Rank == "King" )
                {
                    cards.RemoveAt(i);
                    i--;
                }
                
            }
        }
    }
}
