using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1lab
{
    public class MeterReading
    {
        public string ResourceType { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public MeterReading(string resourceType, DateTime date, double value)
        {
            ResourceType = resourceType;
            Date = date;
            Value = value;
        }
        public override string ToString()
        {
            return $"Ресурс: {ResourceType}; Дата: {Date:yyyy-MM-dd}; Значение: {Value:F2}";
        }
    }
}