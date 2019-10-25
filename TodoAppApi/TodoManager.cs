using System.Collections.Generic;

namespace TodoAppApi
{
    public class TodoManager : ITodoManager
    {
        private static List<TodoItem> list = new List<TodoItem>();

        public List<TodoItem> GetAllTodos()
        {
            return list;
        }

        public void AddTodo(TodoItem x)
        {
            list.Add(x);
        }

        public TodoItem GetTodo(int id)
        {
            foreach (var todoItem in list)
            {
                if (id == todoItem.Id)
                {
                    return todoItem;
                }
            }

            return null;
        }

        public void UpdateTodo(int id, string newTitle)
        {
            TodoItem z = GetTodo(id);
            z.Title = newTitle;
        }

        public void DeleteTodo(int id)
        {
            TodoItem found = null;
            foreach (var todoItem in list)
            {
                if (id == todoItem.Id)
                {
                    found = todoItem;
                }
            }
            list.Remove(found);
        }
    }

}