using System;
using SmartIT.DebugHelper;
using SmartIT.Employee.MockDB;

namespace DatabaseTest
{
  class Program
  {
    static void Main(string[] args)
    {
      TodoRepository _todoRepository = new TodoRepository();
      var todoList = _todoRepository.GetAll();
      todoList.CDump("_todoRepository.GetAll()");
      var findById = _todoRepository.FindById(2);
      findById.CDump("_todoRepository.FindById(2)");
      var newTodo = _todoRepository.Add(new Todo { Name = "Call a friend" });
      _todoRepository.GetAll().CDump("Check if Call a friend todo added?");
      newTodo.Name = newTodo.Name + " Updated";
      _todoRepository.Update(newTodo);
      _todoRepository.GetAll().CDump("Check if Call a friend todo updated with Updated?");
      _todoRepository.Delete(_todoRepository.FindById(1));
      _todoRepository.GetAll().CDump("Check if Id=1 todo is Deleted?");

      Console.ReadLine();
    }
  }
}
