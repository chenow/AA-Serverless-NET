using System;
using Newtonsoft.Json;

namespace dotnet
{
    class Personne
    {
        public string nom { get; set; }
        public int age { get; set; }

        public string Hello(bool isLowercase)
        {
            string message = $"hello {nom}, you are {age}";
            return isLowercase ? message.ToLower() : message.ToUpper();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Personne personne = new Personne
            {
                nom = "Alice",
                age = 30
            };

            string json = JsonConvert.SerializeObject(personne, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}