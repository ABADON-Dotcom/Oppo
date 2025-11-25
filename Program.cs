using System.Globalization;

namespace _1lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            List<MeterReading> readings = new List<MeterReading>();

            foreach (var line in File.ReadAllLines(@"C:\Users\Asus\Desktop\Lab_1-main\Test.txt"))
            {
                try
                {
                    readings.Add(logic.ToMeterReading(line));
                }
                catch (MeterReadingException)
                {
                }
            }
            //контейнер
            var commandDescriptions = new Dictionary<string, string>
            {
                { "1", "Вывести исходные данные" },
                { "2", "Фильтр по дате" },
                { "3", "Выход из программы" }
            };

            while (true)
            {
                Console.WriteLine("\n1 - Исходные данные\n2 - Фильтр по дате\n3 - Выход");
                Console.Write("Выберите: ");

                string choice = Console.ReadLine();

                if (!commandDescriptions.ContainsKey(choice))
                {
                    Console.WriteLine("Некорректная команда");
                    continue;
                }

                Console.WriteLine($"\nВы выбрали: {commandDescriptions[choice]}");

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nИсходные данные:");
                        readings.ForEach(Console.WriteLine);
                        break;
                    case "2":
                        FilterByDate(readings);
                        break;
                    case "3":
                        return;
                }
            }
        }

        static void FilterByDate(List<MeterReading> readings)
        {
            Console.Write("Введите начальную дату (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Введите конечную дату (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var filtered = readings
                .Where(r => r.Date >= startDate && r.Date <= endDate)
                .OrderBy(r => r.Value)
                .ToList();

            Console.WriteLine($"\nПоказания с {startDate:yyyy-MM-dd} по {endDate:yyyy-MM-dd}:");
            Console.WriteLine($"Найдено {filtered.Count} записей:\n");
            filtered.ForEach(Console.WriteLine);

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
