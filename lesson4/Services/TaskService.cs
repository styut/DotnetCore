// using Taskking.Models;
// using Taskking.Interfaces;

// namespace Taskking.Services;

// public  class TaskService : ITaskService
// {
//     private List<Taskk> ListTaskk;
//     TaskService()  
//     {
//         ListTaskk = new List<Taskk>
//         {
//             new Taskk { Id = 1, TaskkName = "washing", IsDo = false},
//             new Taskk { Id = 2, TaskkName = "keeping", IsDo = false},
//             new Taskk { Id = 3, TaskkName = "shoping", IsDo = true},
//         };
//     }
//     public  List<Taskk> GetAll() => ListTaskk;
//     public Taskk Get(int id)
//     {
//         return ListTaskk.FirstOrDefault(T => T.Id == id);
//     }
//     public int Post(Taskk newTaskk)
//     {
//         int max = ListTaskk.Max(T => T.Id);
//         newTaskk.Id = max + 1;
//         ListTaskk.Add(newTaskk);  
//         return newTaskk.Id;      
//     }
        
//     // public void Put(int id, Taskk newTaskk)
//     // {
//     //     if (id == newTaskk.Id)
//     //     {
//     //         var Taskk = ListTaskk.Find(T => T.Id == id);
//     //         if (Taskk != null)
//     //         {
//     //             int index = ListTaskk.IndexOf(Taskk);
//     //             ListTaskk[index] =newTaskk;
//     //         }
//     //     }
//     // }
//     public void Delete(int id)
//     {

//             var Taskk = ListTaskk.Find(T => T.Id == id);
//             if (Taskk != null)
//             {
//                 ListTaskk.Remove(Taskk);
//             }

//     }
// }