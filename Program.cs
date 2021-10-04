using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TP3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
        //Question 1 Count all movies.
        List<MovieCollection.WaltDisneyMovies> moviesList = new MovieCollection().Movies;
        Console.WriteLine(moviesList.Count);


        //Question 2 Count all movies.
        Console.WriteLine(moviesList.Count(x => x.Title.Contains("e")));


        //Question 3 Count how many time the letter f is in all the titles from this list.
        var compteur_F = 0;
            foreach (var itemF in moviesList)
            {
              compteur_F += itemF.Title.Count(x => x == 'f');
            }
            Console.WriteLine(compteur_F);


        //Question 3 Display the title of the film with the higher budget.
        Console.WriteLine("Affichez le film au budget le plus élevé.");
                  var highBudget =
                      from VAR in moviesList
                      orderby VAR.Budget descending 
                      select VAR.Title;
                  Console.WriteLine(highBudget.First());


        //Question 4 Display the title of the movie with the lowest box office.
        Console.WriteLine("Affichez le film ayant le plus petit budget.");
                  var lowBudget =
                      from VAR in moviesList
                      orderby VAR.Budget ascending 
                      select VAR.Title;
                  Console.WriteLine(lowBudget.First());


        //Question 5 Order the movies by reversed alphabetical order and print the first 11 of the list.
        var inverse11 = (from movie in moviesList orderby movie.Title descending select movie).Take(11);
        foreach (var tmp2 in inverse11)
        {
        Console.WriteLine(tmp2.Title);
        }


        //Question 6 Count all the movies made before 1980.



        //Question 7 Display the average running time of movies having a vowel as the first letter.
        Console.WriteLine((from movie in moviesList where "aeiou".IndexOf(movie.Title.ToLower()[0]) >= 0 select movie.RunningTime).Average());


        //Question 8 Print all movies with the letter H or W in the title, but not the letter I or T.
        foreach (var list_H_W in from movie in moviesList where (movie.Title.ToUpper().Contains('H') || movie.Title.ToUpper().Contains('W')) && !(movie.Title.ToUpper().Contains('I') || movie.Title.ToUpper().Contains('T')) select movie) {
        Console.WriteLine(list_H_W.Title);
        }



        //Question 9 Calculate the mean of all Budget / Box Office of every movie ever
        var average = from item in moviesList select item.Budget;
        var averageBoxOffice = from item in moviesList select item.BoxOffice; 
        var budgetAverage = average.Average();
        var BoxOfficeAverage = averageBoxOffice.Average();
        var tmp = budgetAverage / BoxOfficeAverage;
        Console.WriteLine(budgetAverage);
        Console.WriteLine(BoxOfficeAverage);
        }
    }
}