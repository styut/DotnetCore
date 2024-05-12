using Taskking.Models;

namespace Taskking.Interfaces;

 public interface ITaskService
  {
      List<Taskk> GetAll();
      Taskk Get(int id);
      int Post(Taskk newTaskk);      
      void Put(Taskk newTaskk);
      void Delete(int id);
  }