using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LearningEnglish
{
    [Table("Words")]
    public class Word
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Mp3Path { get; set; }
        public string Rus { get; set; }
        public string Eng { get; set; }
    }
}
