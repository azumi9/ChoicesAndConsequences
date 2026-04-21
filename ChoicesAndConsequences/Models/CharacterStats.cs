namespace ChoicesAndConsequences.Models
{
    // Пункт 5: Використання переліку (Enum) для рангів детектива
    public enum DetectiveRank
    {
        Novice,       // Новачок
        Assistant,    // Помічник
        Professional, // Професіонал
        Master        // Майстер дедукції
    }

    // Пункт 5: Використання структури (Struct) для характеристик
    public struct CharacterStats
    {
        public int Energy;      // Енергія (витрачається на дії)
        public int Perception;  // Уважність (шанс знайти доказ)
        public DetectiveRank Rank;

        public CharacterStats(int energy, int perception, DetectiveRank rank)
        {
            Energy = energy;
            Perception = perception;
            Rank = rank;
        }
    }
}