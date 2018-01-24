using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lfg.Pms.Code;
using System.Linq.Expressions;
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
            //Console.WriteLine(person.id);
            //Console.WriteLine(person.name);
            //Student student1 = TransObj<Person,Student>.TransToVersion2(p);
            //定义一个变量。
            //var e = Expression.New(typeof(Person));
            ConstantExpression constant = Expression.Constant(10, typeof(int));
            ConstantExpression constant1 = Expression.Constant(200,typeof(int));
            BinaryExpression binaryExpression = Expression.Add(constant1, constant);

            ParameterExpression paraLeft = Expression.Parameter(typeof(int), "a");
            ParameterExpression paraRight = Expression.Parameter(typeof(int), "b");

            BinaryExpression binaryLeft = Expression.Multiply(paraLeft, paraRight);
            ConstantExpression conRight = Expression.Constant(2, typeof(int));

            BinaryExpression binaryBody = Expression.Add(binaryLeft, conRight);

            LambdaExpression lambda =
                Expression.Lambda<Func<int, int, int>>(binaryBody, paraLeft, paraRight);

            Console.WriteLine(lambda.ToString());

            Console.Read();






            Func<int> func = Expression.Lambda<Func<int>>(binaryExpression).Compile();
            Console.WriteLine(func());
            Console.ReadKey();
        }
    }
}
