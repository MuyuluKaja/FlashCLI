# FlashCLI 
#### This is a project I had made for an outreach program called 'Pathways to Bath'.
#### In this file I'll be going through the issues I've had in this files creation and also what went well (WWW and EBI)

## Requirements
Install [.NET SDK](https://dotnet.microsoft.com/en-us/download)


## How to Run the program
Clone the repository:
```
git clone https://github.com/MuyuluKaja/FlashCLI.git
```

Open Repository:
```
cd FlashCLI
```

Run file:
```
dotnet run Program.cs
```

## About The Project itself
Based on what I had specified in my Project's Outline, this program is intended to implement concepts to amplify memory 
based revision using rewards. Essentially, the program is supposed to incorporate rewards based on your performance and engagement 
with doing the flashcards. The concepts used in this project are 'spaced repetition' and 'reward based revision'.
### What is Spaced Repetition? 
Spaced repetition is a technique for efficient memorisation which uses repeated review of content followed by an algorithm to determine how often this content should be reviewed. This is helpful in the improvement of content retention over time. This is because our ability to remember a piece of information is critically dependant of the amount of time we’ve reviewed it, time elapsed since we’ve last reviewed it and the distribution of reviews. Essentially, our recollection of information is proportional to the number of times we’ve reviewed it. Studies have shown that the correlation between retention and repetitions is strong, as if the number of repetitions increases, the information becomes more engraved deeply and indelibly, and if the number of repetitions is smaller, retained information decreases and becomes vague over time
*This is from my project's outline**

### What do I mean by incoporating rewards?
Rewards are an extensively studied subject by psychologists and neuroscientists into determining its role in performance and actions. In regard to studying, rewarding is beneficiary in its motivation for studying. Rewards trigger a neuron called ‘dopamine’, and this neuron can be optimised for optimal study. The way dopamine works is by giving you a feeling of pleasure, satisfaction and motivation 

For studying, this is supposed to help the user engage more often and actively with the app and studying

*This is from my project's outline**

## WWW (What went well)
In this project, I was able to sucessfully incorporate a spaced repetition algorithm on a deck of cards manually created from the user

I was able to use data structures (Lists, Dictionaries etc.) and OOP concepts (Encapulsation, Instantiation, Abstraction etc.) 
for creating, storing and using decks and flashcards

I was able to categorise and section parts of my program to make it more readable and understandable to someone whos trying to understand the code

## Issues + (Further Development/Future Plans)
### Issues: 
- The storing of these decks and flashcards are not permanent, in fact they're volatile and is gone once the program is shut
- Rewarding wasnt incoporated as I intended a point based system and star ratings to measure the user's engagement
- There is no GUI for the user to use, relies on the CLI
- No use of databases or files to permanently store flashcards (txt, csv etc.)

### Future Plans
- Due to A level exams and mocks, I was unable to learn more about databases and file storage, manipulation and interaction to permanently store these flashcards
, if I had more time before the deadline, I would spend time learning more about storing files in a csv file using StreamReader and CsvHelper to interact and extract data from. 
- I was also unable to incorporate a point based system in which they're added based on the user's engagement, and so with more time, incorporating rewards will be a priority.
##### I will continue to develop this projects and correct the issues stated above. I will be developing a GUI using WinForms or AvaloniaUI so interactivity between the user and the program is simplified. On top of that, I will incorporate a reward based scoring system in which they can compare it to their peers, and I'll use one of the SQL, XML and CSV for storing the data permanently so the flashcards made are reusable.



### References Used: 
[SM-2 Algorithm](https://github.com/thyagoluciano/sm2)

[Object Oriented Programming in C#](https://www.w3schools.com/cs/cs_oop.php)

[Data Structures in C#](https://learn.microsoft.com/en-us/dotnet/standard/collections/)





