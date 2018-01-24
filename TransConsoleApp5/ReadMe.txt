.Lambda #Lambda1<System.Func`2[TransConsoleApp5.Student,TransConsoleApp5.Person]>(TransConsoleApp5.Student $p) {
    .New TransConsoleApp5.Person(){
        id = $p.id,
        name = $p.name
    }
}


.New TransConsoleApp5.Person(){
    id = $p.id,
    name = $p.name
}




通过表达式构造方法：
1、定义ParameterExpression（定义参数）
2、定义操作（加减乘除，赋值，新建对象等相关操作）
3、转换为Lambda表达式树（第一个为需要转换的表达式，第二个为参数）



类型映射：

将以下方法转为为通用表达式

public class Person
{
    public string id { get; set; }
    public string name { get; set; }
        
    public string personId { get; set; }
}

public class Student
{
    public string id { get; set; }
    public string studentId { get; set; }
    public string name { get; set; }
}

 常规转换：

 public Student Trans(Person p)
 {
	return new Student()
	{
		id = p.id,
		name =p.name
	}
 }

 public Person Trans(Student s)
 {
	return new Person()
	{
		id=s.id,
		name = s.name
	}
 }

 =>泛型抽象

public Tout Trans(TIn tIn)
{
	return new Tout()
	{
		id =  tIn.id
		...
	}
}





public Tout Trans(TIn tIn)
{
	
}


Lambda表达式转换=>  (Tin)=>Tout;

转换为表达式树=>

1、定义参数。（ParameterExpression）
2、获取成员绑定。（MemberBinding）
	2.1、获取成员定义。（MemberExpression）
	2.2、创建成员绑定。（MemberBinding）
3、创建新对象。（NewExpression）
4、使用成员初始化函数（MemberInitExpression）
5、获取Lambda表达式Expression.Lambda<Func<Tin,Tout>>(MemberInitExpression,ParameterExpression)
6、编译Lambda表达式获取委托
7、调用委托。







