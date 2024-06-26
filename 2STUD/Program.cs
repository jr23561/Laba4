﻿using System.Text;

namespace Laba4Students
{
    public class Kolachko
    {
        static List<Student> ReadData(StreamReader sr)
        {
            List<Student> students = new List<Student>();
            try
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] subs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string newStr = string.Join(" ", subs);
                    students.Add(new Student(newStr));
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                sr.Close();
            }
            return students;
        }

        public static void RunMenu(List<Student> students)
        {
            List<string> avgMark = GetStudentsWithNecessaryMark(students);
            Console.WriteLine("студенти, що мають середній бал, більший ніж 4,5: ");
            foreach (string st in avgMark)
            {
                Console.WriteLine(st);
            }
        }
        public static List<string> GetStudentsWithNecessaryMark(List<Student> students)
        {

            List<string> avgMark = new List<string>();
             foreach (Student student in students)
             {
                double averageMark = GetAvgMark(student);
                 if (averageMark > 4.5)
                 {
                     avgMark.Add($"{student.surName} " +
                                 $"{student.firstName} " +
                                 $"{student.patronymic} " +
                                 $"{student.physicsMark.ToString()}");

                 }
             }
             return avgMark;
        }
        public static double GetAvgMark(Student student)
        {
            return (student.physicsMark - '0' + student.informaticsMark -'0' + student.mathematicsMark - '0') / 3.0;
        }
        public static void TupM()
        {
            StreamReader sr = new StreamReader("input.txt");
            List<Student> students = ReadData(sr);
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            RunMenu(students);
        }
    }


    public struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        public Student(string lineWithAllData)
        {
            string[] data = lineWithAllData.Split();
            surName = data[0];
            firstName = data[1];
            patronymic = data[2];
            sex = data[3][0];
            dateOfBirth = data[4];
            mathematicsMark = data[5][0];
            physicsMark = data[6][0];
            informaticsMark = data[7][0];
            scholarship = int.Parse(data[8]);
        }

    }



    public static class Kharchenko
    {
        static List<Student> ReadData(StreamReader sr)
        {
            List<Student> students = new();
            string line;
            try
            {

                line = sr.ReadLine();
                while (line != null)
                {
                    string[] subs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string newStr = string.Join(" ", subs);
                    students.Add(new Student(newStr));
                    line = sr.ReadLine();

                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return students;
        }
        public static void TupM()
        {
            StreamReader sr = new StreamReader("1nput.txt");
            List<Student> students = ReadData(sr);
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            RunMenu(students);

        }
        static List<string> GetAbsentStudents(List<Student> students)
        {
            List<string> absentStudents = new List<string>();

            foreach (var student in students)
            {
                int missedExams = 0;
                if (student.mathematicsMark == '-') missedExams++;
                if (student.physicsMark == '-') missedExams++;
                if (student.informaticsMark == '-') missedExams++;

                if (missedExams > 1)
                {
                    absentStudents.Add(student.surName);
                }
            }

            return absentStudents;
        }
        static void RunMenu(List<Student> students)
        {
            List<string> absenceStudents = GetAbsentStudents(students);
            Console.WriteLine("Студенти що пропустили більше одного екзамену: ");
            foreach (string st in absenceStudents)
            {
                Console.WriteLine(st);
            }
        }

    }

}
