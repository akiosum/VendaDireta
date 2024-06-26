﻿using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class ProdutoPreco : Entity
{
    #region Properties

    public Guid IdProduto { get; private set; }
    public decimal Preco { get; private set; }
    public Produto Produto { get; set; }

    #endregion Properties

    #region Constructors

    public ProdutoPreco()
    {
    }

    public ProdutoPreco(decimal preco)
    {
        Preco = preco;
    }

    #endregion Constructors

    #region Methods

    public void Atualizar(decimal valor)
    {
        Preco = valor;
        DataDeAlteracao = DateTime.Now;
    }

    #endregion Methods
}