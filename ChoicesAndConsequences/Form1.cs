using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using ChoicesAndConsequences.Models;
using ChoicesAndConsequences.Services;

namespace ChoicesAndConsequences
{
    public partial class Form1 : Form
    {
        private GameService _gameService = new GameService();
        private Character _player = new Character("det_1", "Шерлок Холмс");
        private bool _isCoffeeExhausted = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            string storyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "story.json");
            _gameService.LoadStory(storyPath);

            lbInventory.DoubleClick += LbInventory_DoubleClick;

            // ДОБАВЛЕНО: Галочка будет ставиться по первому клику
            lbInventory.CheckOnClick = true;

            // Додаємо перевірку на null, щоб не було жовтого попередження
            var startScene = _gameService.GetSceneById("start");
            if (startScene != null)
            {
                UpdateUI(startScene);
            }
        }

        private void UpdateUI(GameScene? scene)
        {
            if (scene == null) return;

            this.Text = $"Choices and Consequences | {_player.Name} | Енергія: {_player.Stats.Energy}%";
            UpdateStatus();
            rtbStory.Text = scene.Text;

            // ВИПРАВЛЕНО: прибрали .Properties
            try
            {
                if (!string.IsNullOrEmpty(scene.ImagePath))
                {
                    // Звертаємось напряму до Resources
                    var img = Resources.ResourceManager.GetObject(scene.ImagePath);
                    pbScene.Image = (System.Drawing.Image?)img;
                }
                else
                {
                    pbScene.Image = null;
                }
            }
            catch { pbScene.Image = null; }

            flpChoices.Controls.Clear();

            foreach (var choice in scene.Choices)
            {
                string btnText = choice.EnergyCost > 0 ? $"{choice.Text} (⚡{choice.EnergyCost})" : choice.Text;
                Button btn = new Button { Text = btnText, AutoSize = true, Padding = new Padding(10) };

                // ПРОВЕРЯЕМ УСЛОВИЯ ДО ТОГО, КАК ИГРОК НАЖАЛ
                bool conditionsMet = true;
                foreach (var condition in choice.Conditions)
                {
                    if (!condition.IsMet(_player, _gameService.GetInventory()))
                    {
                        conditionsMet = false;
                        break;
                    }
                }

                // Если условия не выполнены (нет ключа или энергии), делаем кнопку неактивной
                if (!conditionsMet)
                {
                    btn.Enabled = false; // Кнопка станет серой и не будет кликаться
                }

                btn.Click += (s, e) =>
                {
                    string nextSceneId = choice.NextSceneId;

                    // Логіка кущів
                    if (nextSceneId == "find_coffee" && _isCoffeeExhausted)
                    {
                        nextSceneId = _gameService.GetInventory().Any(i => i.Id == "coffee_thermos")
                            ? "bushes_picked"
                            : "bushes_empty";
                    }

                    if (choice.EnergyCost > 0)
                    {
                        var stats = _player.Stats;
                        stats.Energy -= choice.EnergyCost;
                        _player.Stats = stats;
                    }

                    // Підбір предметів
                    if (choice.Text.Contains("Забрати термос"))
                    {
                        _gameService.AddToInventory(new Evidence("coffee_thermos", "Термос кави", "Відновлює 30% енергії", ""));
                        _isCoffeeExhausted = true;
                        RefreshInventoryUI();
                    }
                    else if (choice.Text.Contains("Випити каву"))
                    {
                        var stats = _player.Stats;
                        stats.Energy = Math.Min(100, stats.Energy + 30);
                        _player.Stats = stats;
                        _isCoffeeExhausted = true;
                    }
                    else if (choice.Text.Contains("Оглянути ворота") || choice.Text.Contains("Забрати ключ"))
                    {
                        _gameService.AddToInventory(new Evidence("old_key", "Іржавий ключ", "Від воріт", ""));
                        RefreshInventoryUI();
                    }

                    // ДОДАТИ ЦЕ: Логіка підвищення рангу
                    if (choice.PromoteRank)
                    {
                        var stats = _player.Stats;
                        if (stats.Rank < DetectiveRank.Master) // Перевіряємо, щоб не вийти за межі максимального рангу
                        {
                            stats.Rank++; // Підвищуємо ранг на 1 рівень
                            _player.Stats = stats;
                            MessageBox.Show($"Вітаємо! Ваш детективний ранг підвищено до: {stats.Rank}!", "Підвищення рангу");
                        }
                    }

                    var nextScene = _gameService.GetSceneById(nextSceneId);
                    if (nextScene != null) UpdateUI(nextScene);
                };

                flpChoices.Controls.Add(btn);
            }
        }

        private void RefreshInventoryUI()
        {
            lbInventory.Items.Clear();
            foreach (var item in _gameService.GetInventory())
            {
                lbInventory.Items.Add(item.Name);
            }
        }

        // Додали ?, щоб прибрати попередження CS8622
        private void LbInventory_DoubleClick(object? sender, EventArgs e)
        {
            if (lbInventory.SelectedItem == null) return;
            string selectedName = lbInventory.SelectedItem.ToString() ?? "";

            if (selectedName.Contains("Термос кави"))
            {
                var stats = _player.Stats;
                if (stats.Energy >= 100) return;

                stats.Energy = Math.Min(100, stats.Energy + 30);
                _player.Stats = stats;

                var coffee = _gameService.GetInventory().FirstOrDefault(i => i.Id == "coffee_thermos");
                if (coffee != null) _gameService.GetInventory().Remove(coffee);

                RefreshInventoryUI();
                UpdateStatus();
                MessageBox.Show("Кава була дуже доречною!");
            }
        }

        private void UpdateStatus()
        {
            this.Text = $"Choices and Consequences | {_player.Name} | Енергія: {_player.Stats.Energy}% | Ранг: {_player.Stats.Rank}";
        }

        private void pbScene_Click(object sender, EventArgs e) { }

        private void flpChoices_Paint(object sender, PaintEventArgs e) { }

        private void lbInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если что-то выделено (индекс не равен -1), мы сразу снимаем выделение
            if (lbInventory.SelectedIndex != -1)
            {
                lbInventory.ClearSelected();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}