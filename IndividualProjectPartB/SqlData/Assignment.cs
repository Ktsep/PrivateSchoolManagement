namespace IndividualProjectPartB.SqlData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            Courses = new HashSet<Course>();
        }

        public int AssignmentID { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime SubDateTime { get; set; }

        public decimal OralMark { get; set; }

        public decimal TotalMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        public void ListOfAssignments(List<Assignment> assignmentList)
        {
            Console.WriteLine("Title | Description | SubDateTime | OralMark | TotalMark");
            int count = 1;
            foreach (var assi in assignmentList)
            {
                Console.WriteLine($"{count}  {assi.Title} | {assi.Description} | {assi.SubDateTime} | {assi.OralMark} | {assi.TotalMark}");
                count++;
            }
        }

        public void AssignmentsPerCourse(ProjectDBModel ProjectModel)
        {
            var assignmentsPerCourse = ProjectModel.Assignments.Include(a => a.Courses).ToList();
            foreach (var a in assignmentsPerCourse)
            {
                foreach (var c in a.Courses)
                {
                    Console.WriteLine($"Assignment {a.Title} | {a.Description} has course {c.Title} {c.Stream} {c.Type} ");
                }
            }
        }
     
        public void AssignmentsPerCourcePerStudent(ProjectDBModel projectModel)
        {
            var assignmentsPerCoursePerStudent = projectModel.Assignments.Include(a => a.Courses.Select(c => c.Students)).ToList();
            foreach (var a in assignmentsPerCoursePerStudent)
            {
                foreach (var c in a.Courses)
                {
                    foreach(var s in c.Students)
                    {
                        Console.WriteLine($"Assignment {a.Title} | {a.Description} has {c.Title} {c.Stream} course and {s.FirstName} {s.LastName} student");
                    }
                }
            }
        }
        
        public void AddAssignments(ProjectDBModel projectModel, int assignmentListCount)
        {
            Console.WriteLine("Type the number of assignments you want to add");
            int assignmentNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill the assignment's fields in the following order");
            Console.WriteLine("Title | Description | Sub date time | Oral mark | Total mark");
            for (int i = 0; i < assignmentNum; i++)
            {
                Assignment assignment = new Assignment
                {
                    Title = Console.ReadLine(),
                    Description = Console.ReadLine(),
                    SubDateTime = Convert.ToDateTime(Console.ReadLine()),
                    OralMark = Convert.ToInt32(Console.ReadLine()),
                    TotalMark = Convert.ToInt32(Console.ReadLine())
                };
                projectModel.Assignments.Add(assignment);
                projectModel.SaveChanges();
                if (i < assignmentNum -1)
                {
                    Console.WriteLine("Fill the fields of the new assignment");
                }
                List<Assignment> assignmentList = projectModel.Assignments.ToList();
                var addedAssignmentsList = assignmentList.Skip(assignmentListCount).ToList();
                Console.WriteLine("List of added assignments:");
                foreach (var added in addedAssignmentsList)
                {
                    Console.WriteLine($"{added.Title} | {added.Description} | {added.SubDateTime} | {added.OralMark} | {added.TotalMark}");
                }

            }
        }

    }
            
     
}
