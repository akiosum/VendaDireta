using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class Cliente : Entity
{
    #region Properties

    public string Nome { get; private set; }
    public string Apelido { get; private set; }

    #endregion Properties

    #region Constructors

    public Cliente(string nome, string apelido)
    {
        Nome = nome;
        Apelido = apelido;
    }

    #endregion Constructors
}