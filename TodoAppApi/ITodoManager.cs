using System.Collections.Generic;

namespace TodoAppApi
{
    public interface ITodoManager
    {

        List<TodoItem> GetAllTodos();

        void AddTodo(TodoItem x);

        TodoItem GetTodo(int id);

        void UpdateTodo(int id, string newTitle);

        void DeleteTodo(int id);

    }
}