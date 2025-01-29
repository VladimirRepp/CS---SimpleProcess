using System;
using System.Diagnostics;

// Пример работы с процессами 
namespace Sample_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sample1();
            Sample2();
        }

        /// <summary>
        /// Пример 1: создание процесса notepad.exe
        /// </summary>
        private static void Sample1()
        {
            Console.Title = "Пример 1: создание процесса notepad.exe";

            Process proc = new Process();

            // Устанвока имени файла запуска процесса 
            proc.StartInfo.FileName = "notepad.exe"; // находится в Windows/System32, иначе указываем относительный или конктретный путь для файла
            proc.Start();

            Console.WriteLine($"Запущен процесс: {proc.ProcessName}\nОжидаение завершения ...");

            proc.WaitForExit();

            Console.WriteLine($"Процесс завершен с кодом: {proc.ExitCode}");
            Console.WriteLine($"Текущий процесс имеет имя: {Process.GetCurrentProcess().ProcessName}");

            Console.ReadLine();
        }

        /// <summary>
        /// Пример 2: вывод списка процессов запущенных в OC Windows 
        /// </summary>
        private static void Sample2()
        {
            Console.Title = "Пример 2: список процессов";

            // Настраиваем консоль для красивой таблици
            Console.WindowWidth = 40;
            Console.BufferWidth = 40;

            // Получаем все запущенные процессы
            Process[] processes = Process.GetProcesses();

            // Заголовок
            Console.WriteLine(" {0, -28}{1, -10}", "Имя процесса: ", "PID:");

            foreach (Process p in processes)
                Console.Write(" {0, -28}{1, -10}", p.ProcessName, p.Id);

            Console.ReadLine();
        }
    }
}
