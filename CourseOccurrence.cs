using System;

namespace Kurahaxi
{
    public class CourseOccurrence
    {
        public CourseOccurrence(Course course, DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            Course = course;
        }

        public Course Course { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public new string ToString()
        {
            return string.Format("CourseOccurrence: {0} -> {1}", Start, End);
        }
    }
}