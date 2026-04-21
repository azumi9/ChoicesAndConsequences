namespace ChoicesAndConsequences.Models
{
    // Абстракція. Базовий клас для всього в грі
    public abstract class GameEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public GameEntity(string id, string name)
        {
            Id = id;
            Name = name;
        }

        // Абстрактний метод 
        public abstract string Interact();
    }
}