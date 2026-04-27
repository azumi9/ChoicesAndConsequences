using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ChoicesAndConsequences.Models;

namespace ChoicesAndConsequences.Services
{
    public class GameService
    {
        private List<GameScene> _scenes = new List<GameScene>();
        private List<Evidence> _inventory = new List<Evidence>();

        // Завантажує історію з JSON-файлу та ініціалізує об'єкти умов для виборів.
        public void LoadStory(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return;

                string jsonString = File.ReadAllText(filePath);

                // Налаштування десеріалізації (ігнорування регістру символів)
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var loadedScenes = JsonSerializer.Deserialize<List<GameScene>>(jsonString, options);

                if (loadedScenes != null)
                {
                    _scenes = loadedScenes;

                    // ПЕРЕТВОРЕННЯ ДАНИХ У ОБ'ЄКТИ (Data-Driven підхід)
                    // Проходимо по кожній сцені та кожному варіанту вибору
                    foreach (var scene in _scenes)
                    {
                        foreach (var choice in scene.Choices)
                        {
                            // 1. Якщо в JSON вказано ID предмета — додаємо об'єкт HasItemCondition
                            if (!string.IsNullOrEmpty(choice.RequiredItem))
                            {
                                choice.Conditions.Add(new HasItemCondition(choice.RequiredItem));
                            }

                            // 2. Додаємо умову енергії для всіх дій, що мають вартість більше 0
                            if (choice.EnergyCost > 0)
                            {
                                choice.Conditions.Add(new EnergyCondition(choice.EnergyCost));
                            }

                            // 3. Додаємо умову рангу
                            if (!string.IsNullOrEmpty(choice.RequiredRank))
                            {
                                if (Enum.TryParse<DetectiveRank>(choice.RequiredRank, out var parsedRank))
                                {
                                    choice.Conditions.Add(new RankCondition(parsedRank));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Виводимо помилку у вікно, якщо JSON має неправильний формат
                System.Windows.Forms.MessageBox.Show($"Помилка JSON: {ex.Message}");
            }
        }

        // Пошук сцени за її ідентифікатором за допомогою LINQ
        public GameScene? GetSceneById(string id) => _scenes.FirstOrDefault(s => s.SceneId == id);

        // Отримання поточного списку інвентарю
        public List<Evidence> GetInventory() => _inventory;

        // Додає доказ до інвентарю, якщо його там ще немає.
        public void AddToInventory(Evidence item)
        {
            if (item != null && !_inventory.Any(i => i.Id == item.Id))
            {
                _inventory.Add(item);
            }
        }

        // Допоміжний узагальнений метод (Generics) для пошуку в будь-якому списку GameEntity
        public T? FindInList<T>(List<T> list, string id) where T : GameEntity
        {
            return list?.FirstOrDefault(item => item.Id == id);
        }
    }
}