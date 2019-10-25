using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp
{
    class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; } 
    }

    class TodoManager
    {
        private List<TodoItem> list = new List<TodoItem>();

        public void AddTodo(TodoItem x)
        {
            list.Add(x);
        }

        public TodoItem GetTodo(int y)
        {
            for (int i = 0; i < list.Count; i++)
            {
                TodoItem x = list[i];
                int z = x.Id;
                if (y == z)
                {
                    return x;
                }
            }
            return null;
        }

        public void UpdateTodo(int x, string y)
        {
            TodoItem z = GetTodo(x);
            z.Title = y;
        }

        public void DeleteTodo(int x)
        {
            TodoItem found = null;
            foreach (var y in list)
            {
                if (x == y.Id)
                {
                    found = y;
                }
            }
            list.Remove(found);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // task 1 - create to-do manager class with AddTodo, GetTodo, UpdateTodo and DeleteTodo
            TodoManager todoManager = new TodoManager();

            // task 2 - create a list inside TodoManager. AddTodo operation should add a new item into that list.
            var todoItem1 = new TodoItem {Id = 1, Title = "Buy milk", Rating = 3};
            todoManager.AddTodo(todoItem1);

            var todoItem2 = new TodoItem {Id = 2, Title = "Wash dishes", Rating = 2};
            todoManager.AddTodo(todoItem2);

            var todoItem3 = new TodoItem {Id = 3, Title = "Summon Satan", Rating = 5};
            todoManager.AddTodo(todoItem3);

            // task 3 - it should ask TodoManager's inner list and retrieve to-do item with ID = 2
            var buyMilkTodo = todoManager.GetTodo(2);
            Console.WriteLine(buyMilkTodo.Title);

            // task 4 - it should ask TodoManager's inner list and retrieve to-do item with ID = 3. Then, change the title.
            todoManager.UpdateTodo(3, "Summon Pokemon");
            var updatedTodo = todoManager.GetTodo(3); // retrieve the element again to test, if the title has been updated
            Console.WriteLine(updatedTodo.Title);

            // task 5 - access the TodoManager's inner list and remove the item which ID = 3.
            todoManager.DeleteTodo(3);
        }

      //  static void ListExample()
      //  {
      //      List<TodoItem> list = new List<TodoItem>();
      //
      //      list.Add(new TodoItem { Title = "Buy milk", Rating = 2 });
      //
      //      var todoItem2 = new TodoItem();
      //      todoItem2.Title = "Wash dishes";
      //      todoItem2.Rating = 3;
      //      list.Add(todoItem2);
      //
      //      for (int i = 0; i < list.Count; i++)
      //      {
      //          var elem = list[i];
      //          Console.WriteLine(elem.Title);
      //      }
      //
      //      foreach (var elem in list)
      //      {
      //          Console.WriteLine(elem.Title);
      //      }
      //  }
    }
}
