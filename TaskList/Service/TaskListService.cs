using Microsoft.EntityFrameworkCore;
using TaskListProject.Entities;
using TaskListProject.Persistence;
using TaskListProject.Service.Interface;

namespace TaskListProject.Service;

public class TaskListService : ITaskListService
{
    private readonly TaskListDbContext context;

    public TaskListService(TaskListDbContext context)
    {
        this.context = context;
    }

    public async Task<TaskResponse<IEnumerable<TaskList>>> GetAllTasks()
    {
        var taskResponse = new TaskResponse<IEnumerable<TaskList>>();
        try
        {
            taskResponse.Tarefas = context.TaskList.ToList();

            if (taskResponse.Tarefas.Count() == 0)
            {
                taskResponse.Mensagem = "Não foram encontrados resultados.";
                taskResponse.Sucesso = true;

            }
        }
        catch (Exception ex)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = ex.Message;

        }

        return taskResponse;
    }

    public async Task<TaskResponse<TaskList>> GetTaskById(int id)
    {
        var taskResponse = new TaskResponse<TaskList>();
        try
        {
            taskResponse.Tarefas = context.TaskList.Where(c => c.IdTaskList.Equals(id)).FirstOrDefault();

            if (taskResponse.Tarefas == null)
            {
                taskResponse.Mensagem = "Não foram encontrados resultados.";
                taskResponse.Sucesso = true;

            }
        }
        catch (Exception ex)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = ex.Message;
        }

        return taskResponse;
    }

    public async Task<TaskResponse<TaskList>> CreateTask(TaskPostModel task)
    {
        var taskResponse = new TaskResponse<TaskList>();
        try
        {
            var taskMapped = new TaskList
            {
                Titulo = task.Titulo,
                Descricao = task.Descricao,
                Finalizada = task.Finalizada,
                DataInicio = task.DataInicio,
                DataFim = task.DataFim,
                DataCriacao = DateTime.Now
            };

            context.Add(taskMapped);
            await context.SaveChangesAsync();

            taskResponse.Mensagem = "Registro incluido com sucesso";
            taskResponse.Sucesso = true;
        }
        catch (Exception ex)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = ex.Message;
        }

        return taskResponse;
    }


    public async Task<TaskResponse<TaskList>> UpdateTask(TaskPutModel task)
    {
        var taskResponse = new TaskResponse<TaskList>();
        var taskSeach = context.TaskList.AsNoTracking().Where(c => c.IdTaskList.Equals(task.IdTaskList)).FirstOrDefault();

        if (taskSeach == null)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = "Nõa existe resultado para o Id informado";
            return taskResponse;
        }

        try
        {
            var taskMapped = new TaskList
            {
                Titulo = task.Titulo,
                Descricao = task.Descricao,
                Finalizada = task.Finalizada,
                DataInicio = task.DataInicio,
                DataFim = task.DataFim,

                DataCriacao = taskSeach.DataCriacao,
                DataAlteracao = DateTime.Now
            };

            context.Update(taskMapped);
            await context.SaveChangesAsync();

            taskResponse.Mensagem = "Registro alterado com sucesso";
            taskResponse.Sucesso = true;
        }
        catch (Exception ex)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = ex.Message;
        }
        return taskResponse;
    }


    public async Task<TaskResponse<TaskList>> UpdateStatusTask(TaskPatchModel task)
    {
        var taskResponse = new TaskResponse<TaskList>();
        var taskSeach = context.TaskList.AsNoTracking().Where(c => c.IdTaskList.Equals(task.IdTaskList)).FirstOrDefault();

        if (taskSeach == null)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = "Nõa existe resultado para o Id informado";
            return taskResponse;
        }

        try
        {
            taskSeach.Finalizada = task.Finalizada;
            taskSeach.DataAlteracao = DateTime.Now;

            context.Update(taskSeach);
            await context.SaveChangesAsync();

            taskResponse.Mensagem = "Registro alterado com sucesso";
            taskResponse.Sucesso = true;
        }
        catch (Exception ex)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = ex.Message;
        }
        return taskResponse;
    }

    public async Task<TaskResponse<TaskList>> DeleteTask(int id)
    {
        var taskResponse = new TaskResponse<TaskList>();
        var taskSeach = context.TaskList.AsNoTracking().Where(c => c.IdTaskList.Equals(id)).FirstOrDefault();

        if (taskSeach == null)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = "Nõa existe resultado para o Id informado";
            return taskResponse;
        }

        try
        {
            context.Remove(taskSeach);
            await context.SaveChangesAsync();

            taskResponse.Mensagem = "Registro excluido com sucesso";
            taskResponse.Sucesso = true;
        }
        catch (Exception ex)
        {
            taskResponse.Sucesso = false;
            taskResponse.Mensagem = ex.Message;
        }

        return taskResponse;

    }

}
