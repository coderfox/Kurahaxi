using System;
using System.Collections.Generic;
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

        public IEnumerable<CourseOccurrence> Occurrences => Schedules.SelectMany(schedule =>
        {
            var (start, end) = schedule.GetTimeSpan(School);
            return schedule.GetDates(School).Select(date =>
                new CourseOccurrence(this, date + start, date + end));
        });
    }
}