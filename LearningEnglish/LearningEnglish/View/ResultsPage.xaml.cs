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
    public partial class ResultsPage : ContentPage
    {
        private List<Level> _levels;
        public ResultsPage()
        {
            InitializeComponent();
            App.Database.CreateTableResult();

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

        private void ResultsItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void LevelSelectedIndexChanged(object sender, EventArgs e)
        {
            var name = levelNames.Items[levelNames.SelectedIndex];
            var level = GetLevels().Single(l => l.Name == name);
            resultsList.ItemsSource = GetResults(level.Id);
        }

        private List<Result> GetResults(int levelId)
        {            
            var x = App.Database.GetResults().Where(w => w.LevelId == levelId).ToList(); ;
            return x;
        }

        private void DeleteClicked(object sender, EventArgs e)
        {

        }
    }
}