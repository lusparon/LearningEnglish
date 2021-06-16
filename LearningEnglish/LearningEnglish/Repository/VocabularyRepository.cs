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
        public int SaveResult(Result item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public int SaveSetting(Setting item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public void CreateTableResult()
        {
            var x = database.CreateTable<Result>();
        }

        public void CreateTableSetting()
        {
            var x = database.CreateTable<Setting>();
        }

        public void DropTableResult()
        {
            var x = database.DropTable<Result>();
        }
        public IEnumerable<Result> GetResults()
        {
            return database.Table<Result>().ToList();
        }

        public IEnumerable<Setting> GetSettings()
        {
            return database.Table<Setting>().ToList();
        }
        
        public Setting GetSetting1()
        {
            return database.Table<Setting>().FirstOrDefault(w => w.Name.Equals("playInEngRus"));
        }
        public Setting GetSetting2()
        {
            return database.Table<Setting>().FirstOrDefault(w => w.Name.Equals("replayAudioRus"));
        }
    }
}
