using System;

namespace ChoicesAndConsequences.Models
{
    // Клас Evidence тепер реалізує два інтерфейси: 
    // ICollectible (можна підібрати) та ISearchable (можна обшукати)
    public class Evidence : GameEntity, ICollectible, ISearchable
    {
        // Порожній конструктор для коректної десеріалізації з JSON
        public Evidence() : base("", "")
        {
        }

        public Evidence(string id, string name, string description, string imagePath)
            : base(id, name)
        {
            // Записуємо дані у властивості, що успадковані від GameEntity
            this.Description = description;
            this.ImagePath = imagePath;
        }

        public override string Interact()
        {
            OnPickup();
            return $"Ви знайшли доказ: {Name}";
        }

        // --- Реалізація методу інтерфейсу ICollectible ---
        public void OnPickup()
        {
            // Логування в консоль для перевірки роботи механіки
            Console.WriteLine($"[LOG]: Предмет {Name} додано до інвентарю.");
        }

        // --- Реалізація методу інтерфейсу ISearchable (ПУНКТ №10) ---
        public bool Search()
        {
            // Логіка: якщо у предмета є опис, Шерлок може знайти в ньому додаткові деталі
            if (!string.IsNullOrEmpty(Description))
            {
                Console.WriteLine($"[LOG]: Обшук предмета {Name} пройшов успішно.");
                return true;
            }
            return false;
        }
    }
}