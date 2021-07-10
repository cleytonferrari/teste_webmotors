using System.Text.Json.Serialization;

namespace Teste_WebMotors.Dominio
{
    public class Modelo
    {
        [JsonPropertyName("ID")]
        public int Id{ get; set; }

        [JsonPropertyName("Name")]
        public string Nome { get; set; }
        
        [JsonPropertyName("MakeID")]
        public int MarcaId { get; set; }
    }
}
