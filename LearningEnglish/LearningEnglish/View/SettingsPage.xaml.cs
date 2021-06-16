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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            App.Database.CreateTableSetting();
            var x = App.Database.GetSettings();

            var setting1 = App.database.GetSetting1();
            if (setting1 == null)
                App.database.SaveSetting(new Setting { Name = "playInEngRus", Value = true });
            else
            {
                Setting1.BindingContext = setting1;
                Setting1.SetBinding(CheckBox.IsCheckedProperty, "Value");
            }    

            var setting2 = App.database.GetSetting2();
            if (setting2 == null)
                App.database.SaveSetting(new Setting { Name = "replayAudioRus", Value = true });
            else
            {
                Setting2.BindingContext = setting2;
                Setting2.SetBinding(CheckBox.IsCheckedProperty, "Value");
            }
            x = App.Database.GetSettings();
        }

        private void Setting1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var val = e.Value;
            var setting1 = App.database.GetSetting1();
            setting1.Value = val;
            App.database.SaveSetting(setting1);
            var x = App.Database.GetSettings();
        }

        private void Setting2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var val = e.Value;
            var setting2 = App.database.GetSetting2();
            setting2.Value = val;
            App.database.SaveSetting(setting2);
            var x = App.Database.GetSettings();
        }
    }
}