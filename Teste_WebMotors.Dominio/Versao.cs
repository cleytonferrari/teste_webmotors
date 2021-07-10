using System.Text.Json.Serialization;

namespace Teste_WebMotors.Dominio
{
    public class Versao
    {
        [JsonPropertyName("ID")]
        public int Id{ get; set; }

        [JsonPropertyName("Name")]
        public string Nome { get; set; }
        
        [JsonPropertyName("ModelID")]
        public int ModeloId { get; set; }
    }
}
