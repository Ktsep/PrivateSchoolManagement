using IndividualProjectPartB.SqlData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IndividualProjectPartB
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProjectDBModel projectModel = new ProjectDBModel();

            List<Student> studentList = projectModel.Students.ToList();
            Student student = new Student();

            List<Trainer> trainerList = projectModel.Trainers.ToList();
            Trainer trainer = new Trainer();

            List<Assignment> assignmentList = projectModel.Assignments.ToList();
            Assignment assignment = new Assignment();

            List<Course> courseList = projectModel.Courses.ToList();
            Course course = new Course();

            bool menuFlag = true;
            bool SelectFlag = true;
            bool AddFlag = true;
            do
            {
                Console.WriteLine("    Starting Menu    ");

                Console.WriteLine("Type (1) : To select data from DB");
                Console.WriteLine("Type (2) : To add data to the DB");
                Console.WriteLine("Type (3) : to close program");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        {
                            SelectData();
                        }
                        break;
                    case 2:
                        {
                            AddData();
                        }
                        break;
                    case 3:
                        {
                            menuFlag = !true;
                        }
                        break;

                }
            } while (menuFlag);

            void SelectData()
            {
                do
                {
                    Console.WriteLine("Type (1) : To show all the students");
                    Console.WriteLine("Type (2) : To show all the trainers");
                    Console.WriteLine("Type (3) : To show all the assignments");
                    Console.WriteLine("Type (4) : To show all the courses");
                    Console.WriteLine("Type (5) : To show all the students per course");
                    Console.WriteLine("Type (6) : To show all the trainers per course");
                    Console.WriteLine("Type (7) : To show all the assignments per course");
                    Console.WriteLine("Type (8) : To show all the assignments per course per student");
                    Console.WriteLine("Type (9) : To show the students that belong to more than one courses");
                    Console.WriteLine("Type (10) : To go back to the main menu");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                student.ListOfStudents(projectModel);
                            }
                            break;
                        case 2:
                            {
                                trainer.ListOfTrainers(trainerList);
                            }
                            break;
                        case 3:
                            {
                                assignment.ListOfAssignments(assignmentList);
                            }
                            break;
                        case 4:
                            {
                                course.ListOfCourses(courseList);
                            }
                            break;
                        case 5:
                            {
                                student.StudentsPerCourse(projectModel);
                            }
                            break;
                        case 6:
                            {
                                trainer.TrainersPerCourse(projectModel);
                            }
                            break;
                        case 7:
                            {
                                assignment.AssignmentsPerCourse(projectModel);
                            }
                            break;
                        case 8:
                            {
                                assignment.AssignmentsPerCourcePerStudent(projectModel);
                            }
                            break;
                        case 9:
                            {
                                student.StudentsWithMoreThanOneCourses(projectModel);
                            }
                            break;
                        case 10:
                            {
                                SelectFlag = !true;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("wrong input try again");
                            }
                            break;
                    }
                } while (SelectFlag);
                SelectFlag = true;

            }
            void AddData()
            {
                do
                {
                    Console.WriteLine("Type (1) : To add students");
                    Console.WriteLine("Type (2) : To add trainers");
                    Console.WriteLine("Type (3) : To add assignments");
                    Console.WriteLine("Type (4) : To add courses");
                    Console.WriteLine("Type (5) : To go back to the main menu");
                    int menuChoice = Convert.ToInt32(Console.ReadLine());
                    switch (menuChoice)
                    {
                        case 1:
                            student.AddStudents(projectModel, studentList.Count);
                            break;
                        case 2:
                            trainer.AddTrainers(projectModel, trainerList.Count);
                            break;
                        case 3:
                            assignment.AddAssignments(projectModel, assignmentList.Count);
                            break;
                        case 4:
                            course.AddCourses(projectModel, courseList.Count);
                            break;
                        case 5:
                            AddFlag = !true;
                            break;
                        default:
                            Console.WriteLine("Invalid number, please try again");
                            break;
                    }
                } while (AddFlag);
                AddFlag = true;
            }
        }
    }
}
