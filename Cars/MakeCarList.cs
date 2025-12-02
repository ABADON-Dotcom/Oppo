using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARSOPPO
{
    class MakeCarList
    {
        private List<Car> carList;

        public MakeCarList(List<string> dataList)
        {
            carList = dataList.Select(d => new Car(d)).ToList();
        }

        public void PrintCarList()
        {
            foreach (var car in carList)
                Console.WriteLine(car);
        }

        public void SortCarByMonth(string year, string month)
        {
            var filtered = carList
                .Where(c => c.Date.Year.ToString() == year &&
                            c.Date.Month.ToString("D2") == month)
                .OrderBy(c => c.Date)
                .ToList();

            foreach (var car in filtered)
                Console.WriteLine(car);
        }

        public void SortByValue()
        {
            var sorted = carList.OrderBy(c => c.Date).ToList();

            foreach (var car in sorted)
                Console.WriteLine(car);
        }

        public void ManualInsert(string data, int position = 10)
        {
            var newCar = new Car(data);

            if (position > carList.Count)
                carList.Add(newCar);
            else
                carList.Insert(position - 1, newCar);
        }

        public void PrintCarByNumber(string number)
        {
            foreach (var item in carList)
            {
                if (item.Number == number)
                    Console.WriteLine(item);
            }
        }
    }
}
