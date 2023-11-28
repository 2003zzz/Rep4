using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
namespace LINQApp
{
    internal class Program
    {
        public class Sportsmen
        {
            public string surname { get; set; }
            public string Stype { get; set; }
            public int place { get; set; }
        }

        static void Main(string[] args)
        {
            List <Sportsmen> sport = new List<Sportsmen>();
            string[] lines = System.IO.File.ReadAllLines("..\\..\\..\\..\\LINQApp\\data.txt");

            Console.WriteLine("Исходный список спортсменов\n::::::::::::::::::::::::");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            string[] parts = null;
            foreach (string line in lines)
            {
                parts = line.Split(' ');
                sport.Add(new Sportsmen { surname = parts[0], Stype = parts[1], place = int.Parse(parts[2]) });
            }

            // фильтрация
            var prizeSpotsmen =
                sport.Where(s => (s.Stype == "Фехтование" || s.Stype == "Плавание") && s.place <= 3);

            Console.WriteLine(":::::::::::::::::::::::\nФильтрация по спортсменам\nзанявшие призовые места по плаванию и фехтованию");
            foreach (var sportsman in prizeSpotsmen)
            {
                Console.WriteLine($"{sportsman.surname} {sportsman.Stype} {sportsman.place}");
            }

            //сортировка
            Console.WriteLine("\nСортировка по фамилии и месту");
            var sorted = sport
                .OrderBy(s => s.surname)
                .ThenBy(s => s.place);
            foreach (var sportsman in sorted)
            {
                Console.WriteLine($"{sportsman.surname} {sportsman.Stype} {sportsman.place}");
            }

            //группивка по виду спорта
            Console.WriteLine("\nГруппировка по виду спорта\n");
            var groupSType = sport.GroupBy(s => s.Stype);
            foreach (var sportsman in groupSType)
            {
                Console.WriteLine(sportsman.Key.ToUpper());
                foreach (var sp in sportsman)
                {
                    Console.WriteLine(sp.surname);
                }
                Console.Write("\n");
            }

            //группировка с количеством
            Console.WriteLine("Группировка по виду спорта \nс подсчётом количества в каждой группе:\n");
            var groupStypeCount = sport.GroupBy(s => s.Stype)
                .Select(t => new { sport = t.Key, count = t.Count() });

            foreach (var group in groupStypeCount)
            {
                Console.WriteLine("Вид спорта: " + group.sport);
                Console.WriteLine("Количество: " + group.count + " чел");
                Console.WriteLine();
            }

            var count = sport.Count(s => "бвгджзйклмнпрстфхцчшщ".Contains(s.surname.ToLower()[0]));
            Console.WriteLine($"Количество спортсменов, чьи фамилии начинаются с согласной буквы равно: {count}");

            Console.WriteLine("\nОбьединение двух последовательностей\n");
            string[] s = System.IO.File.ReadAllLines("..\\..\\..\\..\\LINQApp\\data2.txt");
            List<Sportsmen> sport_ = new List<Sportsmen>();
            string[] str = null;
            foreach (string line in s)
            {
                str = line.Split(' ');
                sport_.Add(new Sportsmen { surname = str[0], Stype = str[1], place = int.Parse(str[2]) });
            }
            var resUnion = sport.Union(sport_);
            int i = 0;
            foreach (Sportsmen line in resUnion)
            {
                i++;
                Console.WriteLine($"{i} - {line.surname} {line.Stype} {line.place}");
            }
            Console.ReadKey();
        }
    }
}

