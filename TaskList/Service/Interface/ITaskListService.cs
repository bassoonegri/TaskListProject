using System.Threading.Tasks;
using TaskListProject.Entities;

namespace TaskListProject.Service.Interface;

public interface ITaskListService
{

    Task<TaskResponse<IEnumerable<TaskList>>> GetAllTasks();
    Task<TaskResponse<TaskList>> GetTaskById(int id);

    Task<TaskResponse<TaskList>> CreateTask(TaskPostModel task);

    Task<TaskResponse<TaskList>> UpdateTask(TaskPutModel task);

    Task<TaskResponse<TaskList>> UpdateStatusTask(TaskPatchModel task);

    Task<TaskResponse<TaskList>> DeleteTask(int id);
}
