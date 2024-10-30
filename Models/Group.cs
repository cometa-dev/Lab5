using System.Collections.Generic;

namespace Lab5.Models
{
    public class Group
    {
        public Group()
        {
            Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
        public int NumberOfStudents { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}