using System.Globalization;
using System.Text.RegularExpressions;

namespace _1lab
{
    public class Logic
    {
        public MeterReading ToMeterReading(string str)
        {
            var match = Regex.Match(str, @"(\w+)\s+(\d{4}-\d{2}-\d{2})\s+([\d.,]+)");

            if (!match.Success)
                throw new MeterReadingException("Неверный формат строки");

            string resourceType = match.Groups[1].Value;
            DateTime date = DateTime.Parse(match.Groups[2].Value);

           
            string valueString = match.Groups[3].Value.Replace(',', '.');
            if (!double.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                throw new MeterReadingException($"Неверный формат числа: {match.Groups[3].Value}");

            return new MeterReading(resourceType, date, value);
        }
    }
}