using System.Collections.Generic;

namespace Lab5.Models
{
    public class Classroom
    {
        public Classroom()
        {
            Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}