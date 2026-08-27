namespace Desafio.Models
{
    public class ResponsePessoa
    {
        public bool Success { get; set; }

        public Pessoa? Pessoa { get; set; }

        public string? Error { get; set; }
    }
}