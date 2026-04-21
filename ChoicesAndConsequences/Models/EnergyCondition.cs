using System.Collections.Generic;

namespace ChoicesAndConsequences.Models
{
    public class EnergyCondition : ICondition
    {
        private int _minEnergy;
        public string FailureMessage => "Ви занадто виснажені (недостатньо енергії)!";

        public EnergyCondition(int minEnergy) => _minEnergy = minEnergy;

        public bool IsMet(Character player, List<Evidence> inventory)
        {
            return player.Stats.Energy >= _minEnergy;
        }
    }
}