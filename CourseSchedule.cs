using System;
using System.Collections.Generic;
using System.Linq;

namespace Kurahaxi
{
    public class CourseSchedule
    {
        public DayOfWeek Weekday { get; set; }
        public int ClassNo { get; set; }
        public int ClassLength { get; set; }
        public IEnumerable<int> Weeks { get; set; }

        public CourseSchedule(DayOfWeek weekday, int classNo, int classLength, IEnumerable<int> weeks)
        {
            Weekday = weekday;
            ClassNo = classNo;
            Weeks = weeks;
            ClassLength = classLength;
        }

        public CourseSchedule(DayOfWeek weekday, int classNo, IEnumerable<int> weeks)
            : this(weekday, classNo, 1, weeks)
        {
        }

        [Obsolete]
        public ClassSpan GetClassSpan(School school) => school.ClassSpans[ClassNo];

        public (TimeSpan start, TimeSpan end) GetTimeSpan(School school) =>
            (GetStartTimeSpan(school), GetEndTimeSpan(school));
        public TimeSpan GetStartTimeSpan(School school) => school.ClassSpans[ClassNo].Start;
        public TimeSpan GetEndTimeSpan(School school) => school.ClassSpans[ClassNo + ClassLength - 1].End;

        public int GetWeekdayOffset(School school)
        {
            var weekdayOffset = Weekday - school.TermStart.DayOfWeek;
            if (weekdayOffset < 0) weekdayOffset += 7;
            return weekdayOffset;
        }

        public IEnumerable<DateTime> GetDates(School school) =>
            Weeks.Select(w => school.TermStart.AddDays((w - 1) * 7 + GetWeekdayOffset(school)));

        public IEnumerable<(DateTime start, DateTime end)> GetTimes(School school) => GetDates(school).Select(date =>
            (date + GetStartTimeSpan(school), date + GetEndTimeSpan(school)));

        public IEnumerable<int> GetExcludedWeeks(School school)
        {
            return Enumerable.Range(1, school.TermWeeks).Where(w => !Weeks.Contains(w));
        }
    }
}