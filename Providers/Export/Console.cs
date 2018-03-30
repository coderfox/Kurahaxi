using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurahaxi.Providers.Export
{
    public class ConsoleExporter : IExporter
    {
        private readonly IEnumerable<Course> _courses;

        public ConsoleExporter(IEnumerable<Course> courses)
        {
            _courses = courses;
        }

        public void Export()
        {
            foreach (var occurrence in _courses.SelectMany(c => c.Occurrences))
            {
                Console.WriteLine("[{0}]{1} - {2}\n\tin {3} from {4:MM/dd HH:mm} to {5:MM/dd HH:mm}",
                    occurrence.Course.Type,
                    occurrence.Course.Name,
                    occurrence.Course.Teacher,
                    occurrence.Course.Place,
                    occurrence.Start,
                    occurrence.End);
            }
        }

        public Task ExportAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}