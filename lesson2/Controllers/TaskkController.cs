using Microsoft.AspNetCore.Mvc;
using Taskking.Models;

namespace Taskking.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskkController : ControllerBase
{
    static List<Taskk> ListTaskk;
    static  TaskkController()  
    {
        ListTaskk = new List<Taskk>
        {
            new Taskk { Id = 1, TaskkName = "washing", IsDo = false},
            new Taskk { Id = 2, TaskkName = "keeping", IsDo = false},
            new Taskk { Id = 3, TaskkName = "shoping", IsDo = true},
        };
    }


    [HttpGet]
    public IEnumerable<Taskk> Get()
    {
        return ListTaskk;
    }
    
   [HttpGet("{id}")]
    public Taskk Get(int id)
    {
        return ListTaskk.FirstOrDefault(T => T.Id == id);
    }

        
    [HttpPost]
    public int Post(Taskk newTaskk)
    {
        int max = ListTaskk.Max(T => T.Id);
        newTaskk.Id = max + 1;
        ListTaskk.Add(newTaskk);  
        return newTaskk.Id;      
    }
        
    [HttpPut("{id}")]
    public void Put(int id, Taskk newTaskk)
    {
        if (id == newTaskk.Id)
        {
            var Taskk = ListTaskk.Find(T => T.Id == id);
            if (Taskk != null)
            {
                int index = ListTaskk.IndexOf(Taskk);
                ListTaskk[index] =newTaskk;
            }
        }
    }
        
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

            var Taskk = ListTaskk.Find(T => T.Id == id);
            if (Taskk != null)
            {
                ListTaskk.Remove(Taskk);
            }

    }



}
