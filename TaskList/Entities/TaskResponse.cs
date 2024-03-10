namespace TaskListProject.Entities;

public class TaskResponse<T>
{
    /// <summary>
    /// Dados da(s) tarefa(s)
    /// </summary>
    public T? Tarefas { get; set; }

    /// <summary>
    /// Mensagem de retorno
    /// </summary>
    public string Mensagem { get; set; } = string.Empty;
    
    /// <summary>
    /// Flag de sucesso da operação
    /// </summary>
    public bool Sucesso { get; set; } = true;
}
