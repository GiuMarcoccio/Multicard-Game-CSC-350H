using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1_Multigame_Card
{
    public class ElevensBoard
    {
        Board board = new Board();
        Deck deck = new Deck();

        public void RemoveJQK(List<Card> list)
        {
            bool J = false;
            bool Q = false;
            bool K = false;
            bool flag = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Rank == "Jack" && !J)
                    J = true;
                else if (list[i].Rank == "Queen" && !Q)
                    Q = true;
                else if (list[i].Rank == "King" && !K)
                    K = true;
                else
                    continue;
            }

            if (J && Q && K)
            {
                string userJQK;
                do
                {
                    Console.WriteLine("\nYou have a set of Jack, Queen and King! \nWould you like to take them out? \n");
                    Console.WriteLine("Answer (Y/N): ");
                    userJQK = Console.ReadLine();
                } while (userJQK != "Y" && userJQK != "y" && userJQK != "n" && userJQK != "N");

                if (userJQK == "n" || userJQK == "N")
                    return;
                else
                {
                    do
                    {
                        J = false;
                        Q = false;
                        K = false;

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

                        board.DealCards(3, list);
                        deck.PrintDeck(list);

                        Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                        Console.WriteLine("\n\tYour score is : " + board.Score);

                        flag = true;
                    } while (!flag);
                }
            }
        }
        public void PairTerminationElevens(List<Card> list)
        {
            int counter = 0, cardValue;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1 + i; j < list.Count; j++)
                {
                    cardValue = list[i].getCardValue() + list[j].getCardValue();
                    if (cardValue == 11)
                        counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine(" \nNO PAIR AVALABLE. GAME OVER.\n" +
                                  " Number of Cards remaining in Deck: " + deck.CardListCount());

                deck.PrintDeck(list);
                System.Environment.Exit(0);
            }
        }

        public void PairMissedElevens(List<Card> list, int cardValue)
        {
            //Checking if there is any pair that the user missed
            Console.WriteLine("\nPrinting pair of Cards that add up to 11...\n");

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1 + i; j < list.Count; j++)
                {
                    cardValue = list[i].getCardValue() + list[j].getCardValue();
                    if (cardValue == 11)
                        Console.WriteLine("Card " + (i + 1) + " has a value of " + list[i].getCardValue() +
                                            " and Card " + (j + 1) + " has a value of " + list[j].getCardValue() +
                                            " ==> " + list[i].getCardValue() + " + " + list[j].getCardValue() +
                                            " = " + cardValue + "\n");
                }
            }
        }
        public void ElevensGame(List<Card> list, int card1, int card2, int cardValue)
        {
            bool flag = false;
            // Repeat this task until user are not able to find two cards in the card list with total equals 10.
            do
            {
                Console.WriteLine("\nValue between cards selected is: " + cardValue + "\n");

                if (cardValue != 11)
                {
                    flag = true;

                    if (cardValue > 11)
                        Console.WriteLine("\nValue has exceeded!");
                    else
                        Console.WriteLine("\nValue has is less than expected!");

                    // Checking if there is any pair that the user missed
                    PairMissedElevens(list, cardValue);

                    // Print the cards in the card list and the number of cards in the deck
                    Console.WriteLine("\nPrinting Cards from the Card List: \n");
                    deck.PrintDeck(list);

                    Console.WriteLine("\nNumber of Cards from the Deck: " + deck.CardListCount());

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

                Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + board.Score);

                RemoveJQK(list);

                PairTerminationElevens(list);

                board.UserCards(list);

            } while (!flag);
        }
    }
}
