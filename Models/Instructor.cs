using System.Collections.Generic;

namespace Lab5.Models
{
    public class Instructor
    {
        public Instructor()
        {
            Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}