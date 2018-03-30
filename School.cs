using System;
using System.Collections.Generic;

namespace Kurahaxi
{
    public class School
    {
        public School(string name, DateTime termStart, int termWeeks, IList<ClassSpan> classSpans)
        {
            Name = name;
            TermStart = termStart;
            TermWeeks = termWeeks;
            ClassSpans = classSpans;
        }

        public string Name { get; set; }
        public IList<ClassSpan> ClassSpans { get; set; }
        public DateTime TermStart { get; set; }
        public int TermWeeks { get; set; }
        
        public DateTime TermEnd => TermStart.AddDays(TermWeeks * 7);
    }
}