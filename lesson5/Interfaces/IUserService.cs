using Taskking.Models;

namespace Taskking.Interfaces;

 public interface IUserService
  {
      List<User> GetAll();
      int Post(User newUser);      
      void Delete(int id);
  }