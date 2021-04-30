using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LearningEnglish
{
    [Table("Topics")]
    public class Topic
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
    }
}
