using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningEnglish.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningEnglish
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestingResultPage : ContentPage
    {
        public TestingResultPage(TestStatistic statistic)
        {
            InitializeComponent();
            BindingContext = statistic;
        }
    }
}