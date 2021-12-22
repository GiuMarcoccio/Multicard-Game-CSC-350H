using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1_Multigame_Card
{
    public class TensBoard
    {
        Board board = new Board();
        Deck deck = new Deck();

        public void RemoveTJQK(List<Card> list)
        {
            bool T = false;
            bool J = false;
            bool Q = false;
            bool K = false;
            bool flag = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Rank == "Ten" && !T)
                    T = true;
                else if (list[i].Rank == "Jack" && !J)
                    J = true;
                else if (list[i].Rank == "Queen" && !Q)
                    Q = true;
                else if (list[i].Rank == "King" && !K)
                    K = true;
                else
                    continue;
            }

            if (T && J && Q && K)
            {
                string userTJQK;
                do
                {
                    Console.WriteLine("\nYou have a set of Ten, Jack, Queen and King! \nWould you like to take them out? \n");
                    Console.WriteLine("Answer (Y/N): ");
                    userTJQK = Console.ReadLine();
                } while (userTJQK != "Y" && userTJQK != "y" && userTJQK != "n" && userTJQK != "N");

                if (userTJQK == "n" || userTJQK == "N")
                    return;
                else
                {
                    do
                    {
                        T = false;
                        J = false;
                        Q = false;
                        K = false;

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Ten" && !T)
                            {
                                T = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Jack" && !J)
                            {
                                J = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Queen" && !Q)
                            {
                                Q = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "King" && !K)
                            {
                                K = true;
                                list.RemoveAt(i);
                            }
                        }

                        board.DealCards(4, list);
                        deck.PrintDeck(list);

                        Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                        Console.WriteLine("\n\tYour score is : " + board.Score);

                        flag = true;
                    } while (!flag);
                }
            }
        }
        public void PairMissedTens(List<Card> list, int cardValue)
        {
            //Checking if there is any pair that the user missed
            Console.WriteLine("\nPrinting pair of Cards that add up to 10...\n");

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1 + i; j < list.Count; j++)
                {
                    cardValue = list[i].getCardValue() + list[j].getCardValue();
                    if (cardValue == 10)
                        Console.WriteLine("Card " + (i + 1) + " has a value of " + list[i].getCardValue() +
                                            " and Card " + (j + 1) + " has a value of " + list[j].getCardValue() +
                                            " ==> " + list[i].getCardValue() + " + " + list[j].getCardValue() +
                                            " = " + cardValue + "\n");
                }
            }
        }
        public void PairTerminationTens(List<Card> list)
        {
            int counter = 0, cardValue;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1 + i; j < list.Count; j++)
                {
                    cardValue = list[i].getCardValue() + list[j].getCardValue();
                    if (cardValue == 10)
                        counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine(" \nNO PAIR AVALABLE. GAME OVER.\n" +
                                  " Number of Cards remaining in Deck: " + deck.CardListCount());
                System.Environment.Exit(0);
            }
        }
        public void TensGame(List<Card> list, int card1, int card2, int cardValue)
        {
            bool flag = false;
            // Repeat this task until user are not able to find two cards in the card list with total equals 10.
            do
            {
                Console.WriteLine("\nValue between cards selected is: " + cardValue + "\n");

                if (cardValue != 10)
                {
                    flag = true;

                    Console.WriteLine("\nValue has to be equal to 10!");

                    // Checking if there is any pair that the user missed
                    PairMissedTens(list, cardValue);

                    // Print the cards in the card list and the number of cards in the deck
                    deck.PrintDeck(list);

                    Console.WriteLine("\nUndealt Cards Remaining: " + deck.CardListCount());

                    System.Environment.Exit(0);
                }

                // Remove the two card from the list if the total value of the two cards equals to 10,
                // and then deal two more cards from the deck and fill the empty slots.
                else
                {
                    board.RemoveReplace(card1, card2, list);
                    board.scorePoint(1);
                }

                deck.PrintDeck(list);

                Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list))+ " Undealt Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + board.Score);

                RemoveTJQK(list);

                PairTerminationTens(list);

                board.UserCards(list, 13);

            } while (!flag);
        } 
    }
}
