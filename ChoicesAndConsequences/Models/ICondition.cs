namespace ChoicesAndConsequences.Models
{
    public interface ICondition
    {
        // Перевіряємо, чи виконується умова для конкретного гравця та стану гри
        bool IsMet(Character player, List<Evidence> inventory);

        // Повідомлення, яке побачить гравець, якщо умова НЕ виконана
        string FailureMessage { get; }
    }
}