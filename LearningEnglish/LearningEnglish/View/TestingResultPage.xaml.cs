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
        public TestingResultPage(Result result)
        {
            InitializeComponent();
            BindingContext = result;
            //Создаем новую таблицу
            App.Database.CreateTableResult();            
            //Получаем максимальный имеющийся рейтинг
            var maxRating = App.Database.GetResults().Where(m => m.TopicId == result.TopicId && m.WayOfControlId == result.WayOfControlId).OrderByDescending(o => o.Rating).FirstOrDefault();
            var x = App.Database.GetResults();
            //Обновляем данные 
            if (maxRating == null)
            {
                App.Database.SaveResult(result);
            }
            else
            if (result.Rating > maxRating.Rating)
            {
                maxRating.Rating = result.Rating;
                App.Database.SaveResult(maxRating);
            }
        }
    }
}