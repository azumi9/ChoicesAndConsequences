using System.Collections.Generic;

namespace ChoicesAndConsequences.Models
{
    public class GameScene
    {
        public string SceneId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        // Тепер тут список об'єктів вибору замість старого Dictionary
        public List<SceneChoice> Choices { get; set; } = new List<SceneChoice>();

        // Порожній конструктор для десеріалізації JSON
        public GameScene() { }

        // Конструктор з параметрами (якщо ти захочеш створювати сцени вручну в коді)
        public GameScene(string id, string text, string imagePath)
        {
            SceneId = id;
            Text = text;
            ImagePath = imagePath;
        }
    }
}