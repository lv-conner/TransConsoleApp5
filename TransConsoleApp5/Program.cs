using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lfg.Pms.Code;
namespace TransConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person()
            {
                name="Tim",
                id="00010"

            };

            var student = new Student()
            {
                name = "Tim",
                id = "00010",
                studentId = "01020"
            };

            Person person = TransObj<Student, Person>.Trans(student);



            //Student student = TransObj<Person,Student>.Trans(p);

            Console.WriteLine(person.id);
            Console.WriteLine(person.name);


            Console.ReadKey();



        }
    }
}
