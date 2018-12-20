using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {

            /*************************************/
            Func<int, string> fun = (p) => { return "44"; };

            Func<int,string> funno = (p) => "sdds";
          string f1f=  Test<int>(funno,9);
            Console.WriteLine(f1f);
            /*************************************/

            // Action s  = HH;// Action s = () => { Console.WriteLine(87844); }; 无返回值

            // Action<int> g = h => { Console.Write(h); };//一个参数 无返回值，一个参数括号可以省略

            // Action<int, int> k = (b, c) => { Console.Write(b); };//一个参数，两个参数 不可以省略 无返回值
            // s();

            // Func<int, int> m = n => { return n; };//带有一个参数 和返回值的 =>是lamad简写，n代表参数 return n 代表返回值
            // Console.Write(m(87));


            // Func<int, int, int> qw = (m1,m2) => { return m1; };//带有两个参数 和返回值的 =>是lamad简写，m1代表参数 return m1 代表返回值就是返回那个m2
            // Console.Write(qw(8,7));

            ////以上都是最多16参数，最少0

            Func<int> m1 = () => { return 8; };
            //Console.WriteLine(m1());
            Func<int> f1 = () => { return 1; };//必须写 return 1;
          
            List<long> a = new List<long>();
            for (int i = 1; i <= 6; i++)
            {
                a.Add(i);
            }

            List<long> b = new List<long>();
            for (int i =8 ; i <= 9; i++)
            {
                b.Add(i);
            }
            var list = b.Where(p => a.BinarySearch(p) < 0).ToList();
            ChildDelegateSyntax ex = new ChildDelegateSyntax();
            ex.Excute();
            //ex.AsyncLoad(() => { var d = 3;
            //    var kl = d * d;
                
            //});
            //Excute();
            Console.ReadLine();
        }
        static string Test<T>(Func<T, string> fc, T para)
        {
            return fc(para);
        }
        public delegate void TestDelegate(string message);
        public delegate long TestDelegate2(int m, long num);
        delegate string anoy(string k, string l);
        public static void Excute()
        {
            TestDelegate2 td = Double;
            TestDelegate f = D;
            Console.WriteLine(td(4, 7));
            f("44147");

            anoy d = (m, n) => { return m + n; };
            Console.Write(d("g", "rr"));
        }
        static long Double(int m, long num)
        {
            return m * num;
        }
        static void D(string p)
        {
            Console.Write(p);
        }
        public void AsyncLoad(Action action)
        {

        }
        public static void HH()
        { Console.WriteLine(787855444); }
        public class BaseDelegateSyntax
        {
            public void AsyncLoad(Action action)
            {
                action();
            }
            public void AsyncLoad(Action action, Action callback)
            {
                IAsyncResult result = action.BeginInvoke((iar) => { callback(); },null);       
            }
            public void AsyncLoad<T>(Action<T> action, T para, Action callback)
            {
                IAsyncResult result = action.BeginInvoke(para, (iar) => {
                    callback();
                },null);
            }
            public void AsyncLoad<T, R>(Func<T, R> action, T para, Action<R> callback)
            {
                IAsyncResult result = action.BeginInvoke(para, (iar) => { var res = action.EndInvoke(iar);callback(res); },null);
            }
        }
        public class ChildDelegateSyntax : BaseDelegateSyntax
        {
            int kl = 0;
            string a = "";         
            public void Excute()
            {            
                //开启异步方法
                base.AsyncLoad(() => {

                    Console.WriteLine(45451);                    

                });
                //开启异步方法 ，异步结束后 执行回调函数
                base.AsyncLoad(()=> {
                    kl = 1 + 6;Console.WriteLine(kl);
                }, () =>Console.WriteLine(kl));
               
                //开启异步有传入参数，并且在异步结束之后触发回调方法
                base.AsyncLoad<string>((s) => { Console.WriteLine(s); a = s; },"dasdas",()=> { Console.WriteLine(a); });
                //开启异步有传入参数，并且在异步结束之后回调
                base.AsyncLoad<string, int>((s) => { return Int32.Parse(s);  },"888",(h)=> { Console.WriteLine(h); });
            }
        }
    }
}
