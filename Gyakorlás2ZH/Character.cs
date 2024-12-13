using Gyakorlás2ZH.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlás2ZH
{
    internal class Character
    {
        public string Name { get; set; }
        public Specieses.Species Species { get; set; }
        public Planets.Planet Planet { get; set; }
        public Sides.Side Side { get; set; }
        public int Health = 100;
        public int Force {  get; set; }
        public Character(string _name,Specieses.Species _species, Planets.Planet _planet, Sides.Side _side, int _force)
        {
            Name = _name;
            Species = _species;
            Planet = _planet;
            Side = _side;
            Force = _force;
        }
        public double Defend(Planets.Planet BattlePlanet)
        {
            double defmultiplier = 0.8;
            if (Species == Specieses.Species.Wookiee) defmultiplier -= 0.1;
            if (BattlePlanet == Planet) defmultiplier -= 0.1;
            defmultiplier -= (double)Force / 400;
            return defmultiplier;
        }
        public void Attack(Character target, Planets.Planet BattlePlanet)
        {
            Random random = new Random();
            var atkmultiplier = (Force/2)-random.Next(0,11)*Defend(BattlePlanet);
            atkmultiplier = Math.Max(0,atkmultiplier);
            target.Health = Math.Max(0,target.Health-(int)atkmultiplier);
            Console.WriteLine($"{Name} Megtámadta {target.Name}-t, és {(int)atkmultiplier} sebzést okozott. {target.Name} életereje: {target.Health}");
        }
        public bool IsAlive => Health > 0;
    }

}
