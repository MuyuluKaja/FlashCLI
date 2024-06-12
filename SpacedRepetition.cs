using System.Reflection.Metadata;

namespace FlashCLI.Data;

public class SpacedRepetition //Spaced repetiton algorithm inspiration from: https://github.com/thyagoluciano/sm2
{
    public static DateTime UpdateReviewDate(StoredDecks.Flashcard card, bool isCorrect)
    {
        //Checks if what's passed through is a card object
        if (card == null)
        {
            throw new ArgumentNullException(nameof(card));
        }

        // Validate NextReviewDate property
        if (!card.HasNextReviewDate)
        {
            throw new InvalidOperationException("Flashcard does not have a NextReviewDate property.");
        }
       //The Initial review date for a new card
       const int initialReviewIntervalDays = 1;
       /*These are the multipliers which will be used based on whether the user is correct or not
        'easyFactor' increases the length of time to be reviewed (higher multiplier)
        'forgettingFactor' decreases the length of time to be reviewed (multiplier below 1)*/
       const double easyFactor = 2.5;
       const double forgettingFactor = 0.8;
       
       //Calculating the new interval in days based on their answer
       double newIntervalInDays;
       if (isCorrect)
       {
           // The time for review gets longer if the user easily gets the answer correct
           newIntervalInDays = initialReviewIntervalDays * easyFactor;
       }
       else
       {
           //Ensures that the cards next date to be reviewed becomes closer by decreasing the value by a factor of *0.8 
           newIntervalInDays = initialReviewIntervalDays * forgettingFactor;
       }
       
       //Days are to be converted to ticks for more accuracy and to be used in calculation
       long newIntervalInTicks = (long)(newIntervalInDays * TimeSpan.TicksPerDay);
       
       //Next Review Date calculated in Ticks for more accuracy and to be used in calculation
       long NextReviewDateInTicks = card.NextReviewDate.Ticks + newIntervalInTicks;
       //Converting Days,Months and Years into Ticks

       DateTime newReviewDate = new DateTime(NextReviewDateInTicks);
       
       //Creates variable Year, Month and Date so they can be passed into the DateTime method
       int newYear = newReviewDate.Year;
       int newMonth = newReviewDate.Month;
       int newDay = newReviewDate.Day;
       
       //Update NextReviewDate with with the date
       card.NextReviewDate = new DateTime(newYear, newMonth, newDay);
       //Returns the next date
       return card.NextReviewDate;


    }
}