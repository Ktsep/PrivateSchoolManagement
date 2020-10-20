select * from students --#1	

select * from Assignments --#2	

select * from Courses --#3

select * from Trainers --#4

SELECT FirstName,LastName,Title,Stream FROM Students
JOIN StudentsPerCourse ON Students.studentId = StudentsPerCourse.studentId
JOIN Courses ON Courses.courseId = StudentsPerCourse.courseId --#5

SELECT FirstName,LastName,Title,Stream,Type FROM Trainers
JOIN TrainersPerCourse ON Trainers.trainerId = TrainersPerCourse.trainerId
JOIN Courses ON Courses.courseId = TrainersPerCourse.courseId --#6

SELECT a.Title,Description,c.Title,Stream,Type FROM Assignments as a
JOIN AssignmentsPerCourse ON a.assignmentId = AssignmentsPerCourse.assignmentId
JOIN COURSES as c ON c.courseId = AssignmentsPerCourse.courseId --#7


SELECT firstname,lastname, assignments.title as AssignmentTitle, Courses.title as CourseTitle,Courses.stream FROM Assignments
JOIN AssignmentsPerCourse ON Assignments.assignmentId = AssignmentsPerCourse.assignmentId
JOIN Courses ON Courses.courseId = AssignmentsPerCourse.courseId
JOIN StudentsPerCourse ON StudentsPerCourse.courseId = Courses.courseId
JOIN Students ON Students.studentId = StudentsPerCourse.studentId --#8

SELECT firstname, lastname   FROM Students
JOIN StudentsPerCourse ON Students.studentId = StudentsPerCourse.studentId
JOIN Courses ON Courses.courseId = StudentsPerCourse.courseId --#9
GROUP BY firstname, lastname
HAVING COUNT(*) > 1;



