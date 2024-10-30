using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Data
{
    public class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClassPeriod> ClassPeriods { get; set; } = null!;
        public DbSet<Classroom> Classrooms { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
    }
}