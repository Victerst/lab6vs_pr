using System;

namespace lab6v_p.Models
{
    public class DailyPlanner
    {
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public string Todo { get; set; }
        public DailyPlanner(string name, string todo, DateTimeOffset date)
        {
            Name = name;
            Todo = todo;
            Date = date;
        }
    }
}