namespace IndividualProjectPartB.SqlData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectDBModel : DbContext
    {
        public ProjectDBModel()
            : base("name=ProjectDBModel")
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.OralMark)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.TotalMark)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Assignments)
                .Map(m => m.ToTable("AssignmentsPerCourse").MapLeftKey("AssignmentID").MapRightKey("CourseID"));

            modelBuilder.Entity<Course>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Stream)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("StudentsPerCourse").MapLeftKey("CourseID").MapRightKey("StudentID"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Trainers)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("TrainersPerCourse").MapLeftKey("CourseID").MapRightKey("TrainerID"));

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.TuitionFees)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Subject)
                .IsUnicode(false);
        }
    }
}
