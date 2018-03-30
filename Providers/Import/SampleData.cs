using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurahaxi.Providers.Import
{
    public class SampleDataImporter : IImporter
    {
        public IEnumerable<Course> Import()
        {
            var classLength = new TimeSpan(0, 45, 0);
            var classSpans = new List<ClassSpan>
            {
                null, // class 0
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
            var school = new School("中山大学", DateTime.Parse("2018-03-05"), 3, classSpans);
            var singleWeeks = Enumerable.Range(1, 3).Where(w => w % 2 == 1).ToArray();
            var course = new Course(school, "程序设计1", "专必", "陆勇", "东B403",
                new[]
                {
                    new CourseSchedule(DayOfWeek.Monday, 1, 2, singleWeeks),
                    new CourseSchedule(DayOfWeek.Sunday, 1, singleWeeks),
                });
            return new[] {course};
        }

        public Task<IEnumerable<Course>> ImportAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}