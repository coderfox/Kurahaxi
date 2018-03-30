using System;
using System.Collections.Generic;
using System.Linq;

namespace Kurahaxi
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once ArrangeTypeModifiers
    class Program
    {
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            #region Class Span Init

            var classLength = new TimeSpan(0, 45, 0);
            var classSpans = new List<ClassSpan>
            {
                null,                                // class 0
                new ClassSpan("08:00", classLength), // class 1
                new ClassSpan("08:55", classLength),
                new ClassSpan("10:00", classLength),
                new ClassSpan("10:55", classLength),
                new ClassSpan("14:20", classLength),
                new ClassSpan("15:15", classLength),
                new ClassSpan("16:20", classLength),
                new ClassSpan("17:15", classLength),
                new ClassSpan("19:00", classLength),
                new ClassSpan("19:55", classLength),
                new ClassSpan("20:50", classLength),
            };

            #endregion

            var school = new School("中山大学", DateTime.Parse("2018-03-05"), 3, classSpans);
            var singleWeeks = Enumerable.Range(1, 3).Where(w => w % 2 == 1).ToArray();
            var course = new Course(school, "程序设计1", "专必", "陆勇", "东B403",
                new List<CourseSchedule>(new[]
                {
                    new CourseSchedule(DayOfWeek.Monday, 1, 2, singleWeeks),
                    new CourseSchedule(DayOfWeek.Sunday, 1, singleWeeks),
                }));

            foreach (var occurrence in course.Occurrences.OrderBy(o => o.Start))
            {
                // Console.WriteLine(occurrence.ToString());
            }

            Console.WriteLine(new Providers.Export.ICalExporter(course.Occurrences).GetString());
        }
    }
}