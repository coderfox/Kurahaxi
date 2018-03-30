using System;

namespace Kurahaxi
{
    public class ClassSpan
    {
        public TimeSpan Start { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan End
        {
            get => Start + Duration;
        }

        public ClassSpan(TimeSpan start, TimeSpan duration)
        {
            Start = start;
            Duration = duration;
        }

        public ClassSpan(string start, TimeSpan duration)
            : this(TimeSpan.Parse(start), duration)
        {

        }
    }
}