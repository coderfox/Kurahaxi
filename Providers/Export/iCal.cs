using System;
using System.Collections.Generic;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

namespace Kurahaxi.Providers.Export
{
    // ReSharper disable once InconsistentNaming
    public class ICalExporter
    {
        public ICalExporter(IEnumerable<CourseOccurrence> occurrences)
        {
            Occurrences = occurrences;
        }

        private IEnumerable<CourseOccurrence> Occurrences { get; }

        public string GetString()
        {
            var calendar = new Calendar();
            foreach (var occurrence in Occurrences)
            {
                calendar.Events.Add(new CalendarEvent
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
                });
            }

            return new CalendarSerializer(calendar).SerializeToString();
        }
    }
}