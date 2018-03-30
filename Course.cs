using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kurahaxi
{
    public class Course
    {
        public Course(School school, string name, string type, string teacher, string place,
            IEnumerable<CourseSchedule> schedules)
        {
            School = school;
            Name = name;
            Type = type;
            Teacher = teacher;
            Place = place;
            Schedules = schedules;
        }

        public School School { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Teacher { get; set; }
        public string Place { get; set; }
        public IEnumerable<CourseSchedule> Schedules { get; set; }

        public IEnumerable<CourseOccurrence> Occurrences
        {
            get
            {
                var occurrences = new Collection<CourseOccurrence>();
                foreach (var schedule in Schedules)
                {
                    var classSpan = schedule.GetClassSpan(School);
                    for (var today = School.TermStart;
                        today < School.TermStart.AddDays(School.TermWeeks * 7);
                        today = today.AddDays(1))
                    {
                        if (today.DayOfWeek != schedule.Weekday) continue;
                        if (!schedule.Weeks.Contains((today - School.TermStart).Days / 7 + 1)) continue;
                        var startTime = today + classSpan.Start;
                        var endTime = today + classSpan.End;
                        var occurrence = new CourseOccurrence(startTime, endTime);
                        occurrences.Add(occurrence);
                    }
                }

                return occurrences;
            }
        }
    }
}