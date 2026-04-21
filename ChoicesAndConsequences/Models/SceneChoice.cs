using System.Collections.Generic;

namespace ChoicesAndConsequences.Models
{
    public class SceneChoice
    {
        public string Text { get; set; } = string.Empty;
        public string NextSceneId { get; set; } = string.Empty;
        public int EnergyCost { get; set; } = 0;

        // Список умов для цього вибору
        public List<ICondition> Conditions { get; set; } = new List<ICondition>();

        // Додаткові поля для завантаження з JSON
        public string? RequiredItem { get; set; }
    }
}