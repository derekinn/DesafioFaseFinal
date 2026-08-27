namespace Desafio.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? Email { get; set; }
        public List<Telefone> Telefones { get; set; } = new();
        public List<Endereco> Enderecos { get; set; } = new();
    }
}