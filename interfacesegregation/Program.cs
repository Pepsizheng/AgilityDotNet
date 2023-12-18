namespace InterfaceSeperate
{
    public class MainEntry
    {
        public static void Main()
        {
            IWork _iwork = new Work(); //正常的转换，子类转父类的用法，不会报错。
                                       //IWorkGeneric<IWork> _workGeneric = new WorkGeneric<Work>();//正常情况下，与上方的子类转父类一样的效果，但是在编译阶段就报错了。将_workGeneric变量的泛型参数改为Work即编译通过。
                                       //所以这里接口的泛型参数并不能通过这个类似接口嵌套接口的方式实现。
            IWorkGenericWith<IWork> _workGenericWith = new WorkGenericWith<Work>();//这里便不会报错，与上方的实现区别在于，转换的接口泛型参数添加了out关键字。即为协变的概念。

            //协变的概念在于，将这种类似嵌套的写法，将接口中的泛型参数也应用子类转父类的思想。同时注意到使用了out标记之后，T就只能用在方法的返回参数中，不能用在方法参数中。

            IWorkGenericSecond<IWork> _workSecond = new WorkGenericSecond<IWork>();
            IWorkGenericSecond<Work> _workSecondChild = (IWorkGenericSecond<Work>)_workSecond;//父类转子类，会发现报错。加上或者取消该（）中的强制转换均会在运行时报错。

            IWorkGenericSecondWith<IWork> _workSecondWith = new WorkGenericSecondWith<IWork>();
            IWorkGenericSecondWith<Work> _workSecondWithChild = _workSecondWith;//父类转子类，在接口的泛型参数添加了in关键字，即为逆变的概念

            //逆变的概念在于，将这种类似嵌套的写法，将接口中的泛型参数也应用父类转子类的思想。同时注意到使用了in标记之后，T就只能用在方法参数中，不能用在方法的返回参数中。

        }
    }

    public interface IWork
    {

    }

    public class Work : IWork
    {

    }

    public interface IWorkGeneric<T>
    {

    }

    public class WorkGeneric<T> : IWorkGeneric<T>
    {

    }

    public interface IWorkGenericWith<out T>
    {
        void SetName(T name);//方法参数不能使用out修饰的T
        T SetNameOut();//返回方法结果就可以
    }

    public class WorkGenericWith<T> : IWorkGenericWith<T>
    {
        public void SetName(T name)
        {
            throw new NotImplementedException();
        }

        public T SetNameOut()
        {
            throw new NotImplementedException();
        }
    }

    public interface IWorkGenericSecond<T>
    {

    }

    public class WorkGenericSecond<T> : IWorkGenericSecond<T>
    {

    }

    public interface IWorkGenericSecondWith<in T>
    {
        T SetName();//方法返回值不能使用in修饰的T
        void SetNameIn(T name);//方法参数可以
    }

    public class WorkGenericSecondWith<T> : IWorkGenericSecondWith<T>
    {
        public T SetName()
        {
            throw new NotImplementedException();
        }

        public void SetNameIn(T name)
        {
            throw new NotImplementedException();
        }
    }

}