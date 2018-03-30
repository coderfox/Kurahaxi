using System;
using System.Collections.Generic;

namespace Kurahaxi
{
    public class CourseSchedule
    {
        public DayOfWeek Weekday { get; set; }
        public int ClassNo { get; set; }
        public IEnumerable<int> Weeks { get; set; }

        public CourseSchedule(DayOfWeek weekday, int classNo, IEnumerable<int> weeks)
        {
            Weekday = weekday;
            ClassNo = classNo;
            Weeks = weeks;
        }

        public ClassSpan GetClassSpan(School school) => school.ClassSpans[ClassNo];
    }
}