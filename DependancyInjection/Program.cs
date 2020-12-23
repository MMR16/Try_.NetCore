using System;

namespace DependancyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loosely Coupled
            //FileLog f = new FileLog();
            //Employee emp = new Employee(f);
            //emp.Print("Mostafa");

            //Independent
            //student doesn't depend on any class
            //Dependancy Injection
            SqlLog s = new SqlLog();
            ConsoleLog l = new ConsoleLog();
            FileLog f = new FileLog();

            //1
            Student std1 = new Student(s);
            Student std2 = new Student(l);
            Student std3 = new Student(f);
            //2
            std1.Log=f;
            //3
            std1.Any(s);
            std1.Print("Mostafa");
            std2.Print("Mahomoud");
            std3.Print("Nour");

            Console.ReadKey();
        }
    }

    //Dependancy Injection
    public class Student
    {
        //1-Constructor Injection
        ILog _Log;
        public Student(ILog log)
        {
            _Log = log;
        }
        public void Print(string msg)
        {
            _Log.Log(msg);
        }
        //2-Property Injection
        public ILog Log
        {
            get
            {
                return _Log;
            }
            set
            {
                _Log = Log;
            }

        }
        //3-Method Injection
        public void Any(ILog log)
        {
            _Log = log;
        }

    }
        //tightly Coupled
        public class Employee
        {
            //ConsoleLog _ConsoleLog = new ConsoleLog();
            //SqlLog _SqlLog = new SqlLog();
            FileLog _FileLog;
            public void Print(string name)
            {
                //_ConsoleLog.log(name);
                //_SqlLog.log(name);
                _FileLog.Log(name);
            }
            //public Employee()
            //{
            //    _FileLog = new FileLog();
            //}
            public Employee(FileLog file)
            {
                _FileLog = file;
            }

        }

        public class ConsoleLog : ILog
        {
            public void Log(string msg)
            {
                Console.WriteLine($"{msg} Loged in Console");
            }
        }

        public class SqlLog : ILog
        {
            public void Log(string msg)
            {
                Console.WriteLine($"{msg} Loged in SQL");
            }
        }

        public class FileLog : ILog
        {
            public void Log(string msg)
            {
                Console.WriteLine($"{msg} Loged in File");
            }

            public FileLog()
            {

            }
        }
    }
