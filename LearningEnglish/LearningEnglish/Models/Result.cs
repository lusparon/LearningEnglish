using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LearningEnglish
{
    [Table("Results")]
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int LevelId { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int WayOfControlId { get; set; }
        public string WayOfControlName { get; set; }
        public int Mistakes { get; set; }
        public int CorrectAnswersOnFirstAttempt { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalWordsCount { get; set; }
        public double Rating { get; set; }
    }
}
