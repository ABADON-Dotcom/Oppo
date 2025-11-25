using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CARSOPPO
{
    internal class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines(@"C:\\Users\\crete\\source\\repos\\CARSOPPO\\CARSOPPO\\data.txt").ToList();
            var carList = new MakeCarList(lines);

            Console.WriteLine("Полный список:");
            carList.PrintCarList();

            Console.WriteLine("\nАвтомобили за 1000.01:");
            carList.SortCarByMonth("1000", "01");

            Console.WriteLine("\nПоиск G044NT124:");
            carList.PrintCarByNumber("G044NT124");

            Console.WriteLine("\nСортировка по дате:");
            carList.SortByValue();

            Console.WriteLine("\nПосле добавления нового автомобиля:");
            carList.ManualInsert("\"НОВЫЙ123\" 2024.01.15");
            carList.PrintCarList();
            Console.ReadLine();
        }
    }
}