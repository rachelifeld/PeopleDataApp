using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string? Gender { get; set; }
}
class Program
{
    static void Main()
    {
        GenerateCSV(); // Generate CSV first

        // Reading CSV file
        var lines = File.ReadAllLines("people_data.csv");
        List<Person> people = new List<Person>();

        foreach (var line in lines)
        { 
            var values = line.Split(',');
            people.Add(new Person
            {
                FirstName = values[0],
                LastName = values[1],
                Age = int.Parse(values[2]),
                Weight = int.Parse(values[3]),
                Gender = values[4]
            });
        }

        // Finding average age of all people
        double averageAge = people.Average(p => p.Age);
        Console.WriteLine($"Average Age of All People: {averageAge} years");

        // Finding total number of people weighing between 120lbs and 140lbs
        int peopleBetween120And140 = people.Count(p => p.Weight >= 120 && p.Weight <= 140);
        Console.WriteLine($"Total Number of People Weighing between 120lbs and 140lbs: {peopleBetween120And140}");

        // Finding average age of people weighing between 120lbs and 140lbs
        double averageAgeBetween120And140 = people.Where(p => p.Weight >= 120 && p.Weight <= 140).Average(p => p.Age);
        Console.WriteLine($"Average Age of People Weighing between 120lbs and 140lbs: {averageAgeBetween120And140} years");
    }

    static void GenerateCSV()
    {
        // Generating random data
        List<string> rows = new List<string>();
        Random rand = new Random();

        for (int i = 0; i < 1000; i++)
        {
            string firstName = GetRandomFirstName();
            string lastName = GetRandomLastName();
            int age = rand.Next(18, 71); // Age between 18 and 70
            int weight = rand.Next(100, 301); // Weight between 100 lbs and 300 lbs
            string gender = rand.Next(2) == 0 ? "Male" : "Female";

            string row = $"{firstName},{lastName},{age},{weight},{gender}";
            rows.Add(row);
        }

        // Writing to CSV file
        File.WriteAllLines("people_data.csv", rows);
    }

    static string GetRandomFirstName()
    {
        // Add a list of common first names
        string[] firstNames = { "John", "Jane", "David", "Emily", "Michael", "Sarah", "Robert", "Jessica", "Christopher", "Amanda" };

        Random rand = new Random();
        return firstNames[rand.Next(firstNames.Length)];
    }

    static string GetRandomLastName()
    {
        // Add a list of common last names
        string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };

        Random rand = new Random();
        return lastNames[rand.Next(lastNames.Length)];
    }
}


