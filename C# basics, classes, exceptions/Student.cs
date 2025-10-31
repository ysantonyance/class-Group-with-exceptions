using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class Student
    {
        private string firstName;

        public string Firstname
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStudentDataException("The name can't be empty", "FirstName");
                }
                firstName = value;
            }
        }

        private string surname;

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStudentDataException("Surname can't be empty", "Surname");
                }
                surname = value;
            }
        }

        private int studentNumber;

        public int StudentNumber
        {
            get
            {
                return studentNumber;
            }
            set
            {
                if (studentNumber <= 0)
                {
                    throw new InvalidStudentDataException("Student's number must be a positive number", "StudentNumber");
                }
                studentNumber = value;
            }
        }

        private List<int> grades;

        public List<int> Grades
        {
            get
            {
                return grades;
            }
            set
            {
                grades = value;
            }
        }

        public Student()
        {
            try
            {
                Firstname = "Karina";
                Surname = "Zinovieva";
                grades = new List<int>();
            }
            catch (StudentManagmentException ex)
            {
                Console.WriteLine($"Invalid creation of a student: {ex.Message}");
                throw;
            }
            
        }

        public Student(string firstName, string surname, int studentNumber)
        {
            Firstname = firstName;
            Surname = surname;
            grades = new List<int>();
        }

        public bool Passed()
        {
            if (grades.Count == 0)
            {
                return false;
            }

            return grades.All(grade => grade > 7);
        }

        public void AddGrade(int grade)
        {
            try
            {
                if (grade < 0 || grade > 12)
                {
                    throw new InvalidGradeException("\nA grade must be in a range from 0 to 12", grade);
                }
                grades.Add(grade);
                Console.WriteLine($"A grade {grade} was added to {this}");
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine($"Invalid adding of a grade {ex.Message}\nDetails: {ex.ErrorDetails}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Done with loading grades for {this}");
            }
            
            
        }

        public double GetAverageGrade()
        {
            if (grades.Count == 0)
                return 0;
            return grades.Average();
        }

        public override string ToString()
        {
            return $"{Surname} {Firstname}";
        }
    }
}
