namespace Desafio.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string? DDD { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set; }
    }
}