namespace DAY3.Classes
{
    public interface ISaveFile
    {
        void SaveText(List<Student> newStudents);
        List<Student> RetrieveText();
    }
}
