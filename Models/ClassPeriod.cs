using System.Collections.Generic;

namespace Lab5.Models
{
    public class ClassPeriod
    {
        public ClassPeriod()
        {
            Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        public string Time { get; set; } = string.Empty;
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}