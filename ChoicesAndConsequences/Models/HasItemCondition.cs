using System.Collections.Generic;
using System.Linq;

namespace ChoicesAndConsequences.Models
{
    public class HasItemCondition : ICondition
    {
        private string _requiredItemId;
        public string FailureMessage => $"Для цього потрібен предмет: {_requiredItemId}";

        public HasItemCondition(string itemId) => _requiredItemId = itemId;

        public bool IsMet(Character player, List<Evidence> inventory)
        {
            // Перевіряємо, чи є в інвентарі предмет з таким ID
            return inventory.Any(item => item.Id == _requiredItemId);
        }
    }
}