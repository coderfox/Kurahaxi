using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

namespace Kurahaxi.Providers.Export
{
    // ReSharper disable once InconsistentNaming
    public class ICalExporter : IExporter
    {
        public ICalExporter(IEnumerable<Course> courses)
        {
            var occurrences = courses.SelectMany(c => c.Occurrences);
            Calendar = new Calendar();
            Calendar.Events.AddRange(
                occurrences.Select(occurrence => new CalendarEvent
                {
                    Summary = occurrence.Course.Name,
                    Description = string.Format("[{0}]{1} - {2}",
                        occurrence.Course.Type,
                        occurrence.Course.Name,
                        occurrence.Course.Teacher),
                    Location = occurrence.Course.Place,
                    Start = new CalDateTime(occurrence.Start),
                    End = new CalDateTime(occurrence.End),
                    Alarms =
                    {
                        new Alarm()
                        {
                            Summary = string.Format("Your next course is {0} at {1} in 5 minutes.",
                                occurrence.Course.Name,
                                occurrence.Course.Place),
                            Action = AlarmAction.Display,
                            Trigger = new Trigger(TimeSpan.FromMinutes(-5))
                        }
                    }
                })
            );
        }

        private Calendar Calendar { get; set; }

        public void Export()
        {
            var fs = new StreamWriter("class_table.ics");
            new CalendarSerializer().Serialize(Calendar, fs.BaseStream, Encoding.UTF8);
        }

        public Task ExportAsync()
        {
            throw new NotImplementedException();
        }
    }
}