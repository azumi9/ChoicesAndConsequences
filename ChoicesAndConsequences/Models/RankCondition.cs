using System;
using System.Collections.Generic;

namespace ChoicesAndConsequences.Models
{
    public class RankCondition : ICondition
    {
        private DetectiveRank _requiredRank;
        public string FailureMessage => $"Недостатній досвід! Потрібен ранг: {_requiredRank}. Знайдіть більше доказів.";

        public RankCondition(DetectiveRank rank) => _requiredRank = rank;

        public bool IsMet(Character player, List<Evidence> inventory)
        {
            // Перевіряємо, чи поточний ранг гравця більший або дорівнює необхідному
            return player.Stats.Rank >= _requiredRank;
        }
    }
}