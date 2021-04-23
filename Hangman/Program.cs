using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            string[] wordBank = { "Computer", "Python", "Strawberry", "Java", "Supernatural", "Dreadful", "Heroes" };

              string wordToGuesses = wordBank[random.Next(0, wordBank.Length)];
              string wordToGuessesUppercase = wordToGuesses.ToUpper();

              StringBuilder builder = new StringBuilder(wordToGuesses.Length);
              for (int index = 0; index < wordToGuesses.Length; index++)
                builder.Append('*');
            

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;

            string strInput;
            char guesses;

            while (!won && lives > 0)
            {
                Console.Write("Guess a letter: ");

                strInput = Console.ReadLine().ToUpper();
                guesses = strInput[0];

                if (correctGuesses.Contains(guesses))
                {
                    Console.WriteLine($"You've already tried {guesses}, and it was correct!");
                    continue;
                }
                else if (incorrectGuesses.Contains(guesses))
                {
                    Console.WriteLine($"You've already tried {guesses}, and it was wrong!");
                    continue;
                }

                if (wordToGuessesUppercase.Contains(guesses))
                {
                    correctGuesses.Add(guesses);

                    for (int i = 0; i < wordToGuesses.Length; i++)
                    {
                        if (wordToGuessesUppercase[i] == guesses)
                        {
                            builder[i] = wordToGuesses[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuesses.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guesses);

                    Console.WriteLine($"No, there's no {guesses} in it!");
                    lives--;
                }

                Console.WriteLine(builder.ToString());
            }

            if (won)
            {
                Console.WriteLine("You Win!");
            }

            else
            {
                Console.WriteLine($"You Lost! It was {wordToGuesses}");
            }
                

            Console.ReadLine();

        }
        
    }
}
