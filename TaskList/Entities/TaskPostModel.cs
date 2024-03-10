namespace TaskListProject.Entities;

public class TaskPostModel
{
    /// <summary>
    /// Titulo da tarefa
    /// </summary>
    public string Titulo { get; set; }

    /// <summary>
    /// Descrição da tarefa
    /// </summary>
    public string Descricao { get; set; }

    /// <summary>
    /// Flag identificadora se a tarefa finalizada - 0 Não , 1 - Sim
    /// </summary>
    public bool Finalizada { get; set; }

    /// <summary>
    /// Data de Inicio da tarefa
    /// </summary>
    public DateTime DataInicio { get; set; }

    /// <summary>
    /// Data de conclusão da tarefa
    /// </summary>
    public DateTime? DataFim { get; set; }
}
