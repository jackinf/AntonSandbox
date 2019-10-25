using System;

namespace SandBox
{
    interface IHuman
    {
        bool IsAlive();
        bool IsRich();
    }

    abstract class Person : IHuman
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void Greeting()
        {
            Console.WriteLine($"My name is {Name} and my age is {Age}");
        }

        public bool IsAlive()
        {
            return true;
        }

        public virtual bool IsRich()
        {
            return true;
        }

    }

    class Employee : Person
    {
        public void SayYourSalary()
        {
            Console.WriteLine("My salary is 11 eur an hour");
        }

    }

    class Client : Person
    {
        public void Complain()
        {
            Console.WriteLine("I am complaining");
        }

        public override bool IsRich()
        {
            return false;
        }

    }

    class House
    {
        public void Enter(IHuman human)
        {
            human.IsAlive();
            if (human.IsRich())
            {
                Console.WriteLine("A rich human entered the house");
            }
            else
            {
                Console.WriteLine("A poor human entered the house");
            }
        }
    }

    interface ITodoManager
    {
        void AddTodo();
        void AddTodo(string a);
        void SayHell();
    }

    class TodoManager : ITodoManager
    {
        public TodoManager()
        {
            Console.WriteLine("I am called from constructor");
        }

        public TodoManager(string arg1, int arg2)
        {
            Console.WriteLine($"I am second constructor. I have been called with {arg1} and {arg2}");
        }

        public void AddTodo()
        {
            Console.WriteLine("Todo has been added");
            Console.WriteLine("Todo has been added 1");
        }

        public void AddTodo(string a)
        {
        }

        public void SayHell()
        {
            Console.WriteLine("privet");
        }
    }

    class SomeManager : ITodoManager
    {
        public void AddTodo()
        {

        }

        public void AddTodo(string a)
        {

        }

        public void SayHell()
        {
            Console.WriteLine("tere");
        }
    }

    class MovieController
    {
        public MovieController(ITodoManager todoManager)
        {
            todoManager.SayHell();
        }

        public string Index()
        {
            return "I am content from Index";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // /movie/index
            TodoManager todoManger = new TodoManager();
            SomeManager sm = new SomeManager();
            MovieController controller = new MovieController(sm);
            string result = controller.Index();
            Console.WriteLine(result);
        }

        static void MyApp1()
        {
            var person1 = new Employee();
            person1.Name = "Bob";
            person1.Age = 8;
            person1.Greeting(); // bob
            person1.SayYourSalary();

            var person2 = new Client();
            person2.Name = "Glen-Glen";
            person2.Age = 81;
            person2.Greeting(); // glen
            person2.Complain();

            var house = new House();
            house.Enter(person1);
            house.Enter(person2);
        }
    }
}
