﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningEnglish
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonTeachingClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeachingPage());
        }

        private async void ButtonControlClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ControlPage());
        }

        private async void ButtonResultsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultsPage());
        }

        private async void ButtonSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void ButtonHelpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }
    }
}
