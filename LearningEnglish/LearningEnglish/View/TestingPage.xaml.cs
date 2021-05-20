﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningEnglish
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestingPage : ContentPage
    {
        private List<Word> _words;
        
        int wayOfControl; // Число от 1 до 4 – номер способа контроля.
        int taskCounter; // Количество показанных заданий.
        int mistakesCounter; // Количество допущенных ошибок.
        int localMistakesCounter; // Количество допущенных ошибок в пределах одного задания.
        int correctAnswersOnFirstAttempt; // Количество заданий, на которые был дан верный ответ с первой попытки.
        int SZ; // Общее количество слов, по которым ведётся тестирование.
        double rating; // Рейтинг -- результат прохождения тестирования.
        List<Word> used;
        Word currTask ;
        List<Word> answers; // ответы на текущее задание
        public TestingPage(Topic topic, int controlMethodId)
        {
            InitializeComponent();
            BindingContext = topic;
            wayOfControl = controlMethodId;
            taskCounter = 0;
            correctAnswersOnFirstAttempt = 0;
            mistakesCounter = 0;
            rating = 0;
            _words = GetWords(topic.Id);
            SZ = _words.Count();
            progressLabel.Text = string.Format("Выполнено {0} из {1} ({2}%)", taskCounter, SZ, 0);

            used = new List<Word>();
            NextTask();

        }

        private List<Word> GetWords(int topicId)
        {
            return App.Database.GetWords().Where(w => w.TopicId == topicId).ToList();
        }

        private void NextTask()
        {
            ClearButtons();
            
            Random rnd = new Random();
            localMistakesCounter = 0;

            var words = _words.OrderBy(s => rnd.NextDouble()).ToList();
            var item = words.First();

            while (used.Contains(item)) 
            {
                words = _words.OrderBy(s => rnd.NextDouble()).ToList();
                item = words.First();
            }

            used.Add(item);
            currTask = item;
            words.Remove(currTask);
            answers = words.Take(4).ToList();
            answers.Insert(rnd.Next(5), currTask);
            FillPage();
        }

        private void ClearButtons()
        {
            for (var i = 1; i < 6; i++)
                ((Button)Content.FindByName("answer" + i)).BackgroundColor = Color.Default;
        }

        private void FillPage()
        {
            switch (wayOfControl)
            {
                case 1:
                    taskName.Text = currTask.Rus;
                    for (var i = 1; i < 6; i++)
                        ((Button)Content.FindByName("answer" + i)).Text = answers[i-1].Eng;
                    break;
                case 2:
                    taskName.Text = currTask.Eng;
                    for (var i = 1; i < 6; i++)
                        ((Button)Content.FindByName("answer" + i)).Text = answers[i-1].Rus;
                    PlayAudio();
                    break;
                case 3:
                    taskName.Text = "Воспроизвести повторно";
                    for (var i = 1; i < 6; i++)
                        ((Button)Content.FindByName("answer" + i)).Text = answers[i-1].Rus;
                    PlayAudio();
                    break;
            }            
        }

        private void PlayAudio()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            var mp3Path = currTask.Mp3Path.Replace("\\", "/");
            var path = Path.Combine("Sounds", mp3Path + ".mp3");
            player.Load(path);
            player.Play();
        }

        private async void AnswerClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var selectedAnswer = answers.FirstOrDefault(w => wayOfControl == 1 ? w.Eng == btn.Text : w.Rus == btn.Text);
            if (currTask == selectedAnswer)
            {
                taskCounter++;
                progressBar.Progress = taskCounter*1.0/SZ;

                double percent = Math.Round(taskCounter * 100.0 / SZ, 2);
                progressLabel.Text = string.Format("Выполнено {0} из {1} ({2}%)", taskCounter, SZ,percent);

                if (localMistakesCounter == 0)
                    correctAnswersOnFirstAttempt++;
                switch (localMistakesCounter)
                {
                    case 0: rating += (double)50 / SZ; break;
                    case 1: rating += (double)25 / SZ; break;
                    case 2: rating += 12.5 / SZ; break;
                    case 3: rating += 6.25 / SZ; break;
                    case 4: break;
                }
                // Если тестирование не завершено, выводим следующее задание.
                if (taskCounter < SZ)
                    NextTask();
                // Если тестирование завершено, передаём результаты
                else
                {
                    await Navigation.PopAsync();
                }
            }
            else if (btn.BackgroundColor != Color.Red)
            {
                btn.BackgroundColor = Color.Red;
                mistakesCounter++;
                localMistakesCounter++;
            }
        }

        private void TaskNameClicked(object sender, EventArgs e)
        {
            if (wayOfControl != 1)
                PlayAudio();
        }
    }
}