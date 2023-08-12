using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman Game!");

            // Player 1 enters a word
            Console.Write("Player 1, please enter a word: ");
            string word = Console.ReadLine().ToUpper();

            // Initialize the guessed word with underscores
            char[] guessedWord = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                guessedWord[i] = '_';
            }

            int attempts = 10; // number of attempts that Player 2 has

            while (attempts > 0)
            {
                // Display the guessed word
                Console.WriteLine();
                Console.Write("Guessed word: ");
                Console.WriteLine(guessedWord);

                // Player 2 enters a letter
                Console.Write("Player 2, enter a letter: ");
                char letter = Console.ReadLine().ToUpper()[0];

                bool letterFound = false;

                // Check if the letter is in the word
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        guessedWord[i] = letter;
                        letterFound = true;
                    }
                }

                // Check if Player 2 has guessed the word
                if (new string(guessedWord) == word)
                {
                    Console.WriteLine();
                    Console.WriteLine("Congratulations, you guessed the word!");
                    return;
                }

                // Decrement the number of attempts if the letter was not found
                if (!letterFound)
                {
                    attempts--;
                    Console.WriteLine();
                    Console.WriteLine($"Wrong letter! You have {attempts} attempts left.");
                }
            }

            // Player 2 has run out of attempts
            Console.WriteLine();
            Console.WriteLine("You have run out of attempts. Game over!");
            Console.WriteLine($"The word was {word}.");

            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
