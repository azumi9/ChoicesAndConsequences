namespace ChoicesAndConsequences.Models
{
    // Використання інтерфейсів
    public interface ICollectible
    {
        string Name { get; set; }
        string Description { get; set; }
        void OnPickup(); // Дія при знаходженні
    }
}