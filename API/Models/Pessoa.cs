namespace API.Models
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

        public void ValidarEnderecos()
        {
            if (Enderecos.Count == 0)
            {
                throw new Exception("Coloque ao menos um endereço!");
            }
            if (Enderecos.Count(endereco => endereco.IsPrincipal) != 1)
            {
                throw new Exception("Coloque exatamente um endereço principal!");
            }
        }
        public void ValidarNascimento()
        {
            if (DataNascimento.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
            {
                throw new Exception("A data de nascimento não pode ser no futuro!");
            }
        }
        public void Validar()
        {
            ValidarEnderecos();
            ValidarNascimento();

            if (string.IsNullOrWhiteSpace(CPF) || CPF.Length != 11 || !CPF.All(char.IsDigit))
            {
                throw new Exception("O CPF deve ter exatamente 11 dígitos!");
            }
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new Exception("O nome é obrigatório!");
            }

            if (Nome.Trim().Length < 2)
            {
                throw new Exception("O nome deve possuir pelo menos 2 caracteres!");
            }

            if (Nome.Any(char.IsDigit))
            {
                throw new Exception("O nome não pode possuir números!");
            }
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@") || !Email.Contains("."))
            {
                throw new Exception("O email está invalido!");
            }
            foreach(var telefone in Telefones)
            {
                telefone.Validar();
            }
            foreach(var endereco in Enderecos)
            {
                endereco.Validar();
            }
        }
    }
}

