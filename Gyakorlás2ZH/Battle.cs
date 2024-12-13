using Gyakorlás2ZH.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlás2ZH
{
    internal class Battle
    {
        Planets.Planet BattlePlanet { get; set; }
        List<Character> Jedi {  get; set; }
        List<Character> Sith {  get; set; }
        public Battle(Planets.Planet _battleplanet, List<Character> _all)
        {
            BattlePlanet = _battleplanet;
            Jedi = new List<Character>();
            Sith = new List<Character>();

            foreach (var character in _all)
            {
                if (character.Side == Sides.Side.Jedi) Jedi.Add(character);
                else Sith.Add(character);
            }
        }
        public void Simulation()
        {
            foreach (var character in Sith)
            {
                if (!Jedi.Any()) return;
                Random random = new Random();
                int index = random.Next(0, Jedi.Count);
                var target = Jedi[index];
                character.Attack(target, BattlePlanet);
                if (!target.IsAlive) Jedi.Remove(target);
            }
            foreach (var character in Jedi)
            {
                if (!Sith.Any()) return;
                Random random = new Random();
                int index = random.Next(0, Sith.Count);
                var target = Sith[index];
                character.Attack(target, BattlePlanet);
                if (!target.IsAlive) Sith.Remove(target);
            }
            Log();
        }
        private void Log()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Világos Oldal:");
            foreach (var character in Jedi)
            {
                Console.WriteLine($"- {character.Name}: {character.Health} HP \n");
            }
            Console.WriteLine("Sötét Oldal:");
            foreach (var character in Sith)
            {
                Console.WriteLine($"- {character.Name}: {character.Health} HP \n");
            }
            Console.WriteLine("-------------------------------------------------------");

            File.AppendAllText("BattleLog.txt", "-------------------------------------------------------");
            File.AppendAllText("BattleLog.txt", "Világos Oldal:");
            foreach (var character in Jedi)
            {
                File.AppendAllText("BattleLog.txt", ($"- {character.Name}: {character.Health} HP \n"));
            }
            File.AppendAllText("BattleLog.txt", "Sötét Oldal:");
            foreach (var character in Sith)
            {
                File.AppendAllText("BattleLog.txt", ($"- {character.Name}: {character.Health} HP \n"));
            }
            File.AppendAllText("BattleLog.txt", "-------------------------------------------------------");
        }
        public bool IsOver => Jedi.Count == 0||Sith.Count == 0;
        public void GetSrongestFighter(Sides.Side Side)
        {
            Character StrongestSith = null;
            Character StrongestJedi = null;
            foreach (var Jedi in Jedi)
            {
                if (StrongestJedi == null || Jedi.Force > StrongestJedi.Force) StrongestJedi = Jedi;

            }
            Console.WriteLine("A Legerősebb Jedi:");
            Console.WriteLine($"{StrongestJedi.Name}, Ereje: {StrongestJedi.Force}");
            foreach (var Sith in Sith)
            {
                if (StrongestSith == null || Sith.Force > StrongestSith.Force) StrongestSith = Sith;

            }
            Console.WriteLine("A Legerősebb Sith:");
            Console.WriteLine($"{StrongestSith.Name}, Ereje: {StrongestSith.Force}");
        }
        public string DeclareWinner()
        {
            if (Jedi.Count == 0 && Sith.Count == 0) return "Döntetlen! A csata túl heves volt, és egyik oldal sem maradt életben.";
            if (Jedi.Count == 0) return "A sötét oldal győzött! A galaxis mostantól a félelem és gyűlölet uralma alatt áll.";
            return "A világos oldal győzedelmeskedett! A remény lángja újra fellángolt a galaxisban.";
            
        }
    }
}
