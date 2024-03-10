using Microsoft.AspNetCore.Mvc;
using TaskListProject.Entities;
using TaskListProject.Service.Interface;

namespace TaskListProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskListController : ControllerBase
{
    private readonly ITaskListService taskListService;


    public TaskListController(ITaskListService taskListService)
    {
        this.taskListService = taskListService;
    }

    /// <summary>
    /// Método que retorna todas a tarefas por ordem de data de inicio
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskResponse<TaskList>>>> GetAll()
    {
        var list = await taskListService.GetAllTasks();
        return Ok(list);
    }

    /// <summary>
    /// Método que consulta a tarefa por parametros (id, tittulo ou descricao)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponse<TaskList>>> GetById(int id)
    {
        var list = await taskListService.GetTaskById(id);
        return Ok(list);
    }

    /// <summary>
    /// Método de criação de tarefa
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<TaskResponse<TaskList>>> Post([FromBody] TaskPostModel task)
    {
        var list = await taskListService.CreateTask(task);
        return Ok(list);
    }


    /// <summary>
    /// Método de atualização somente do status da tarefa
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<ActionResult<TaskResponse<TaskList>>> UpdateStatus([FromBody] TaskPatchModel task)
    {
        var list = await taskListService.UpdateStatusTask(task);
        return Ok(list);
    }


    /// <summary>
    /// Método de atualização da tarefa
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<TaskResponse<TaskList>>> Update([FromBody] TaskPutModel task)
    {
        var list = await taskListService.UpdateTask(task);
        return Ok(list);
    }


    /// <summary>
    /// Método de exclusão (física) da tarefa
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteById(int id)
    {
        var list = await taskListService.DeleteTask(id);
        return Ok(list);
    }

}
