using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1_Multigame_Card
{
    public class Board
    {
        Deck deck = new Deck();
        
        public int card1, card2, cardValue = 0, score = 0;
        
        // Getting User Cards
        public void UserCards(List<Card> list, int max)
        {
            Console.WriteLine("\n\nPlease, select two cards from the list.");

            do
            {
                Console.Write("\nCard #1: ");
                card1 = Convert.ToInt32(Console.ReadLine());
            } while (card1 < 1 || card1 > max);

            do
            {
                Console.Write("\nCard #2: ");
                card2 = Convert.ToInt32(Console.ReadLine());
            } while (card2 < 1 || card2 > max || card1 == card2);

            cardValue = list[card1 - 1].getCardValue();

            cardValue += list[card2 - 1].getCardValue();
        }

        // Dealing Cards using NumCards as number of cards from specific game
        public void DealCards(int NumCards, List<Card> list)
        {
            // Shuffling the deck
            Console.WriteLine("Shuffling Deck...\n");
            deck.Shuffle();

            Console.WriteLine("\nDealing " + NumCards + " cards to new list card...\n");

            if (deck.CardListCount() >= NumCards)
            {
                for (int i = 0; i < NumCards; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
            }
                
            else if (deck.CardListCount() >= NumCards - 1)
            {
                for (int i = 0; i < NumCards - 1; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
                Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + Score);
            }
                
            else if (deck.CardListCount() >= NumCards - 2)
            {
                for (int i = 0; i < NumCards - 2; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
                Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + Score);
            }

            else if (deck.CardListCount() >= NumCards - 3) 
            { 
                for (int i = 0; i < NumCards - 3; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
                Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + Score);
            }
            else
                Console.WriteLine("\nDeck Empty\n");

            


        }

        // Removing and Replacing cards after user choice
        public void RemoveReplace(int card1, int card2, List<Card> list)
        {
            if (card1 > card2)
            {
                list.RemoveAt(card1 - 1);

                if (deck.CardListCount(list) == 1)
                    HasWon();
                else
                    list.RemoveAt(card2 - 1);
            }
            else
            {
                list.RemoveAt(card1 - 1);

                if (card2 == 2)
                {
                    if (deck.CardListCount(list) == 1)
                        HasWon();
                    else
                        list.RemoveAt(card2 - 2);
                }
                else
                    list.RemoveAt(card2 - 2);
            }

            for (int i = 11; i < 13; i++)
            {
                if (deck.CardListCount() >= 2)
                {
                    list.Add(deck.TakeTopCard());
                }
                else if (deck.CardListCount() >= 1)
                {
                    list.Add(deck.TakeTopCard());
                    break;
                }
                else
                    break;

            }

        }

        // Function that execute once the user has won 
        public void HasWon()
        {
            Console.WriteLine("\n\tYour score is : " + Score);
            Console.WriteLine("\nYOU WIN THIS GAME! CONGRATULATIONS :D\n");
            System.Environment.Exit(0);
        }
        public int CardsRemaining
        {
            get { return deck.CardListCount(); }
        }
        public int Score
        {
            get { return score; }
        }
        public void scorePoint(int point)
        {
            score += point;
        }

        public void resetGame()
        {

        }
    }
}
