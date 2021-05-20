using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningEnglish
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlPage : ContentPage
    {
        private List<Level> _levels;
        public ControlPage()
        {
            InitializeComponent();

            _levels = GetLevels();
            foreach (var level in _levels)
                levelNames.Items.Add(level.Name);
        }

        private List<Level> GetLevels()
        {
            return new List<Level> {
                new Level {Id = 1, Name = "Beginner" },
                new Level {Id = 2, Name = "Elementary" },
                new Level {Id = 3, Name = "Intermediate" },
                new Level {Id = 4, Name = "Advanced" },
            };
        }

        private void LevelSelectedIndexChanged(object sender, EventArgs e)
        {
            var name = levelNames.Items[levelNames.SelectedIndex];
            var level = GetLevels().Single(l => l.Name == name);
            topicsList.ItemsSource = GetTopics(level.Id);
        }
        private List<Topic> GetTopics(int levelId)
        {
            return App.Database.GetTopics().Where(w => w.Level == levelId).ToList();
        }

        private async void TopicsItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var topic = e.SelectedItem as Topic;
            await Navigation.PushAsync(new ControlMetodPage(topic));
        }

        private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }
    }
}