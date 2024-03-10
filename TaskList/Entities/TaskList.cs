using System.ComponentModel.DataAnnotations;

namespace TaskListProject.Entities;

public class TaskList
{
    /// <summary>
    /// Chave de identificação da taarefa
    /// </summary>
    [Key]
    public int IdTaskList { get; set; }

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

    /// <summary>
    /// Data de criacao da tarefa
    /// </summary>
    public DateTime DataCriacao { get; set; }

    /// <summary>
    /// Data de alteração das informações da Tarea
    /// </summary>
    public DateTime? DataAlteracao { get; set; }

}
