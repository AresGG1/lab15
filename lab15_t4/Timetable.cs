using System;

namespace lab15_t4
{
    public struct Timetable
    {
        public string nazv;
        public int numr;
        public DateTime date;
        public TimeSpan time;
        public override string ToString()
        {
            return $"Train: {this.nazv}, {this.numr}, {this.date.Year}:{this.date.Month}:{this.date.Day}, {this.time.Hours}:{this.time.Minutes}:{this.time.Seconds}";
        }
    }
}