namespace DesafioWeb.Models
{
    public class PessoaModel
    {
        public List<EnderecoModel> Enderecos { get; set; } = new();
        public List<TelefoneModel> Telefones { get; set; } = new();
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? Email { get; set; }
    }
}
