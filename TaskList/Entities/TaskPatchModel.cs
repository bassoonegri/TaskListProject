namespace TaskListProject.Entities;

public class TaskPatchModel
{
    /// <summary>
    /// Id da tarefa
    /// </summary>
    public int IdTaskList{ get; set; }

    /// <summary>
    /// 0 - Não
    /// 1 - Sim
    /// </summary>
    public bool Finalizada{ get; set; }
}
