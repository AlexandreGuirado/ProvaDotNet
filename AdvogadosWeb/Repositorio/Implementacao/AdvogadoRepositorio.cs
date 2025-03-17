using System;
using System.Collections.Generic;
using System.Linq;
using AdvogadosWeb.Models.Dominio;
using AdvogadosWeb.Repositorio.Interface;

namespace AdvogadosWeb.Repositorio.Implementacao
{
    public class AdvogadoRepositorio : IAdvogadoRepositorio
    {
        private static List<Advogado> _advogados = new List<Advogado>(); // In-memory data store (replace with database)
        private static int _nextId = 1;

        public IEnumerable<Advogado> ListarAdvogados()
        {
            return _advogados;
        }

        public Advogado ObterAdvogado(int pIntId)
        {
            return _advogados.FirstOrDefault(a => a.Id == pIntId);
        }

        public void IncluirAdvogado(Advogado pObjAdvogado)
        {
            pObjAdvogado.Id = _nextId++;
            _advogados.Add(pObjAdvogado);
        }

        public void AtualizarAdvogado(Advogado pObjAdvogado)
        {
            var existingAdvogado = _advogados.FirstOrDefault(a => a.Id == pObjAdvogado.Id);
            if (existingAdvogado != null)
            {
                existingAdvogado.Nome = pObjAdvogado.Nome;
                existingAdvogado.Senioridade = pObjAdvogado.Senioridade;
                existingAdvogado.Logradouro = pObjAdvogado.Logradouro;
                existingAdvogado.Bairro = pObjAdvogado.Bairro;
                existingAdvogado.Estado = pObjAdvogado.Estado;
                existingAdvogado.CEP = pObjAdvogado.CEP;
                existingAdvogado.Numero = pObjAdvogado.Numero;
                existingAdvogado.Complemento = pObjAdvogado.Complemento;
            }
        }

        public void ExcluirAdvogado(int pIntId)
        {
            var advogadoToRemove = _advogados.FirstOrDefault(a => a.Id == pIntId);
            if (advogadoToRemove != null)
            {
                _advogados.Remove(advogadoToRemove);
            }
        }
    }
}