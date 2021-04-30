using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Reflection;

namespace LearningEnglish
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "MyData.db";
        public static VocabularyRepository database;
        public static VocabularyRepository Database
        {
            get
            {
                if (database == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"LearningEnglish.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new VocabularyRepository(dbPath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental"});
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
