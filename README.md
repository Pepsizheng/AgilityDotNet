# AgilityDotNet
describe common design models and experiences when using agility.

## 里氏替换原则中的协变和逆变

* 协变
参考该实现cs文件说明：[segregation](../AgilityDotNet/interfacesegregation/Program.cs);

* 逆变
参考该实现cs文件说明：[segregation](../AgilityDotNet/interfacesegregation/Program.cs);

里氏替换不只是父类转子类，子类转父类的思想，还有原则指导，总结为严于律己，宽以待人。
解释为子类实现的时候，对于前置条件不能更严格，对于方法要返回前的后置条件不能更宽松。
同时对于只需要在类中或子类中修改的字段属性，不能被子类实现到外部类也可以修改。这条实现也叫做数据不变式。即某个条件规定后不变而不是指数据本身不变。
