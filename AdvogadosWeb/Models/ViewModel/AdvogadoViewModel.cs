using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AdvogadosWeb.Models.Dominio;

namespace AdvogadosWeb.Models.ViewModel
{
    [Serializable]
    public class AdvogadoViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Nome do Advogado é obrigatório.")]
        [Display(Name = "Nome do Advogado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Senioridade é obrigatória.")]
        [Display(Name = "Senioridade")]
        public Senioridade Senioridade { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [Display(Name = "CEP")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido. Use o formato 00000-000.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        public IEnumerable<SelectListItem> Senioridades { get; set; }

        public IEnumerable<SelectListItem> Estados { get; set; }

        public AdvogadoViewModel()
        {
            Senioridades = new List<SelectListItem>();
            Estados = new List<SelectListItem>();
        }

    }
}