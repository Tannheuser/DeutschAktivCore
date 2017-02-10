using System;

namespace DeutschAktiv.Core.Models
{
    public class ScheduleItem : Event
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Teacher { get; set; }
    }
}