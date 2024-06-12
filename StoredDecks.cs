using FlashCLI.Data;

namespace FlashCLI;

public class StoredDecks
{
    /* Creates a dictionary to store decks of flashcards
     Concept of Encapsulation used by making it private*/
    private readonly Dictionary<string, List<Flashcard>> Decks = new Dictionary<string, List<Flashcard>>();

    //Creating Flashcards Method - public to be used outside class
    public void CreateNewDeck(string deckName)
    {
        //Checks if a deck already has that name
        if (Decks.ContainsKey(deckName))
        {
            Console.WriteLine("Deck '{0}' already exists.", deckName);
            return;
        }

        //Adds a new deck with the name passed in, and also creates a list of flashcards within that deck.
        Decks.Add(deckName, new List<Flashcard>());
        Console.WriteLine("Deck '{0}' created successfully.", deckName);
    }
    
    //Deleting Flashcards Method - Public to be used outside class
    public void DeleteDeck(string deckName)
    {
        //Checks if there is a deck with that name to be deleted
        if (!Decks.ContainsKey(deckName))
        {
            Console.WriteLine("Deck '{0}' does not exist.", deckName);
            return;
        }
        
        //Deck removed from dictionary
        Decks.Remove(deckName);
        Console.WriteLine("Deck '{0}' removed successfully.", deckName);
    }

    //Method for creating flashcard - Public to be used outside class
    public void CreateFlashcards(string deckName)
    {
        //Check if a deck with the name matching the parameter deckName exists, prompts user to create a deck if it doesnt exist
        if (!Decks.ContainsKey(deckName))
        {
            Console.WriteLine("Deck '{0}' does not exist. Create a deck first.", deckName);
            return;
        }
        
        
        //Stores the front and back of the flashcard in 'question' and 'answer'
        Console.WriteLine("Enter question for the new flashcard:");
        string question = Console.ReadLine();

        Console.WriteLine("Enter answer for the new flashcard:");
        string answer = Console.ReadLine();

        //'question' and 'answer' are passed into a getter and setter and then are added to the list of flashcards in that deck
        Flashcard newFlashcard = new Flashcard { Question = question, Answer = answer };
        Decks[deckName].Add(newFlashcard);
        Console.WriteLine("Flashcard added to deck '{0}'.", deckName);
    }

    //Method for doing the flashcard - Public to be used outside class
    public void DoFlashcards(string deckName)
    {
        //Checks if deck passed in exists
        if (!Decks.ContainsKey(deckName))
        {
            Console.WriteLine("Deck '{0}' does not exist.", deckName);
            return;
        }
        
        //Retrieves flashcards from deck
        List<Flashcard> flashcards = Decks[deckName];
        
        //Checks if there are flashcards in the deck
        if (flashcards.Count == 0)
        {
            Console.WriteLine("Deck '{0}' has no flashcards to do.", deckName);
            return;
        }
        
        //Foreach to iterate over each flashcard in the list
        foreach (Flashcard flashcard in flashcards)
        {
            //Displays The question
            Console.WriteLine("Question:");
            Console.WriteLine(flashcard.Question);
            Console.WriteLine("Press Enter to show the answer");
            Console.ReadLine(); //When enter is pressed, the answer is revealed

            Console.WriteLine("Answer:");
            Console.WriteLine(flashcard.Answer);
            
            //Asks user to select either 'y' or 'n' for if they remembered the flashcard
            Console.WriteLine("Did you remember it? (y/n)");
            string remembered = Console.ReadLine().ToLower(); //ensures its lowercase to keep consistency
            
            //Creates two cases in how the spaced repetition algorithm is to be implemented based on their answer. 'y' (true) would increase length interval, 'n' (false) would decrease length interval 
            flashcard.NextReviewDate = remembered == "y" //See SpacedRepetition.cs for more notes on that
                ? SpacedRepetition.UpdateReviewDate(flashcard, isCorrect: true)
                : SpacedRepetition.UpdateReviewDate(flashcard, isCorrect: false);
            
            //Outputs the Next review date based on spaced repetition algorithm
            string normalFormatNextReviewDate = flashcard.NextReviewDate.ToString("yyyy-MM-dd");
            Console.WriteLine($"Next review date: {normalFormatNextReviewDate}");
        }
    }
    
    
    //Method for outputting the existing decks - Public to be used outside class
    public void GetExistingDecks()
    {
        //Checks if theres any existing decks
        if (Decks.Count == 0)
        {
            Console.WriteLine("No Decks");
            return;
        }
        
        //Foreach to interate over all the decks in the dictionary and outputs them
        Console.WriteLine("Existing Decks:");
        foreach (var deck in Decks)
        {
            Console.WriteLine(deck.Key);
        }
    }

    
    //Creates a class called 'Flashcard' - Public to be used outside class
    public class Flashcard
    {
        
        //Uses getters and setters to retrieve information for each flashcard when instantiated
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime NextReviewDate { get; set; }
        
        public bool HasNextReviewDate => NextReviewDate != null;
    }
}