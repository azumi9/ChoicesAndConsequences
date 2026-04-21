using ChoicesAndConsequences.Models;
using System;

namespace ChoicesAndConsequences.Models
{
    // Наслідування від GameEntity
    public class Character : GameEntity
    {
        // Використання структури статів
        public CharacterStats Stats { get; set; }

        public Character(string id, string name) : base(id, name)
        {
            // Початкові дані: 100 енергії, 10 уважності, ранг "Новачок"
            Stats = new CharacterStats(100, 10, DetectiveRank.Novice);
        }

        public override string Interact()
        {
            return $"Детектив {Name} (Ранг: {Stats.Rank}). Енергія: {Stats.Energy}%";
        }
    }
}