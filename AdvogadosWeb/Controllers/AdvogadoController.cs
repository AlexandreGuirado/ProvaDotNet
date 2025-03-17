using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AdvogadosWeb.Models.Dominio;
using AdvogadosWeb.Models.ViewModel;
using AdvogadosWeb.Repositorio.Interface;
using AdvogadosWeb.Repositorio.Implementacao;
using System.Threading.Tasks;

namespace AdvogadosWeb.Controllers
{
    public class AdvogadoController : Controller
    {
        private readonly IAdvogadoRepositorio _advogadoRepositorio;

        public AdvogadoController()
        {
            _advogadoRepositorio = new AdvogadoRepositorio();
        }

        // GET: Advogado
        public ActionResult Index()
        {
            var advogados = _advogadoRepositorio.ListarAdvogados();
            return View(advogados);
        }

        // GET: Advogado/Details/5
        public ActionResult Details(int id)
        {
            var advogado = _advogadoRepositorio.ObterAdvogado(id);
            if (advogado == null)
            {
                return HttpNotFound();
            }
            return View(advogado);
        }

        // GET: Advogado/Create
        public async Task<ActionResult> Create()
        {
            var viewModel = new AdvogadoViewModel();
            await PopularViewBag(viewModel);
            return View(viewModel);
        }

        // POST: Advogado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AdvogadoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var advogado = new Advogado
                {
                    Nome = viewModel.Nome,
                    Senioridade = viewModel.Senioridade,
                    Logradouro = viewModel.Logradouro,
                    Bairro = viewModel.Bairro,
                    Estado = viewModel.Estado,
                    CEP = viewModel.CEP,
                    Numero = viewModel.Numero,
                    Complemento = viewModel.Complemento
                };
                _advogadoRepositorio.IncluirAdvogado(advogado);
                return RedirectToAction("Index", new { sucesso = "true" });
            }

            await PopularViewBag(viewModel);
            return View(viewModel);
        }

        // GET: Advogado/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var advogado = _advogadoRepositorio.ObterAdvogado(id);
            if (advogado == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AdvogadoViewModel
            {
                Id = advogado.Id,
                Nome = advogado.Nome,
                Senioridade = advogado.Senioridade,
                Logradouro = advogado.Logradouro,
                Bairro = advogado.Bairro,
                Estado = advogado.Estado,
                CEP = advogado.CEP,
                Numero = advogado.Numero,
                Complemento = advogado.Complemento
            };

            await PopularViewBag(viewModel);
            return View(viewModel);
        }

        // POST: Advogado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AdvogadoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var advogado = new Advogado
                {
                    Id = viewModel.Id.Value,
                    Nome = viewModel.Nome,
                    Senioridade = viewModel.Senioridade,
                    Logradouro = viewModel.Logradouro,
                    Bairro = viewModel.Bairro,
                    Estado = viewModel.Estado,
                    CEP = viewModel.CEP,
                    Numero = viewModel.Numero,
                    Complemento = viewModel.Complemento
                };
                _advogadoRepositorio.AtualizarAdvogado(advogado);
                return RedirectToAction("Index", new { sucesso = "true" });
            }
            await PopularViewBag(viewModel);
            return View(viewModel);
        }

        // GET: Advogado/Delete/5
        public ActionResult Delete(int id)
        {
            var advogado = _advogadoRepositorio.ObterAdvogado(id);
            if (advogado == null)
            {
                return HttpNotFound();
            }
            return View(advogado);
        }

        // POST: Advogado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _advogadoRepositorio.ExcluirAdvogado(id);
            return RedirectToAction("Index");
        }

        private async Task PopularViewBag(AdvogadoViewModel viewModel)
        {
            viewModel.Senioridades = Enum.GetValues(typeof(Senioridade))
                                     .Cast<Senioridade>()
                                     .Select(e => new SelectListItem
                                     {
                                         Value = e.ToString(),
                                         Text = e.ToString(),
                                         Selected = e == viewModel.Senioridade
                                     });

            //Lista HardCore, já que a ViaCep não fornece UFs

            viewModel.Estados = new List<SelectListItem>
            {
                new SelectListItem { Value = "AC", Text = "Acre", Selected = viewModel.Estado == "AC" },
                new SelectListItem { Value = "AL", Text = "Alagoas", Selected = viewModel.Estado == "AL" },
                new SelectListItem { Value = "AP", Text = "Amapá", Selected = viewModel.Estado == "AP" },
                new SelectListItem { Value = "AM", Text = "Amazonas", Selected = viewModel.Estado == "AM" },
                new SelectListItem { Value = "BA", Text = "Bahia", Selected = viewModel.Estado == "BA" },
                new SelectListItem { Value = "CE", Text = "Ceará", Selected = viewModel.Estado == "CE" },
                new SelectListItem { Value = "DF", Text = "Distrito Federal", Selected = viewModel.Estado == "DF" },
                new SelectListItem { Value = "ES", Text = "Espírito Santo", Selected = viewModel.Estado == "ES" },
                new SelectListItem { Value = "GO", Text = "Goiás", Selected = viewModel.Estado == "GO" },
                new SelectListItem { Value = "MA", Text = "Maranhão", Selected = viewModel.Estado == "MA" },
                new SelectListItem { Value = "MT", Text = "Mato Grosso", Selected = viewModel.Estado == "MT" },
                new SelectListItem { Value = "MS", Text = "Mato Grosso do Sul", Selected = viewModel.Estado == "MS" },
                new SelectListItem { Value = "MG", Text = "Minas Gerais", Selected = viewModel.Estado == "MG" },
                new SelectListItem { Value = "PA", Text = "Pará", Selected = viewModel.Estado == "PA" },
                new SelectListItem { Value = "PB", Text = "Paraíba", Selected = viewModel.Estado == "PB" },
                new SelectListItem { Value = "PR", Text = "Paraná", Selected = viewModel.Estado == "PR" },
                new SelectListItem { Value = "PE", Text = "Pernambuco", Selected = viewModel.Estado == "PE" },
                new SelectListItem { Value = "PI", Text = "Piauí", Selected = viewModel.Estado == "PI" },
                new SelectListItem { Value = "RJ", Text = "Rio de Janeiro", Selected = viewModel.Estado == "RJ" },
                new SelectListItem { Value = "RN", Text = "Rio Grande do Norte", Selected = viewModel.Estado == "RN" },
                new SelectListItem { Value = "RS", Text = "Rio Grande do Sul", Selected = viewModel.Estado == "RS" },
                new SelectListItem { Value = "RO", Text = "Rondônia", Selected = viewModel.Estado == "RO" },
                new SelectListItem { Value = "RR", Text = "Roraima", Selected = viewModel.Estado == "RR" },
                new SelectListItem { Value = "SC", Text = "Santa Catarina", Selected = viewModel.Estado == "SC" },
                new SelectListItem { Value = "SP", Text = "São Paulo", Selected = viewModel.Estado == "SP" },
                new SelectListItem { Value = "SE", Text = "Sergipe", Selected = viewModel.Estado == "SE" },
                new SelectListItem { Value = "TO", Text = "Tocantins", Selected = viewModel.Estado == "TO" }
            };
        }
    }
}