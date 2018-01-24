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
                id="00010",
                personId="p1"
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
            Student student1 = TransObj<Person, Student>.Trans(p);
            //定义一个变量。
            //var e = Expression.New(typeof(Person));
            //ConstantExpression constant = Expression.Constant(10, typeof(int));
            //ConstantExpression constant1 = Expression.Constant(200,typeof(int));
            //BinaryExpression binaryExpression = Expression.Add(constant1, constant);

            //ParameterExpression paraLeft = Expression.Parameter(typeof(int), "a");
            //ParameterExpression paraRight = Expression.Parameter(typeof(int), "b");

            //BinaryExpression binaryLeft = Expression.Multiply(paraLeft, paraRight);
            //ConstantExpression conRight = Expression.Constant(2, typeof(int));

            //BinaryExpression binaryBody = Expression.Add(binaryLeft, conRight);

            //LambdaExpression lambda =
            //    Expression.Lambda<Func<int, int, int>>(binaryBody, paraLeft, paraRight);

            //Console.WriteLine(lambda.ToString());

            //Console.Read();








            //ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "i");

            //BinaryExpression binaryExpression = Expression.AddAssign(parameterExpression, parameterExpression);

            //var ex = Expression.Lambda<Func<int, int>>(binaryExpression, parameterExpression);

            //Func<int, int> lambdaExpression = Expression.Lambda<Func<int, int>>(binaryExpression, parameterExpression).Compile();

            ParameterExpression parameter = Expression.Parameter(typeof(Person), "p");
            List<MemberExpression> memberList = new List<MemberExpression>();
            List<MemberBinding> bindingList = new List<MemberBinding>();
            foreach (var item in typeof(Person).GetProperties())
            {
                MemberExpression memberExpression = Expression.Property(parameter, item.Name);
                Console.WriteLine(memberExpression.ToString());
                MemberBinding binding = Expression.Bind(item, memberExpression);
                Console.WriteLine(binding);
                bindingList.Add(binding);
                memberList.Add(memberExpression);
            }










            //Console.WriteLine(lambdaExpression(10));

            Console.ReadKey();
        }
    }
}
