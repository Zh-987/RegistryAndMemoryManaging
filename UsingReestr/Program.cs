using System;
using Microsoft.Win32;

namespace UsingReestr
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * СОздание нового ключа в реестре
             * RegistryKey newUserKey = Registry.CurrentUser;
            RegistryKey newSubKey = newUserKey.CreateSubKey("ItStep");

            newSubKey.SetValue("login", "qwerty");
            newSubKey.SetValue("password", "qwerty1234");
            newSubKey.Close();*/


            /* 
             Работа с вложением ключа в старый реестр
             

            RegistryKey newUserKey = Registry.CurrentUser;
            RegistryKey newSubKey = newUserKey.OpenSubKey("ItStep", true);
            RegistryKey ItStepSubKey = newSubKey.CreateSubKey("System Programming");
            ItStepSubKey.SetValue("qwerty","qwerty123");
            ItStepSubKey.Close();
            newSubKey.Close();
            */
            /*
             * Считывание данных из реестра
           
            RegistryKey newUserKey = Registry.CurrentUser;
            RegistryKey newSubKey = newUserKey.OpenSubKey("ItStep", true);
            string login = newSubKey.GetValue("login").ToString();
            string password = newSubKey.GetValue("password").ToString();
            RegistryKey ItStepSubKey = newSubKey.OpenSubKey("System Programming", true);
            string qwerty = ItStepSubKey.GetValue("qwerty").ToString();
            ItStepSubKey.Close();
            newSubKey.Close();

            Console.WriteLine(login); 
            Console.WriteLine(password);
            Console.WriteLine(qwerty);
              */
            /*
             Удаление значения внутри реестра


             RegistryKey newUserKey = Registry.CurrentUser;
             RegistryKey newSubKey = newUserKey.OpenSubKey("ItStep", true);

              newSubKey.DeleteSubKey("System Programming");

              newSubKey.DeleteValue("password");

              newSubKey.Close();

             newUserKey.DeleteSubKey("ItStep"); */

            Test();

            long totalMemory = GC.GetTotalMemory(true);

            GC.Collect(0,GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();
        }


        static void Test()
        {
            /* Managing managing = new Managing();
             managing.Name = "qwerty";
             Console.WriteLine(managing.Name);*/

            Managing? managing = null;
            try
            {
                 managing = new Managing("Qwerty");
            }
            finally
            {
                managing?.Dispose();
            }
        }
    }
    class Managing:IDisposable
    {
        private bool disposed = false;
        public string Name { get; set; }
        public Managing(string name) => Name = name;
        /* ~Managing()
         {
             Console.WriteLine($"{Name} has deleted");
         }*/

        public void Dispose()
        {
            /*Console.WriteLine($"{Name} has deleted");*/
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
            }
            // Освобождаем не управляемые ресурсы
            disposed = true;
        }

        ~Managing()
        {
            Dispose(false);
        }

    }
}
