using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CARSOPPO
{
    class Car
    {
        public string Number { get; private set; }
        public string DateString { get; private set; }
        public DateTime Date { get; private set; }

        public Car(string data)
        {
            // Извлекаем номер
            Number = Regex.Match(data, "\"(.*?)\"").Groups[1].Value;

            // Извлекаем дату
            DateString = Regex.Match(data, @"\d{4}\.\d{2}\.\d{2}").Value;

            // Превращаем дату в DateTime
            DateTime parsed;
            if (DateTime.TryParseExact(DateString, "yyyy.MM.dd",
                                       null,
                                       System.Globalization.DateTimeStyles.None,
                                       out parsed))
            {
                Date = parsed;
            }
            else
            {
                Date = DateTime.MinValue;
            }
        }

        public override string ToString()
        {
            return $"{Number}  {DateString}";
        }
    }
}
