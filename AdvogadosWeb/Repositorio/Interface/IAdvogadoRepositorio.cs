using System.Collections.Generic;
using AdvogadosWeb.Models.Dominio;

namespace AdvogadosWeb.Repositorio.Interface
{
    public interface IAdvogadoRepositorio
    {
        IEnumerable<Advogado> ListarAdvogados();
        Advogado ObterAdvogado(int pIntId);
        void IncluirAdvogado(Advogado pObjAdvogado);
        void AtualizarAdvogado(Advogado pObjAdvogado);
        void ExcluirAdvogado(int pIntId);
    }
}