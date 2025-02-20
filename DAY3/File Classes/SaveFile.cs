using Newtonsoft.Json;

namespace DAY3.Classes
{
    public class SaveFile : ISaveFile
    {
        public void SaveText(List<Student> newStudents)
        {
            try
            {
                Student.students.AddRange(newStudents);
                string studentJson = JsonConvert.SerializeObject(Student.students, Formatting.Indented);

                if (System.IO.File.Exists("studentData.txt"))
                {
                    System.IO.File.WriteAllText("studentData.txt", studentJson + Environment.NewLine + Environment.NewLine);
                    Console.WriteLine("TEXT ADDED IN FILE");
                }
                else
                {
                    System.IO.File.WriteAllText("studentData.txt", studentJson + Environment.NewLine + Environment.NewLine);
                    Console.WriteLine("TEXT FILE CREATED");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public List<Student> RetrieveText()
        {
            try
            {
                if (!System.IO.File.Exists("studentData.txt"))
                {
                    Console.WriteLine("No student data found.");
                    return new List<Student>();
                }
                string studentJson = System.IO.File.ReadAllText("studentData.txt");
                var students = JsonConvert.DeserializeObject<List<Student>>(studentJson);
                if(students == null)
                {
                    Console.WriteLine("No student data found.");
                    return new List<Student>();
                }
                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving student data: {ex.Message}");
                return new List<Student>();
            }
        }

    }
}
