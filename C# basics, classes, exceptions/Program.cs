using System.Runtime.CompilerServices;

namespace C__basics__classes__exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student1 = new Student("John", "Doe", 1);
                student1.AddGrade(12);
                student1.AddGrade(12);
                student1.AddGrade(12);

                Student student2 = new Student("Jane", "Doe", 2);
                student2.AddGrade(2);
                student2.AddGrade(2);
                student2.AddGrade(2);

                List<Student> students = new List<Student> { student1, student2 };

                Group group1 = new Group(students, "P45", "C#", 1);
                group1.Print();

                Group group2 = new Group(group1);
                group2.Print();

                Student student3 = new Student("Bob", "Bobovich", 3);
                student3.AddGrade(3);
                student3.AddGrade(3);
                student3.AddGrade(3);

                Student student4 = new Student("Bob", "Smith", 5);
                student4.AddGrade(5);
                student4.AddGrade(5);
                student4.AddGrade(5);
                group1.AddStudent(student4);

                group1.AddStudent(student3);
                group1.Print();

                group1.TransferStudent(student3, group1, group2);
                group1.TransferStudent(student4, group1, group2);
                group2.Print();

                group1.WorstStudent();
                group1.FailedStudents();

                group2.WorstStudent();
                group2.FailedStudents();

                student1.AddGrade(50);

                Student BadStudent = new Student("", "Bad", -1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Program error: {ex.Message}");
            }
            
        }
    }
}
