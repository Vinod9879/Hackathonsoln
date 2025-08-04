using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2.Librarian has a list of books and their authors as a text. You need to write a program to assist him. Write a method that prints the output as the book titles and is sorted based on the alphabetical order of their author names and book titles. 
//The Function signature:
//List<String> SortTitles(List<String>) { }

//Assumptions & Limitations: 
//1.A title will not contain the double quote (") character. 
//2. If a book contains more than one author, consider only the first author's name for sorting. 
//3. If two books have the same first author, use the book title for sorting. 
//4. Book titles are unique. 
//Sample Input (List containing the following three entries) 	Sample Output (List containing the following three entries) 
//"The Canterbury Tales" by Chaucer 
//"Algorithms" by Sedgewick 
//"The C Programming Language" by Kernighan and Ritchie 	The Canterbury Tales 
//The C Programming Language 
//Algorithms 


namespace Hack
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            List<string> books = new List<string>
            {
                "\"The Canterbury Tales\" by Chaucer",
                "\"Algorithms\" by Sedgewick",
                "\"The C Programming Language\" by Kernighan and Ritchie"
            };

            List<string> sortedTitles = SortTitles(books);

            Console.WriteLine("Sorted Book Titles:");
            foreach (var title in sortedTitles)
            {
                Console.WriteLine(title);
            }

        }

        public static List<string> SortTitles(List<string> bookEntries)
        {
            if (bookEntries == null || !bookEntries.Any())
            {
                return new List<string>();
            }
            List<(string Title, string Author)> parsedBooks = new List<(string, string)>();

            foreach (string entry in bookEntries)
            {
             
                int titleEndIndex = entry.IndexOf("\" by ");
                string title = entry.Substring(1, titleEndIndex - 1);

                int authorStartIndex = titleEndIndex + "\" by ".Length;
                string authorString = entry.Substring(authorStartIndex);

                string firstAuthor = authorString.Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries).First().Trim();

                parsedBooks.Add((title, firstAuthor));
            }

            
            parsedBooks.Sort((book1, book2) =>
            {
                int authorComparison = String.Compare(book1.Author, book2.Author, StringComparison.OrdinalIgnoreCase);
                if (authorComparison != 0)
                {
                    return authorComparison;
                }
                return String.Compare(book1.Title, book2.Title, StringComparison.OrdinalIgnoreCase);
            });

            List<string> sortedTitles = parsedBooks.Select(b => b.Title).ToList();

            return sortedTitles;
        }

        
    }
}
