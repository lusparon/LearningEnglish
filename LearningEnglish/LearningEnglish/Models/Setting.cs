using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LearningEnglish
{
    [Table("Settings")]
    public class Setting
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Value { get; set; }
    }
}
