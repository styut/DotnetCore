using Microsoft.AspNetCore.Mvc;
using Taskking.Models;
using Taskking.Interfaces;

namespace Taskking.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskkController : ControllerBase
{
    public ITaskService TaskService;
    public TaskkController(ITaskService TaskService)
    {
        this.TaskService = TaskService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Taskk>> Get()
    {
        return TaskService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Taskk> Get(int id)
    {
        var Task = TaskService.Get(id);
        if (Task == null)
            return NotFound();
        return Ok(Task);
    }


    [HttpPost]
    public IActionResult Post(Taskk newTaskk)
    {
        var newId = TaskService.Post(newTaskk);
        return CreatedAtAction(nameof(Post), new { id = newId }, newTaskk);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Taskk newTaskk)
    {
        TaskService.Put(id, newTaskk);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {

        TaskService.Delete(id);
        return Ok();
    }
}
