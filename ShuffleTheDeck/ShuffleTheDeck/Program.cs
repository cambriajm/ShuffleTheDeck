namespace ShuffleTheDeck
{
    internal class Program
    {
        static bool[,] DrawnCards = new bool[5, 15];
        static void Main(string[] args)
        {
            Console.WriteLine("CARDS IDK");
            string userInput = "";
            int cardCount = 0;
            string userPrompt = "";
            string message = "";
            do
            {
                userPrompt = "Welcome to Shuffle the Deck,  click enter to draw a card\n" +
                "q to quit, c to clear";
                Console.Clear();
                if (cardCount == 0)
                {
                    userPrompt = "Hit enter to get a card";
                    DrawnCard();
                    cardCount++;
                }
                else if (cardCount < 52)
                {

                    DrawnCard();
                    cardCount++;
                }
                else
                {
                    userPrompt = "All cards have been drawn\n" +
                         "q to quit, c to clear";
                }
                Display();
                Console.WriteLine(userPrompt);

                Console.WriteLine(cardCount);

                userInput = Console.ReadLine(); //fixed double draw

                if (userInput == "c" || userInput == "C")
                {
                    ClearDrawnCards();
                    cardCount = 0;
                }

            } while (userInput != "Q" && userInput != "q");
            Console.Clear();
            Console.WriteLine("Have a nice day!");
            //pause
            Console.Read();


            //pause
            Console.Read();
        }


        static void Display()
        {
            int padding = 4;
            int prettyNumber = 0;
            string placeHolder = "";
            string columnSeperator = " |";
            string currentRow = "";
            //print heading row
            string[] heading = { "♣", "♦", "♥", "♠" };
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + columnSeperator);
            }
            Console.WriteLine();

            // print the rest of the rows
            for (int number = 1; number <= 13; number++)
            {
                //assemble the row
                for (int suit = 0; suit < 4; suit++)
                {
                    if (DrawnCards[suit, number -1])
                    {
                        prettyNumber = number + (suit * 13); //offset the number by the letter column
                        currentRow += prettyNumber.ToString().PadLeft(padding) + columnSeperator;
                    }
                    else
                    {
                        currentRow += placeHolder.PadLeft(padding) + columnSeperator;
                    }
                }
                Console.WriteLine(currentRow);
                currentRow = ""; //reset 


            }

        }
            static void DrawnCard()
            {
                int letter = 0, number = 0;
                do
                {
                    letter = RandomNumberZeroTo(4);
                    number = RandomNumberZeroTo(13);
                } while (DrawnCards[letter, number]);

                DrawnCards[letter, number] = true;

            }

        static private int RandomNumberZeroTo(int max)
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range);
        }

        static void ClearDrawnCards()
        {
            for (int i = 0; i <= 4; i++)
            {
                //assemble the row
                for (int j = 0; j < 12; j++)
                {
                    DrawnCards[i, j] = false;

                }

            }
        }
    }
}
