namespace IndividualProjectPartB.SqlData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            Courses = new HashSet<Course>();
        }

        public int TrainerID { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        public void ListOfTrainers(List<Trainer> trainerList)
        {
            Console.WriteLine("Firstname | Lastname | Subject");
            int count = 1;
            foreach (var tra in trainerList)
            {
                Console.WriteLine($"{count} {tra.FirstName} | {tra.LastName} | {tra.Subject}");
                count++;
            }
        }
        public void TrainersPerCourse(ProjectDBModel projectModel)
        {
            var trainersPerCource = projectModel.Trainers.Include(a => a.Courses).ToList();
            foreach (var a in trainersPerCource)
            {
                foreach (var c in a.Courses)
                {
                    Console.WriteLine($"Trainer {a.FirstName} {a.LastName} has course {c.Title} {c.Stream} {c.Type}");
                }
                
            }
        }
        public void AddTrainers(ProjectDBModel projectModel, int trainerListCount)
        {
            Console.WriteLine("Type the number of trainers you want to add");
            int numberOfTrainers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill the trainer's fields in the following order");
            Console.WriteLine("First name | Last name | Subject");
            for (int i = 0; i < numberOfTrainers; i++)
            {
                Trainer trainer = new Trainer
                {
                    FirstName = Console.ReadLine(),
                    LastName = Console.ReadLine(),
                    Subject = Console.ReadLine()
                };
                projectModel.Trainers.Add(trainer);
                projectModel.SaveChanges();
                if (i < numberOfTrainers -1)
                {
                    Console.WriteLine("Fill the fields of the new trainer");
                }
            }
            List<Trainer> trainerList = projectModel.Trainers.ToList();
            var addedTrainersList = trainerList.Skip(trainerListCount).ToList();
            Console.WriteLine("List of added trainers:");
            foreach (var  tra in addedTrainersList)
            {
                Console.WriteLine($"{tra.FirstName} | {tra.LastName} | {tra.Subject}");
            }
        }
    }
}