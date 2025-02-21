namespace DAY4.Classes
{
    public class StudentService : IStudentService
    {
        public List<Student>? Students;
        public StudentService()
        {
            Students = new List<Student>();
        }
        public void AddStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("STUDENT OBJECT IS NULL");
                return;
            }
            Students.Add(student);
            Console.WriteLine("STUDENT REGISTERED");
            LogStudent(student);
        }
        public void LogStudent(Student student) 
        {
            string str = $"REGISTRATION TIME : {DateTime.Now.ToShortTimeString()} NAME : {student.Name}\n";

            if (File.Exists("StudentDetails.txt"))
            {
                File.AppendAllText("StudentDetails.txt", str);
                Console.WriteLine("TEXT APPENDED");
            }
            else
            {
                File.WriteAllText("StudentDetails.txt", str);
                Console.WriteLine("FILE CREATED");
            }
        }
    }
}
