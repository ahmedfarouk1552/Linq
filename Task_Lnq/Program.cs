using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Lnq
{
    class Program
    {
        class subject
        {
            public int code { get; set; }
            public string name { get; set; }

        }

        class Student
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public subject [] subjects { get; set; }

        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            //----  1 ----
            var q1 = numbers.Distinct().OrderBy(n => n);
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------");
            //// ---------- 2 -----------
            foreach (var item in q1)
            {
                Console.WriteLine($"( Number= {item} , Multiply= {item * item} )");
            }

            Console.WriteLine("----------------------");


            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
            // ------------------- Query 1 ------------------

            //method expression

            var q2 = names.Where(n => n.Length == 3);
            foreach (var item in q2)
            {
                Console.WriteLine(item);

            }

        Console.WriteLine("--------------------");

            //query expression

            var q3 = from n in names
                     where n.Length == 3
                     select n;
            foreach (var item in q3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------");


            //----------------------Query 2----------------------- 

            var q4 = names.Where(n => n.ToLower().Contains("a")).OrderBy(n => n.Length);
            foreach (var item in q4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------");

            var q5 = names.Take(2);
            foreach (var item in q5)
            {
                Console.WriteLine(item);
            }


            List<Student> students = new List<Student>(){
new Student(){ id=1, firstname="Ali", lastname="Mohammed", subjects=new subject[]{ 
    new subject(){ code=22,name="EF"}, 
    new subject(){ code=33,name="UML"}}},
new Student(){ id=2, firstname="Mona", lastname="Gala", subjects=new subject []{ 
    new subject(){ code=22,name="EF"}, 
    new subject(){ code=34,name="XML"},
    new subject(){ code=25, name="JS"}}}, 
new Student(){ id=3, firstname="Yara", lastname="Yousf", subjects=new subject []{ 
    new subject (){ code=22,name="EF"}, 
    new subject (){ code=25,name="JS"}}},
new Student(){ id=1, firstname="Ali", lastname="Ali", subjects=new subject []{ 
    new subject (){ code=33,name="UML"}}},
};
            Console.WriteLine("----------------------");

            //---------Query 1 -------------
            var q6 = students.Select(n => new { fullname = n.firstname + " " + n.lastname, numOfSubjects = n.subjects.Length });

            foreach (var item in q6)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------");

            //--------------------------- Query 2 --------------------

            var q7 = students.OrderByDescending(n => n.firstname).ThenBy(n => n.lastname).Select(n => n.firstname + " " + n.lastname);

            foreach (var item in q7)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------");
             //------------------Query3-----------------
            var q8 = students.SelectMany(n => n.subjects,
                       (student, subject) => new
                       {
                           StudentName = $"{student.firstname} {student.lastname}",
                           SubjectName = subject.name
                       });
                             
            foreach (var item in q8)
            {
                Console.WriteLine(item);
            }
           
            Console.WriteLine("-------------------------");

             //-------------------Query4---------------
            var q9 = q8.GroupBy(x => x.StudentName);
            foreach (var group in q9)
            {
                Console.WriteLine(group.Key);
                
                foreach (var student in group)
                {
                    Console.WriteLine(student.SubjectName);
                }
            }
            
            



        }
    }
}