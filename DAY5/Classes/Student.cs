namespace DAY5.Classes
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(int Id, string name, int age)
        {
            this.Id = Id;
            this.Name = name;
            this.Age = age;
        }
    }
}
