using Microsoft.AspNetCore.Mvc.Formatters;

namespace DAY5.Classes
{
    public class StudentManagement: IStudentManagement
    {
        List<Student> students;
        public StudentManagement()
        {
            this.students = new List<Student>();
        }

        public string AddStudent(Student student) 
        {
            if (student == null) 
            {
                Console.WriteLine("STUDENT IS NULL\n ENTER VALID OBJECT");
                return "STUDENT IS NULL\n ENTER VALID OBJECT";
            }

            var stu = students.Find(x => x.Id == student.Id);
            if (stu != null)
            {
                Console.WriteLine("STUDENT ALREADY EXISTS");
                return "STUDENT ALREADY EXISTS";
            }
            students.Add(student);
            Console.WriteLine("STUDENT ADDED");
            return "STUDENT ADDED";
        }

        public string RemoveStudent(Student student) 
        {
            if (student == null)
            {
                Console.WriteLine("STUDENT IS NULL\n ENTER VALID OBJECT");
                return "STUDENT IS NULL\n ENTER VALID OBJECT";
            }

            var stu = students.Find(s => s.Id == student.Id);
            if (stu == null)
            {
                Console.WriteLine("STUDENT DOES NOT EXISTS");
                return "STUDENT DOES NOT EXISTS";
            }

            students.Remove(stu);
            Console.WriteLine("STUDENT REMOVED");
            return "STUDENT REMOVED";
        }

        public string UpdateStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("STUDENT IS NULL\n ENTER VALID OBJECT");
                return "STUDENT IS NULL\n ENTER VALID OBJECT";
            }

            var stu = students.Find(s => s.Id == student.Id);
            if (stu == null)
            {
                Console.WriteLine("STUDENT DOES NOT EXISTS");
                return "STUDENT DOES NOT EXISTS";
            }

            stu.Age = student.Age;
            stu.Name = student.Name;
            
            Console.WriteLine("STUDENT UPDATED");
            return "STUDENT UPDATED";
        }

        public List<Student>? GetStudents() 
        { 
            if (students == null)
            {
                Console.WriteLine("NO STUDENTS FOUND");
                return null;
            }
            return this.students; 
        }
    }
}
