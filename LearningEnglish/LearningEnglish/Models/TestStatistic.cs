using System;
using System.Collections.Generic;
using System.Text;

namespace LearningEnglish.Models
{
    public class TestStatistic
    {
        public int MistakesCounter { get; set; } // Количество допущенных ошибок.
        public int WayOfControl { get; set; } // Число от 1 до 4 – номер способа контроля.
        public int CorrectAnswersOnFirstAttempt { get; set; } // Количество заданий, на которые был дан верный ответ с первой попытки.
        public int SZ { get; set; } // Общее количество слов, по которым ведётся тестирование.
        public double Rating { get; set; } // Рейтинг -- результат прохождения тестирования.
        public string TopicName { get; set; }
    }
}
