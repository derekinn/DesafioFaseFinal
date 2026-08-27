namespace DesafioWeb.Models
{
    public class ResponsePessoaModel
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public PessoaModel? Pessoa { get; set; }
    }
}