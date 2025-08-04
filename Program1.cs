using System;
using System.Collections.Generic;



namespace Hack
{

    public class Program1
    {
        public static List<KeyValuePair<string, int>> FrequencyCounter(string input)
        {
            Dictionary<string, int> freq12 = new Dictionary<string, int>();
            string wordq = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    wordq += char.ToLower(c);
                }
                else if (wordq != "")
                {
                    if (freq12.ContainsKey(wordq))
                    {
                        freq12[wordq]++;
                    }
                    else
                    {
                        freq12[wordq] = 1;
                    }
                    wordq = "";
                }
            }

            if (wordq != "")
            {
                if (freq12.ContainsKey(wordq))
                {
                    freq12[wordq]++;
                }
                else
                {
                    freq12[wordq] = 1;
                }
            }

            List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(freq12);

            int n = sortedList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    bool swap = false;
                    if (sortedList[j].Value < sortedList[j + 1].Value)
                    {
                        swap = true;
                    }
                    else if (sortedList[j].Value == sortedList[j + 1].Value)
                    {
                        if (string.Compare(sortedList[j].Key, sortedList[j + 1].Key) > 0)
                        {
                            swap = true;
                        }
                    }

                    if (swap)
                    {
                        KeyValuePair<string, int> temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                    }
                }
            }

            return sortedList;
        }

        public static void Main(string[] args)
        {
            bool processing = true;

            do
            {
                Console.WriteLine("Do you want to analyze word frequencies? (Y/N)");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    Console.WriteLine("Enter the text:");
                    string input = Console.ReadLine();
                    var result = FrequencyCounter(input);
                    Console.WriteLine("\nWord Frequencies:");
                    foreach (var pair in result)
                    {
                        Console.WriteLine($"{pair.Key}: {pair.Value}");
                    }
                }
                else if (choice == "N")
                {
                    processing = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                }

            } while (processing);

            Console.WriteLine("Program ended.");
        }
    }
}