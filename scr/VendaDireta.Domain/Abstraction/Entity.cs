namespace VendaDireta.Domain.Abstraction;

public abstract class Entity : BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now;
    public DateTime? DataDeAlteracao { get; set; }
}