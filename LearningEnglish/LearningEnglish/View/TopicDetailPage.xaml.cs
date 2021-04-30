using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace LearningEnglish
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicDetailPage : ContentPage
    {
        public TopicDetailPage(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException();
            InitializeComponent();

            BindingContext = topic;
            var words = GetWords(topic.Id);
            wordsList.ItemsSource = words;            
        }

        private List<Word> GetWords(int topicId)
        {
            return App.Database.GetWords().Where(w => w.TopicId == topicId).ToList();
        }

        private async void WordsItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var word = e.SelectedItem as Word;

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            var mp3Path = word.Mp3Path.Replace("\\", "/");
            var path = Path.Combine("Sounds", mp3Path + ".mp3");
            player.Load(path);
            player.Play();
            //wordsList.SelectedItem = null;
        }

        private void WordsItemTapped(object sender, ItemTappedEventArgs e)
        {
            var word = e.Item as Word;

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            var path = Path.Combine("Sounds", word.Mp3Path + ".mp3");
            player.Load(path);
            player.Play();
        }
    }
}