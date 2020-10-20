namespace IndividualProjectPartB.SqlData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int StudentID { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public decimal TuitionFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        public void ListOfStudents(ProjectDBModel ProjectModel)
        {
            var studentList = ProjectModel.Students.ToList();
            Console.WriteLine("Firstname | Lastname | DateOfBirth | TuitionFees");
            int count = 1;
            foreach (var stud in studentList)
            {
                Console.WriteLine($"{count} {stud.FirstName} | {stud.LastName} | {stud.DateOfBirth.ToShortDateString()} | {stud.TuitionFees}");
                count++;
            }
        }

        public void StudentsPerCourse(ProjectDBModel projectModel)
        {
            var studentsPerCourse = projectModel.Students.Include(s => s.Courses).ToList();
            foreach (var s in studentsPerCourse)
            {
                foreach (var c in s.Courses)
                {
                    Console.WriteLine($"{s.FirstName} {s.LastName} has cource {c.Title} {c.Stream} {c.Type}");
                }
            }
        }
      
        public void AddStudents(ProjectDBModel projectModel, int studentListCount)
        {
            Console.WriteLine("Type the number of students you want to add");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill the student's fields in the following order");
            Console.WriteLine("First name | Last name | Date of birth | Tuition fees");
            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = new Student
                {
                    FirstName = Console.ReadLine(),
                    LastName = Console.ReadLine(),
                    DateOfBirth = Convert.ToDateTime(Console.ReadLine()),
                    TuitionFees = Convert.ToDecimal(Console.ReadLine())
                };
                projectModel.Students.Add(student);
                projectModel.SaveChanges();
                if (i < numberOfStudents -1)
                {
                    Console.WriteLine("Fill the fields of the new student");
                }
                List<Student> studentList = projectModel.Students.ToList();
                var addedStudentsList = studentList.Skip(studentListCount).ToList();
                Console.WriteLine("List of added students:");
                foreach (var std in addedStudentsList)
                {
                    Console.WriteLine($"{std.FirstName} | {std.LastName} | {std.DateOfBirth.ToShortDateString()} | {std.TuitionFees}");
                }
            }
        }
        
         public void StudentsWithMoreThanOneCourses(ProjectDBModel projectModel)
         {
            var studCourses = projectModel.Students
                .Include(s => s.Courses).Where(s => s.Courses.Count > 1)
                .Select(s => new { s.FirstName, s.LastName }).ToList();

            foreach ( var s in studCourses)
            {
                Console.WriteLine($"{s.FirstName} {s.LastName}");
            }

         }

    }

}
