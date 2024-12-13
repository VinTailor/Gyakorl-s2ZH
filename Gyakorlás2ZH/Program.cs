using Gyakorlás2ZH.enums;

namespace Gyakorlás2ZH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var characters = new List<Character>();
            string[] Jedinevek = { "Master Kael Solari", "Arlyn Dawnstar", "Gorrak" };
            string[] Sithnevek = { "Darth Malakar", "Lord Xyrek, the Whisper of Shadows", "Darth Kraavos" };
            
            foreach (var name in Jedinevek)
            {
                var planet = (Planets.Planet)random.Next(Enum.GetValues(typeof(Planets.Planet)).Length);
                var species = (Specieses.Species)random.Next(Enum.GetValues(typeof(Specieses.Species)).Length);
                var force = random.Next(49, 101);
                characters.Add(new Character(name, species, planet, Sides.Side.Jedi, force));
            }
            foreach (var name in Sithnevek)
            {
                var planet = (Planets.Planet)random.Next(Enum.GetValues(typeof(Planets.Planet)).Length);
                var species = (Specieses.Species)random.Next(Enum.GetValues(typeof(Specieses.Species)).Length);
                var force = random.Next(49, 101);
                characters.Add(new Character(name, species, planet, Sides.Side.Sith, force));
            }
            var BattlePlanet =  (Planets.Planet)random.Next(Enum.GetValues(typeof(Planets.Planet)).Length);
            var Battle = new Battle(BattlePlanet, characters);
            Battle.GetSrongestFighter(Sides.Side.Jedi);

            while (!Battle.IsOver)
            {
                Battle.Simulation();
                Console.WriteLine("A Folytatáshoz nyomj meg egy billentyűt");
                Console.ReadKey();
            }
            Console.WriteLine(Battle.DeclareWinner());

        }
    }
}
