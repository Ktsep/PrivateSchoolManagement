namespace IndividualProjectPartB.SqlData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            Students = new HashSet<Student>();
            Trainers = new HashSet<Trainer>();
        }

        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Stream { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime End_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }

        public void ListOfCourses(List<Course> courseList)
        {
            Console.WriteLine("Title | Stream | Type | StartDate | EndDate");
            int count = 1;
            foreach (var crs in courseList)
            {
                Console.WriteLine($"{count} {crs.Title} | {crs.Stream} | {crs.Type} {crs.Start_Date.ToShortDateString()} | {crs.End_Date.ToShortDateString()}");
                count++;
            }
        }


        public void AddCourses(ProjectDBModel projectModel, int courseListCount)
        {
            Console.WriteLine("Type number of the courses you want to add");
            int numberOfCourses = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill course's fields in the following order");
            Console.WriteLine("Title | Stream | Type | Start_Date | End_Date");
            for (int i = 0; i < numberOfCourses; i++)
            {
                Course course = new Course
                {
                    Title = Console.ReadLine(),
                    Stream = Console.ReadLine(),
                    Type = Console.ReadLine(),
                    Start_Date= Convert.ToDateTime(Console.ReadLine()),
                    End_Date = Convert.ToDateTime(Console.ReadLine())
                };
                projectModel.Courses.Add(course);
                projectModel.SaveChanges();
                if (i < numberOfCourses)
                {
                    Console.WriteLine("Type properties of new course");
                }
            }
            List<Course> courseList = projectModel.Courses.ToList();
            var addedCoursesList = courseList.Skip(courseListCount).ToList();
            Console.WriteLine("List of added courses:");
            foreach (var crs in addedCoursesList)
            {
                Console.WriteLine($"{crs.Title} | {crs.Stream} | {crs.Type} | {crs.Start_Date} | {crs.End_Date}");
            }
        }


    }
}
