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




