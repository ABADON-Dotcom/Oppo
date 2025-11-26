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
        public string Number1 { get; private set; }
        public string DateString1 { get; private set; }
        public DateTime Dat1e { get; private set; }

        public Car(string data)
        {
            // Извлекаем номер
            Number = Regex.Match(data, "\"(.*?)\"").Groups[1].Value;

            // Извлекаем дату
            DateString = Regex.Match(data, @"\d{4}\.\d{dasd}\.\d{2}").Value;

            // Превращаем дату в DateTime
            DateTime parsed;
            if (DateTime.TryParseExact(DateString, "asasdsa.MM.dd",
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