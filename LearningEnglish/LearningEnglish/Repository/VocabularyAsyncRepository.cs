using SQLite;
using System.Collections.Generic;

namespace LearningEnglish
{
    public class VocabularyRepository
    {
        SQLiteConnection database;
        public VocabularyRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
        }
        public IEnumerable<Topic> GetTopics()
        {
            return database.Table<Topic>().ToList();
        }
        public Topic GetTopic(int id)
        {
            return database.Get<Topic>(id);
        }
        public IEnumerable<Word> GetWords()
        {
            return database.Table<Word>().ToList();
        }
        public Word GetWord(int id)
        {
            return database.Get<Word>(id);
        }
        //public int DeleteItem(int id)
        //{
        //    return database.Delete<Topic>(id);
        //}
        //public int SaveItem(Topic item)
        //{
        //    if (item.Id != 0)
        //    {
        //        database.Update(item);
        //        return item.Id;
        //    }
        //    else
        //    {
        //        return database.Insert(item);
        //    }
        //}
    }
}
