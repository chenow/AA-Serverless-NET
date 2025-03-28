namespace dotnet;

{
    class Personne
    {
        public string Nom { get; set; }
        public int Age { get; set; }

        // Méthode Hello qui renvoie un message formaté
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
            // Créer une instance de la classe Personne
            Personne personne = new Personne
            {
                Nom = "Alice",
                Age = 30
            };

            // Appeler la méthode Hello et afficher le résultat
            Console.WriteLine(personne.Hello(true)); // Affiche en minuscules
            Console.WriteLine(personne.Hello(false)); // Affiche en majuscules
        }
    }
}