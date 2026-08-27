namespace DesafioWeb.Models
{
    public class ResponseEnderecoModel
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public EnderecoModel? Endereco { get; set; }
    }
}