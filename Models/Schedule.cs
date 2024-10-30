using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Group is required")]
        [Display(Name = "Group")]
        public int GroupId { get; set; }
        
        public virtual Group? Group { get; set; }

        [Required(ErrorMessage = "Instructor is required")]
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }
        
        public virtual Instructor? Instructor { get; set; }

        [Required(ErrorMessage = "Classroom is required")]
        [Display(Name = "Classroom")]
        public int ClassroomId { get; set; }
        
        public virtual Classroom? Classroom { get; set; }

        [Required(ErrorMessage = "Class Period is required")]
        [Display(Name = "Time")]
        public int ClassPeriodId { get; set; }
        
        public virtual ClassPeriod? ClassPeriod { get; set; }
    }
}