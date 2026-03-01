namespace ShuffleTheDeck
//Cambria Morgan
//RCET 2265
//Spring 2026
//Shuffle the Deck
//https://github.com/cambriajm/ShuffleTheDeck.git
{
    internal class Program
    {
        static bool[,] DrawnCards = new bool[4, 13];
        static void Main(string[] args)
        {
             
            string userInput = "";
            int cardCount = 0;
            string userPrompt = "";
             
            do // loops drawing cards, allows clear and quit
            {
                userPrompt = "Welcome to Shuffle the Deck," +
                    "click enter to draw a card\n" +
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


        }


        static void Display() //formatting and number drawing
        {
            int padding = 10;
             
            string prettySymbol = "";
            string placeHolder = "";
             
            string columnSeperator = "|";
            string currentRow = "";
            //print heading row
            string[] heading = { "Spade  ", "Heart  ", "Club   ", "Diamond  " };
             

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
                        switch (number)//allows numbers to show properly for cards 
                        {
                            case 1:
                                prettySymbol = "A";
                            break;

                            case 11:
                                prettySymbol = "J";
                            break;

                            case 12:
                                prettySymbol = "Q";
                            break;

                            case 13:
                                prettySymbol = "K";
                            break;

                            default:
                                prettySymbol = number.ToString(); //normal numbers normal
                            break;

                        }
                        currentRow += prettySymbol.ToString().PadLeft(padding) + columnSeperator;
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
            static void DrawnCard()//draws random numbers
            {
                int letter = 0, number = 0;
                do
                {
                    letter = RandomNumberZeroTo(3);
                    number = RandomNumberZeroTo(12);
                } while (DrawnCards[letter, number]);

                DrawnCards[letter, number] = true;

            }

        static private int RandomNumberZeroTo(int max)//fixes number range 
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range);
        }

        static void ClearDrawnCards()//clears cards 
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
