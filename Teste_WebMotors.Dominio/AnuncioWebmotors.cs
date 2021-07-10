using System.ComponentModel.DataAnnotations;

namespace Teste_WebMotors.Dominio
{
    public class AnuncioWebmotors
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marca é obrigatória")]
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

    }
}
