namespace API.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public bool IsPrincipal { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Cep) || Cep.Length != 8 || !Cep.All(char.IsDigit))
            {
                throw new Exception("Informe os 8 dígitos do CEP!");
            }

            if (string.IsNullOrWhiteSpace(Logradouro))
            {
                throw new Exception("A Rua é obrigatória!");
            }

            if (string.IsNullOrWhiteSpace(Numero))
            {
                throw new Exception("Número do endereço é obrigatório!");
            }

            if (string.IsNullOrWhiteSpace(Bairro))
            {
                throw new Exception("Bairro é obrigatório!");
            }

            if (string.IsNullOrWhiteSpace(Cidade))
            {
                throw new Exception("Cidade é obrigatória!");
            }

            if (string.IsNullOrWhiteSpace(Estado))
            {
                throw new Exception("Estado é obrigatório!");
            }
        }
    }
}