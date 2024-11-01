﻿using DiscotecaAPI.DTOs;
using DiscotecaAPI.Models;

namespace DiscotecaAPI.Services
{
    public interface IComandaService
    {
        Comanda ObterPorId(int id);
        IEnumerable<Comanda> ListarTodas();
        void CriarComanda(ComandaDTO comanda);
        void VincularCliente(int comandaId, Cliente cliente);
        void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda);
        decimal CalcularTotal(int comandaId);
        void PagarComanda(int comandaId);
    }
}
