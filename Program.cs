using System;
using System.Collections.Generic;


namespace Project_1_Multigame_Card
{
    class Program
    {   
        static void Main(string[] args)
        {
            int choice;

            // Creating a board object
            Board board = new Board();

            // Initializing Game Tens
            TensBoard tens = new TensBoard();

            // Initializing Game Elevens
            ElevensBoard elevens = new ElevensBoard();

            // Initializing Game Thirteens
            ThirteensBoard thirteens = new ThirteensBoard();

            // Creating a deck object
            Deck deck = new Deck();

            // Create a new card list
            List<Card> newCardList = new List<Card>();

            choice = PrintMenu();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:

                        // Deal 13 cards from the deck and add them into the card list
                        board.DealCards(13, newCardList);

                        // Print cards in the card list and ask user select two cards from the list from the command line
                        deck.PrintDeck(newCardList);

                        Console.WriteLine("\n\t" + (deck.CardListCount() - deck.CardListCount(newCardList)) + " Undealt Cards Remaining...");
                        Console.WriteLine("\n\tYour Score is: " + board.Score);

                        // Checking if card list no contain pairs...
                        tens.PairTerminationTens(newCardList);

                        // Asking for Card 1 and Card 2
                        board.UserCards(newCardList, 13);

                        // Play Tens Game
                        tens.TensGame(newCardList, board.card1, board.card2, board.cardValue);
                        break;
                    case 2:
                        // Deal 9 cards from the deck and add them into the card list
                        board.DealCards(9, newCardList);

                        // Print cards in the card list and ask user select two cards from the list from the command line
                        deck.PrintDeck(newCardList);

                        Console.WriteLine("\n\t" + (deck.CardListCount() - deck.CardListCount(newCardList)) + " Undealt Cards Remaining...");
                        Console.WriteLine("\n\tYour Score is: " + board.Score);

                        // Checking if card list no contain pairs...
                        elevens.PairTerminationElevens(newCardList);

                        // Asking for Card 1 and Card 2
                        board.UserCards(newCardList, 11);

                        // Play Tens Game
                        elevens.ElevensGame(newCardList, board.card1, board.card2, board.cardValue);
                        break;
                    case 3:
                        // Deal 10 cards from the deck and add them into the card list
                        board.DealCards(10, newCardList);

                        // Print cards in the card list and ask user select two cards from the list from the command line
                        deck.PrintDeck(newCardList);

                        Console.WriteLine("\n\t" + (deck.CardListCount() - deck.CardListCount(newCardList)) + " Undealt Cards Remaining...");
                        Console.WriteLine("\n\tYour Score is: " + board.Score);

                        // Checking if card list no contain pairs...
                        thirteens.PairTerminationThirteens(newCardList);

                        // Asking for Card 1 and Card 2
                        board.UserCards(newCardList, 10);

                        // Play Tens Game
                        thirteens.ThirteensGame(newCardList, board.card1, board.card2, board.cardValue);
                        break;
                    case 4:
                        PrintMenu();
                        break;
                    case 5:
                        PrintMenu();
                        break;
                    default:
                        Console.WriteLine( "\nChoice is not correct. Please look at "
                            + "choices and reenter\n\n");
                        break;
                }
                choice = PrintMenu();
            }
        }

        public static int PrintMenu()
        {
            int c;

            Console.WriteLine("****************************************************");
            Console.WriteLine("***        WELCOME TO THE MULTI-CARD GAME        ***");
            Console.WriteLine("****************************************************\n");
            Console.WriteLine("Please elect the game that you would like to play:\n");
            Console.WriteLine("\n\t1: Play Tens Game.");
            Console.WriteLine("\n\t2: Play Elevens Game.");
            Console.WriteLine("\n\t3: Play Thirteens Game.");
            Console.WriteLine("\n\t4: NO A OPTION - SKIP");
            Console.WriteLine("\n\t5: NO A OPTION - SKIP");
            Console.WriteLine("\n\t6: Quit.\n\n");
            c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n");

            return c;
        }
    }
}
