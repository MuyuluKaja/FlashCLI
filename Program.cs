using System.Reflection.Metadata;
using FlashCLI;

class FlashCliApp
{
    static void Main(string[] args)
    {
        MainMenu();
        
    }

    //Creates a method for the main menu of the program
    static void MainMenu()
    {
        
        //Creates an instance from the class StoredDecks
        StoredDecks Decks = new StoredDecks();
        //This is what the homescreen will look like, using a text to ASCII generator (ANSI SHADOW): https://patorjk.com/software/taag/#p=display&f=ANSI%20Shadow&t=FlashCLI
        string HomeScreen = @"███████╗██╗      █████╗ ███████╗██╗  ██╗ ██████╗██╗     ██╗
██╔════╝██║     ██╔══██╗██╔════╝██║  ██║██╔════╝██║     ██║
█████╗  ██║     ███████║███████╗███████║██║     ██║     ██║
██╔══╝  ██║     ██╔══██║╚════██║██╔══██║██║     ██║     ██║
██║     ███████╗██║  ██║███████║██║  ██║╚██████╗███████╗██║
╚═╝     ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝ ╚═════╝╚══════╝╚═╝
   Flashcard CLI App For Pathways

   1. Manage Decks
   2. Create Flashcards
   3. Do Flashcards
   4. Exit

   Enter your choice: ";
        
        //Unconditional loop to keep the program running
        while (true)
        {
            //Outputs home sreen
            Console.WriteLine(HomeScreen);
            
            //Creates a variable called 'choice' for the user to select where they are going
            string choice = Console.ReadLine();
            
            //Using switch case to navigate between the possible options the user has created
            switch (choice)
            {
                //This is the first case where the user can Make/Delete a deck
                case "1" :
                    //Creates a loop in case the user selects something that isnt '1' or '2' so it will keep repeating this action
                    while (true)
                    {
                        Console.WriteLine("1. Create a Deck"); 
                        Console.WriteLine("2. Delete a Deck");
                        
                        int UserSelection = int.Parse(Console.ReadLine());
                        if (UserSelection == 1)
                        {
                            //If 1 is selected, the user is asked for a Deck name, then that's stored in the variable 'UserDeckName'
                            Console.WriteLine("Deck name:");
                            string UserDeckName = Console.ReadLine(); 
                            // UserDeckName is then passed as an argument into the method 'CreateNewDeck()' that the class Decks has.
                            Decks.CreateNewDeck(UserDeckName);
                            break;
                        }
                        else if (UserSelection == 2)
                        {
                            //If 2 is selected, the user is asked for the name of the deck that they want to remove, which is then stored into 'UserDeckName'
                            Console.WriteLine("Select Deck:");
                            Decks.GetExistingDecks(); //Outputs existing decks to the user
                            string UserDeckName = Console.ReadLine();
                            //UserDeckName is then passed as an argument into the method 'DeleteDeck' that the class Decks has.
                            Decks.DeleteDeck(UserDeckName);
                            break;
                        }
                    }

                    break;
                    
                    
                    
                //This is the second case in which the user adds flashcards to a deck  
                case "2":
                    //The user is asked which deck they wish to add their flashcards in
                    Console.WriteLine("Select in which Deck:");
                    //The method 'GetExistingDecks' outputs the decks that the user has created
                    Decks.GetExistingDecks();
                    //The SelectedDeck is then passed as an argument into the 'CreateFlashcards' method
                    string SelectedDeck = Console.ReadLine();
                    Decks.CreateFlashcards(SelectedDeck);
                    break;
                
                //This is the third case in which the user can do the flashcards
                case "3":
                    //The decks the user can do are outputted by the method 'GetExistingDecks()'
                    Console.WriteLine("Select a deck: ");
                    Decks.GetExistingDecks();
                    //The chosen deck is stored into the variable deckChosen and is then passed into the method DoFlashcards, then the user can proceed to start doing the flashcards.
                    string deckChosen = Console.ReadLine();
                    Decks.DoFlashcards(deckChosen);
                    break;
                
                case "4":
                    //Closes the entire program
                    Environment.Exit(0);
                    break;
                    
                    
            }
            
        }
    }
}
