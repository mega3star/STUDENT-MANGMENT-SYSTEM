using STUDENT_MANGMENT_SYSTEM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace STUDENT_MANGMENT_SYSTEM
{

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> StudentCourses { get; set; }

        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;

            StudentCourses = new List<Course>();
        }

        public void Enroll(Course course)
        {
            bool check = StudentCourses.Find(c => c.CourseId == course.CourseId) != null;

            if (check == true)
            {
                Console.WriteLine("Course is already enrolled");
            }
            else
            {
                StudentCourses.Add(course);
                Console.WriteLine("Course has been added");
            }
        }

        public string PrintDetails()
        {
            string StudentDtetails = "STUDENT ID: " + StudentId +
            "\n STUDENT NAME: " + Name +
             "\n STUDENT AGE: " + Age +
            "\n STUDENT COURSES: \n";

            foreach (Course course in StudentCourses)
            {
                StudentDtetails += course.Title + "\n";
            }

            return StudentDtetails;

        }



    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }


        public string PrintDetails()
        {
            string CourseDetails = "COURSE ID: " + CourseId +
                 "\nCOURSE TITEL:  " + Title +
                 "\nCOURSE INSTRUCTOR: " + Instructor.Name;
            return CourseDetails;
        }
    }

    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public string PrintDetails()
        {
            string InstructorDetails = "INSTRUCTOR ID: " + InstructorId +
                "\n INSTRUCTOR NAME: " + Name +
                "\n INSTRUCTOR SPECIALIZATION: " + Specialization;

            return InstructorDetails;


        }

    }

    public class StudentManager
    {
        public List<Student> Students = new List<Student>();
        public List<Course> Courses = new List<Course>();
        public List<Instructor> Instructors = new List<Instructor>();

        public StudentManager()
        {

        }

        public bool AddStudent(Student student)
        {
            if (Students.Find(s => s.StudentId == student.StudentId) != null)
            {
                return false;
            }

            Students.Add(student);
            return true;
        }
        public void AddCourse(Course course)
        {
            bool check = Courses.Find(c => c.CourseId == course.CourseId) != null;

            if (check == true)
            {
                Console.WriteLine("The Course Is Already Added");
            }
            else
            {
                Courses.Add(course);
                Console.WriteLine("The Course Has Been Added");
            }
        }
        public void AddInstructor(Instructor instructor)
        {
            bool check = Instructors.Find(i => i.InstructorId == instructor.InstructorId) != null;

            if (check == true)
            {
                Console.WriteLine("The Instructor Is Already Added");
            }
            else
            {
                Instructors.Add(instructor);
                Console.WriteLine("The Instructor Has Been Added");
            }
        }
        public Student FindStudent(int studentId)
        {
            return Students.Find(student => student.StudentId == studentId);
        }
        public Student FindStudentByName(string name)
        {
            return Students.Find(student => student.Name == name);
        }

        public Course FindCourse(int courseId)
        {
            return Courses.Find(Course => Course.CourseId == courseId);
        }

        public Course FindCourseByName(string title)
        {
            return Courses.Find(course => course.Title == title);
        }

        public Instructor FindInstructor(int instructorId)
        {
            return Instructors.Find(instructor => instructor.InstructorId == instructorId);
        }
        public void EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);

            if (student == null)
            {
                Console.WriteLine("Student not found");
                return;
            }

            Course course = FindCourse(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found");
                return;
            }

            student.Enroll(course);

            Console.WriteLine("Student enrolled successfully");
        }
        public string GetInstructorNameByCourseName(string courseName)
        {
            Course course = FindCourseByName(courseName);

            if (course == null)
            {
                return "Course not found.";
            }

            return course.Instructor.Name;
        }
        public bool IsStudentEnrolled(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);

            if (student == null)
            {
                return false;
            }

            Course course = FindCourse(courseId);

            if (course == null)
            {
                return false;
            }

            return student.StudentCourses.Find(c => c.CourseId == courseId) != null;
        }
        class Program
        {
            static void Main(string[] args)
            {
                StudentManager manager = new StudentManager();

                while (true)
                {
                    Console.WriteLine("\n===== Student Management System =====");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Add Instructor");
                    Console.WriteLine("3. Add Course");
                    Console.WriteLine("4. Enroll Student in Course");
                    Console.WriteLine("5. Show All Students");
                    Console.WriteLine("6. Show All Courses");
                    Console.WriteLine("7. Show All Instructors");
                    Console.WriteLine("8. Find Student");
                    Console.WriteLine("9. Find Course");
                    //ضيفلي البونص يا بشمهندس هكون ممتنة
                    Console.WriteLine("10.Check if the student enrolled in specific course");
                    Console.WriteLine("11. Return the instructor name by course name");
                    Console.WriteLine("12. Exit");

                    Console.Write("Choose: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                string studentName = Console.ReadLine();

                                int newStudentId = int.Parse(Console.ReadLine());

                                int studentAge = int.Parse(Console.ReadLine());

                                Student newStudent =
                                    new Student(newStudentId, studentName, studentAge);

                                if (manager.AddStudent(newStudent))
                                {
                                    Console.WriteLine("Student added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Student ID already exists.");
                                }

                                break;
                            }

                        case 2:
                            {
                                Console.Write("Instructor ID: ");
                                int newInstructorId = int.Parse(Console.ReadLine());

                                Console.Write("Instructor Name: ");
                                string newInstructorName = Console.ReadLine();

                                Console.Write("Instructor Specialization: ");
                                string newSpecialization = Console.ReadLine();

                                Instructor newInstructor =
                                    new Instructor(
                                        newInstructorId,
                                        newInstructorName,
                                        newSpecialization
                                    );

                                manager.AddInstructor(newInstructor);

                                break;
                            }

                        case 3:
                            {
                                Console.Write("Course ID: ");
                                int newCourseId = int.Parse(Console.ReadLine());

                                Console.Write("Course Title: ");
                                string newCourseTitle = Console.ReadLine();

                                Console.Write("Instructor ID: ");
                                int selectedInstructorId = int.Parse(Console.ReadLine());

                                Instructor selectedInstructor =
                                    manager.FindInstructor(selectedInstructorId);

                                if (selectedInstructor == null)
                                {
                                    Console.WriteLine("Instructor not found.");
                                    break;
                                }

                                Course newCourse =
                                    new Course(
                                        newCourseId,
                                        newCourseTitle,
                                        selectedInstructor
                                    );

                                manager.AddCourse(newCourse);

                                break;
                            }

                        case 4:
                            {
                                Console.Write("Student ID: ");
                                int selectedStudentId = int.Parse(Console.ReadLine());

                                Student foundStudent =
                                    manager.FindStudent(selectedStudentId);

                                if (foundStudent == null)
                                {
                                    Console.WriteLine("Student not found.");
                                    break;
                                }

                                Console.Write("Course ID: ");
                                int selectedCourseId = int.Parse(Console.ReadLine());

                                Course foundCourse =
                                    manager.FindCourse(selectedCourseId);

                                if (foundCourse == null)
                                {
                                    Console.WriteLine("Course not found.");
                                    break;
                                }

                                manager.EnrollStudentInCourse(
                                    selectedStudentId,
                                    selectedCourseId
                                );

                                break;
                            }
                    
                        case 5:
                            {                        
                                foreach (var s in manager.Students)
                                {
                                    Console.WriteLine(s.PrintDetails());
                                }

                                break;
                            }

                        case 6:
                            {
                                foreach (var c in manager.Courses)
                                {
                                    Console.WriteLine(c.PrintDetails());
                                }

                                break;
                            }
                        case 7:

                            foreach (Instructor instructor in manager.Instructors)
                            {
                                Console.WriteLine(instructor.PrintDetails());
                            }

                            break;
                        case 8:
                            {
                                Console.WriteLine("1. Search by ID");
                                Console.WriteLine("2. Search by Name");

                                int searchChoice = int.Parse(Console.ReadLine());

                                if (searchChoice == 1)
                                {
                                    Console.Write("Student ID: ");
                                    int studentId = int.Parse(Console.ReadLine());

                                    Student student = manager.FindStudent(studentId);

                                    if (student == null)
                                    {
                                        Console.WriteLine("Student not found.");
                                    }
                                    else
                                    {
                                        Console.WriteLine(student.PrintDetails());
                                    }
                                }
                                else if (searchChoice == 2)
                                {
                                    Console.Write("Student Name: ");
                                    string studentName = Console.ReadLine();

                                    Student student = manager.FindStudentByName(studentName);

                                    if (student == null)
                                    {
                                        Console.WriteLine("Student not found.");
                                    }
                                    else
                                    {
                                        Console.WriteLine(student.PrintDetails());
                                    }
                                }

                                break;
                            }
                        case 9:
                            {
                                Console.WriteLine("1. Search by ID");
                                Console.WriteLine("2. Search by Name");

                                int searchChoice = int.Parse(Console.ReadLine());

                                if (searchChoice == 1)
                                {
                                    Console.Write("Course ID: ");
                                    int courseId = int.Parse(Console.ReadLine());

                                    Course course = manager.FindCourse(courseId);

                                    if (course == null)
                                    {
                                        Console.WriteLine("Course not found.");
                                    }
                                    else
                                    {
                                        Console.WriteLine(course.PrintDetails());
                                    }
                                }
                                else if (searchChoice == 2)
                                {
                                    Console.Write("Course Name: ");
                                    string courseName = Console.ReadLine();

                                    Course course = manager.FindCourseByName(courseName);

                                    if (course == null)
                                    {
                                        Console.WriteLine("Course not found.");
                                    }
                                    else
                                    {
                                        Console.WriteLine(course.PrintDetails());
                                    }
                                }

                                break;
                            }
                        case 10:
                            {
                                Console.Write("Student ID: ");
                                int studentId = int.Parse(Console.ReadLine());

                                Console.Write("Course ID: ");
                                int courseId = int.Parse(Console.ReadLine());

                                bool enrolled = manager.IsStudentEnrolled(studentId, courseId);

                                if (enrolled)
                                {
                                    Console.WriteLine("Student is enrolled in this course.");
                                }
                                else
                                {
                                    Console.WriteLine("Student is NOT enrolled in this course.");
                                }

                                break;
                            }
                        case 11:
                            {
                                Console.Write("Course Name: ");
                                string courseName = Console.ReadLine();

                                string instructorName =
                                    manager.GetInstructorNameByCourseName(courseName);

                                Console.WriteLine("Instructor: " + instructorName);

                                break;
                            }

                        case 12:
                            Console.WriteLine("Goodbye!");
                            return;


                    
                    
                    }
                }
            }
        }
    }
}