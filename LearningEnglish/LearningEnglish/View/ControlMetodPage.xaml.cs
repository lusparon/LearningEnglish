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
    public partial class ControlMetodPage : ContentPage
    {
        private Dictionary<int,string> _controlMethods;
        private Topic _selectedTopic ;
        public ControlMetodPage(Topic topic)
        {
            InitializeComponent();

            _selectedTopic = topic;
            _controlMethods = GetControlMethods();
            foreach (var method in _controlMethods)
                ControlMethodsNames.Items.Add(method.Value);

        }
        private async void ControlMethodSelectedIndexChanged(object sender, EventArgs e)
        {
            var name = ControlMethodsNames.Items[ControlMethodsNames.SelectedIndex];
            var controlMethod = GetControlMethods().Single(l => l.Value == name);
            await Navigation.PushAsync(new TestingPage(_selectedTopic, controlMethod.Key));
        }

        private Dictionary<int, string> GetControlMethods()
        {
            return new Dictionary<int, string> {
                 {1, "Рус - Англ" },
                 {2, "Англ - Рус" },
                 {3, "Аудио - Рус" }
            };
        }
    }
}