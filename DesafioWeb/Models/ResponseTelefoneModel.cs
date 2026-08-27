namespace DesafioWeb.Models
{
    public class ResponseTelefoneModel
    {
        public bool Success { get; set; }

        public string? Error { get; set; }

        public TelefoneModel? Telefone { get; set; }
    }
}