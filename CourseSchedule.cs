using System;
using System.Collections.Generic;

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

        public (TimeSpan start, TimeSpan end) GetTime(School school) => (GetStartTime(school), GetEndTime(school));
        public TimeSpan GetStartTime(School school) => school.ClassSpans[ClassNo].Start;
        public TimeSpan GetEndTime(School school) => school.ClassSpans[ClassNo + ClassLength - 1].End;
    }
}