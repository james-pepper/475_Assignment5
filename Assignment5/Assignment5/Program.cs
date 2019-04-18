//Ricardo Ramos 016318183
//James Pepper 016235035
using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static BusinessLayer.BusinessLayer b1 = new BusinessLayer.BusinessLayer();
        static void Main(string[] args)
        {  
            bool exit = true;
            bool subExit = true;
            while (exit)
            {
                Console.WriteLine("----- MAIN MENU -----");
                Console.WriteLine("1. Teacher Options");
                Console.WriteLine("2. Course Options");
                Console.WriteLine("3. Exit");
                Console.WriteLine();

                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        subExit = true;
                        while (subExit)
                        {
                            Console.WriteLine("----- Teacher MENU -----");
                            Console.WriteLine("1. Show All Teachers");
                            Console.WriteLine("2. Add Teacher");
                            Console.WriteLine("3. Remove Teacher");
                            Console.WriteLine("4. Change Teacher's Name by ID");
                            Console.WriteLine("5. Change Teacher's Name By Name");
                            Console.WriteLine("6. Show all Courses Taught By a Teacher");
                            Console.WriteLine("7. Add or Change Course of a Teacher");
                            Console.WriteLine("8. Back to Main Menu");
                            Console.WriteLine();

                            menuChoice = Convert.ToInt32(Console.ReadLine());
                            switch (menuChoice)
                            {
                                case 1:
                                    Console.WriteLine();
                                    ShowAllTeachers();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    ShowAllTeachers();
                                    Console.WriteLine();
                                    AddTeacher();
                                    Console.WriteLine();
                                    ShowAllTeachers();
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    RemoveTeacher();
                                    Console.WriteLine();
                                    ShowAllTeachers();
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    UpdateTeacherByID();
                                    Console.WriteLine();
                                    ShowAllTeachers();
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Console.WriteLine();
                                    UpdateTeacherByName();
                                    Console.WriteLine();
                                    ShowAllTeachers();
                                    Console.WriteLine();
                                    break;
                                case 6:
                                    Console.WriteLine();
                                    GetCoursesByTeacher();
                                    Console.WriteLine();
                                    break;
                                case 7:
                                    AddExistingCourseToTeacher();
                                    Console.WriteLine();
                                    break;
                                case 8:
                                    subExit = false;
                                    Console.WriteLine();
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid choice");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        subExit = true;
                        while (subExit)
                        {
                            Console.WriteLine("----- Course MENU -----");
                            Console.WriteLine("1. Show All Courses");
                            Console.WriteLine("2. Add Course");
                            Console.WriteLine("3. Remove Course");
                            Console.WriteLine("4. Change Course's Name By ID");
                            Console.WriteLine("5. Change Course's Name By Name");
                            Console.WriteLine("6. Remove Teacher from a Course");
                            Console.WriteLine("7. Back to Main Menu");
                            Console.WriteLine();

                            menuChoice = Convert.ToInt32(Console.ReadLine());
                            switch (menuChoice)
                            {
                                case 1:
                                    ShowAllCourses();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    AddCourse();
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    RemoveCourse();
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    UpdateCourseByID();
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    UpdateCourseByName();
                                    Console.WriteLine();
                                    break;
                                case 6:
                                    RemoveTeacherFromCourse();
                                    Console.WriteLine();
                                    break;
                                case 7:
                                    subExit = false;
                                    Console.WriteLine();
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid choice");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        Console.WriteLine();
                        break;
                }
                
            }
        }

        /// <summary>
        /// This method will show all the teachers in the database.
        /// </summary>
        private static void ShowAllTeachers()
        {
            IEnumerable<Teacher> teachers = b1.GetAllTeachers();
            Console.WriteLine("SHOWING ALL TEACHERS");
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine(string.Format("Teacher ID: {0,-6} Teacher Name: {1,-26}", teacher.TeacherId, teacher.TeacherName));
            }
        }

        /// <summary>
        /// This method will add a teacher to the database.
        /// </summary>
        private static void AddTeacher()
        {
            Console.WriteLine("ADD NEW TEACHER");
            Console.WriteLine("Enter the teachers name");
            string teacherName = Console.ReadLine();
            Teacher teacher = new Teacher()
            {
                TeacherName = teacherName,
            };
            b1.AddTeacher(teacher);
        }

        /// <summary>
        /// This method will delete a teacher from the database.
        /// </summary>
        private static void RemoveTeacher()
        {
            ShowAllTeachers();
            Console.WriteLine();
            Console.WriteLine("Delete Teacher By ID");
            Console.WriteLine("Enter teacher ID: ");
            int teacher_id = Convert.ToInt32(Console.ReadLine());
            Teacher teacher = b1.GetTeacherByID(teacher_id);
            b1.RemoveTeacher(teacher);
        }

        /// <summary>
        /// This method will search for a teacher by ID 
        /// and will update the teacher name.
        /// </summary>
        private static void UpdateTeacherByID()
        {
            ShowAllTeachers();
            Console.WriteLine();
            Console.WriteLine("Update Teacher By ID");
            Console.WriteLine("Enter teacher ID: ");
            int teacher_id = Convert.ToInt32(Console.ReadLine());
            Teacher teacher = b1.GetTeacherByID(teacher_id);

            if (teacher == null)
            {
                Console.WriteLine("Teacher does not exist in system");
            }
            Console.WriteLine();
            Console.WriteLine("Enter new teacher name");
            string teacher_name = Console.ReadLine();
            teacher.TeacherName = teacher_name;
            b1.UpdateTeacher(teacher);
        }

        /// <summary>
        /// Get all the courses that are associated with a teacher.
        /// </summary>
        private static void GetCoursesByTeacher()
        {
            ShowAllTeachers();
            Console.WriteLine();
            Console.WriteLine("Get Teacher's Courses");
            Console.WriteLine("Enter teacher ID: ");
            int teacher_id = Convert.ToInt32(Console.ReadLine());
            Teacher teacher = b1.GetTeacherByIdWithCourses(teacher_id);
            Console.WriteLine(teacher.TeacherName);
            Console.WriteLine();

            IList<Course> list = b1.GetCoursesByTeacherID(teacher.TeacherId);

            foreach (Course c in list)
            {
                Console.WriteLine(string.Format("Course ID: {0,-6} Course Name: {1,-10}", c.CourseId, c.CourseName));
            }

            if (list.Count == 0)
            {
                Console.WriteLine("The teacher does not have any courses");
            }

            //foreach (Course course in teacher.Courses)
            //{
            //    Console.WriteLine(string.Format("Course ID: {0,-6} Course Name: {1,-10}", course.CourseId, course.CourseName));
            //}

        }

        /// <summary>
        /// Displays all courses with id and name, as well the teacher for the class for testing purposes.
        /// </summary>
        private static void ShowAllCourses()
        {
            IEnumerable<Course> courses = b1.GetAllCourses();
            Console.WriteLine();
            Console.WriteLine("SHOWING ALL COURSES");
            foreach (Course course in courses)
            {
                if(course.TeacherId == 0)
                {
                    Console.WriteLine(string.Format("Course ID: {0,-6} Course Name: {1,-10} Teacher ID: {2,-14} Teacher Name: {3,-26}", course.CourseId, course.CourseName, "(No Teacher)", "(No Teacher)"));
                }
                else
                {
                    Teacher teacher = b1.GetTeacherByID((int)course.TeacherId);
                    Console.WriteLine(string.Format("Course ID: {0,-6} Course Name: {1,-10} Teacher ID: {2,-14} Teacher Name: {3,-26}", course.CourseId, course.CourseName, course.TeacherId, teacher.TeacherName));
                }
            }
        }

        /// <summary>
        /// Adds a course by name only, with no teacher.
        /// </summary>
        private static void AddCourse()
        {
            Console.WriteLine("ADD NEW COURSE");
            Console.WriteLine("Enter course name");
            string courseName = Console.ReadLine();
            Course course = new Course()
            {
                CourseName = courseName, TeacherId = 0, 
            };
            b1.AddCourse(course);
            ShowAllCourses();
        }

        /// <summary>
        /// Removes teach from a course by changing course's teacher ID to 0.
        /// </summary>
        private static void RemoveTeacherFromCourse()
        {
            ShowAllCourses();
            Console.WriteLine("Removing Teacher from Course");
            Console.WriteLine("Enter Course ID");
            int course_ID = Convert.ToInt32(Console.ReadLine());
            Course course = b1.GetCourseByID(course_ID);
            course.TeacherId = 0;
            b1.UpdateCourse(course);
            ShowAllCourses();
        }

        /// <summary>
        /// This changes the course's teacher ID to new one entered.
        /// No error checking for testing purposes.
        /// </summary>
        private static void AddExistingCourseToTeacher()
        {
            Console.WriteLine("All Courses with Their Teacher:");
            ShowAllCourses();
            IEnumerable<Teacher> teachers = b1.GetAllTeachers();
            IEnumerable<Course> courses = b1.GetAllCourses();

            ShowAllTeachers();

            Console.WriteLine();
            Console.WriteLine("Enter existing teacher ID");
            int teacherID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter course ID to add teacher to");
            int courseID = Convert.ToInt32(Console.ReadLine());
            Course course = b1.GetCourseByID(courseID);
            course.TeacherId = teacherID;
            b1.UpdateCourse(course);
            b1.UpdateTeacher(b1.GetTeacherByID(teacherID));
            ShowAllCourses();
        }

        /// <summary>
        /// Removes course by ID to delete the course from repository.
        /// Uses CRUD operation (Delete).
        /// </summary>
        private static void RemoveCourse()
        {
            ShowAllCourses();
            Console.WriteLine("Delete Course ID");
            Console.WriteLine("Enter course ID: ");
            int course_ID = Convert.ToInt32(Console.ReadLine());
            Course course = b1.GetCourseByID(course_ID);
            b1.RemoveCourse(course);//deletes the course
            ShowAllCourses();
        }

        /// <summary>
        /// Updates course's name only for testing purposes, by ID.
        /// Uses CRUD operation (Update).
        /// </summary>
        private static void UpdateCourseByID()
        {
            ShowAllCourses();
            Console.WriteLine("Update Course By ID");
            Console.WriteLine("Enter course ID: ");
            int course_ID = Convert.ToInt32(Console.ReadLine());
            Course course = b1.GetCourseByID(course_ID);
            if (course == null)
            {
                Console.WriteLine("Course does not exist in system");
            }
            Console.WriteLine();
            Console.WriteLine("Enter new course name");
            string course_Name = Console.ReadLine();
            course.CourseName = course_Name;
            b1.UpdateCourse(course);//updates the course
            ShowAllCourses();
        }

        /// <summary>
        /// Update teacher's name by name
        /// </summary>
        private static void UpdateTeacherByName()
        {
            ShowAllTeachers();
            Console.WriteLine();
            Console.WriteLine("Update Teacher's Name by Name");
            Console.WriteLine("Enter teacher name: ");
            string teacherName = Console.ReadLine();
            Teacher teacher2 = b1.GetTeacherByName(teacherName);
            if (teacher2 == null)
            {
                Console.WriteLine("Teacher does not exist in system");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Enter new teacher name");
            string teacher_name = Console.ReadLine();
            
            teacher2.TeacherName = teacher_name;
            b1.UpdateTeacher(teacher2);
        }

        /// <summary>
        /// Update course's by name
        /// </summary>
        private static void UpdateCourseByName()
        {
            ShowAllCourses();
            Console.WriteLine("Update Course By Name");
            Console.WriteLine("Enter course name: ");
            string courseName = Console.ReadLine();
            Course course = b1.GetCourseByName(courseName);
            if (course == null)
            {
                Console.WriteLine("Course does not exist in system");
            }
            Console.WriteLine();
            Console.WriteLine("Enter new course name");
            string course_Name = Console.ReadLine();
            course.CourseName = course_Name;
            b1.UpdateCourse(course);//updates the course
            ShowAllCourses();
        }
    }
}
