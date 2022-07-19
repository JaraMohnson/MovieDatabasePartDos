using EFMovies;
using EFMovies.Models;
using System.Collections;
using System.Collections.Generic;
using Validator;
bool RunProgram = true;
int menuChoice = 0;
string choice = "";
List<Movie> movieList = new List<Movie>();


Console.WriteLine("Welcome to MarVideo :) ");

while (RunProgram)
{
    Console.WriteLine("Enter 1 to search by genre. Enter 2 to search by title.");

    while (true)
    {
        //get me an integer and create list 
        menuChoice = Validator.Validator.GetUserNumberInt();

        if (menuChoice == 1)
        {
            Console.Write("Please enter a genre: ");
            choice = Console.ReadLine();
            movieList = SearchByGenre(choice);
            break;
        }
        else if (menuChoice == 2)
        {
            Console.Write("Please enter the title or partial title: ");
            choice = Console.ReadLine();
            movieList = SearchByTitle(choice);
            break;
        }
        else
        {
            Console.WriteLine("Please enter a valid choice.");
        }
    }


    if (movieList.Count > 0)
    {
        Console.WriteLine(string.Format("{0,-25} {1,-10} {2,-55}", "Title", "Genre", "Runtime"));
        foreach (Movie m in movieList)
        {
            Console.WriteLine(m.ToString());
        }
    }
    else
    {
        Console.WriteLine("No movies matching that search at this time.");
    }


    RunProgram = Validator.Validator.GetContinue("Do you want to search again?");
    

}

Console.WriteLine("Goodbye!");

static void DisplayMovies()
{
    using (MoviesDBContext context = new MoviesDBContext())
    {

        Console.WriteLine("Title:\t\tGenre:\t\tRuntime:");
        foreach (Movie m in context.Movies)
        {
            string.Format("{0,-25} {1,-15} {2,-55}", "Title", "Genre", "Runtime");
            Console.WriteLine($"{m.ToString()}"); ;
        }
    }

}

static List<Movie> SearchByGenre(string choice)
{
    List<Movie> result = new List<Movie>();
    using (MoviesDBContext context = new MoviesDBContext())
    {

        result = context.Movies.Where(m => m.Genre.ToLower().Contains(choice.ToLower())).ToList();
    }
    return result;
}

static List<Movie> SearchByTitle(string choice)
{
    List<Movie> result = new List<Movie>();
    using (MoviesDBContext context = new MoviesDBContext())
    {
        result = context.Movies.Where(m => m.Title.ToLower().Contains(choice.ToLower())).ToList();

    }
    return result;
}

