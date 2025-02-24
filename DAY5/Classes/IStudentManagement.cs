namespace DAY5.Classes
{
    public interface IStudentManagement
    {
        public string AddStudent(Student student);
        public string RemoveStudent(Student student);
        public string UpdateStudent(Student student);
        public List<Student>? GetStudents();
    }
}
