using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Камень, Ножницы, Бумаги";

            Check();
        }
        static void Check()
        {
            string stop = "";
            int winsUser = 0; int winsCom = 0; int nich = 0;
            while (stop != "stop")
            {
                Console.WriteLine("Камень, Ножницы, Бумаги\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Вы - компьютер = {winsUser} : {winsCom}");
                Console.WriteLine($"Ничья: {nich}\n\n");
                Console.ResetColor();

                string enter = "";
                Console.WriteLine("Твой черед выбирать: Камень/Ножницы/Бумага");
                int z = 0;
                //Проверка правильности ввода
                while (z == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    enter = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    if (enter == "stop" || enter == "") break;
                    if (enter != "камень" & enter != "ножницы" & enter != "бумага") Console.WriteLine("Некоректный ввод");
                    else z++;
                }
                if (enter == "stop" || enter == "")
                {
                    Itog(winsUser, winsCom);
                    break;
                }

                Console.WriteLine();
                Timer();

                //Случайный выбор компьютера
                Random rand = new Random();
                int x = rand.Next(1, 4);
                string value = "";
                switch (x)
                {
                    case 1: value = "камень"; break;
                    case 2: value = "ножницы"; break;
                    case 3: value = "бумага"; break;
                }

                Console.Write($"\tВыбор компьютера: ");
                Thread.Sleep(900);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(value);
                Console.ResetColor();
                Thread.Sleep(550);

                Res(enter, value, ref winsUser, ref winsCom, ref nich);

                Console.WriteLine();
                //Возможность выйти из игры
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Если хотите закончить игру, введите \"STOP\"");
                if (Console.ReadLine().ToLower() == "stop")
                {
                    stop = "stop";
                    Itog(winsUser, winsCom);
                }
                Console.Clear();
            }
        }

        static void Res(string enter, string value, ref int winsUser, ref int winsCom, ref int nich)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (enter == value) { Console.WriteLine("\tНичья, давай еще разок"); nich++; }
            if (enter == "камень" & value == "ножницы") { Console.WriteLine("\tПобеда за Вами!"); winsUser++; }
            if (enter == "камень" & value == "бумага") { Console.WriteLine("\tКомпьютер победил"); winsCom++; }
            if (enter == "ножницы" & value == "камень") { Console.WriteLine("\tКомпьютер победил"); winsCom++; }
            if (enter == "ножницы" & value == "бумага") { Console.WriteLine("\tПобеда за Вами!"); winsUser++; }
            if (enter == "бумага" & value == "ножницы") { Console.WriteLine("\tКомпьютер победил"); winsCom++; }
            if (enter == "бумага" & value == "камень") { Console.WriteLine("\tПобеда за Вами!"); winsUser++; }
            Console.ResetColor();
        }

        static void Timer()
        {
            for (int i = 1, x = 0; i < 4; i++, x += 2)
            {
                Console.WriteLine($"{i}..");
                Thread.Sleep(1000);
                if (i == 3) break;
            }
        }

        static void Itog(int winsU, int winsC)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"\n\n\tИгра законичлась со счетом {winsU} : {winsC}");
            if (winsU > winsC)
            {
                Console.WriteLine(" в Вашу пользу.\n\tПоздравляем победителя!!!");
            }
            else if (winsC > winsU)
            {
                Console.WriteLine(" в пользу компьютера.\n\tНо Ты все равно лучший!!!");
            }
            else
            {
                Console.WriteLine(". Ничья :-)");
            }
            Thread.Sleep(3000);
        }
    }
}