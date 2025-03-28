namespace dotnet
{
    class Personne
    {
        public string Nom { get; set; }
        public int Age { get; set; }

        public string Hello(bool isLowercase)
        {
            string message = $"hello {Nom}, you are {Age}";
            return isLowercase ? message.ToLower() : message.ToUpper();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Personne personne = new Personne
            {
                Nom = "Alice",
                Age = 30
            };

            Console.WriteLine(personne.Hello(true));
            Console.WriteLine(personne.Hello(false));
        }
    }
}