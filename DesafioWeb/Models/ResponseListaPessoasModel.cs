namespace DesafioWeb.Models
{
    public class ResponseListaPessoasModel
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public List<PessoaModel> Pessoas { get; set; } = new();
    }
}
