using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class Empresa : Entity
{
    #region Properties

    public string Nome { get; private set; }
    public string Fantasia { get; private set; }
    public string Documento { get; private set; }
    public string Telefone { get; set; }

    #endregion Properties

    #region Constructors

    public Empresa(string nome, string fantasia, string documento, string telefone)
    {
        Nome = nome;
        Fantasia = fantasia;
        Documento = documento;
        Telefone = telefone;
    }

    #endregion Constructors
}