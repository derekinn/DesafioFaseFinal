namespace API.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string? DDD { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(DDD) ||
                DDD.Length < 2 || DDD.Length > 3 || !DDD.All(char.IsDigit))
            {
                throw new Exception("DDD Incorreto!");
            }

            if (string.IsNullOrWhiteSpace(Numero) ||
                (Numero.Length != 8 && Numero.Length != 9) || !Numero.All(char.IsDigit))
            {
                throw new Exception(
                    "O telefone deve possuir 8 ou 9 dígitos numéricos!");
            }

            if (string.IsNullOrWhiteSpace(Tipo) ||
                (Tipo != "Pessoal" &&
                 Tipo != "Comercial" &&
                 Tipo != "Whatsapp"))
            {
                throw new Exception(
                    "É obrigatório informar um tipo de telefone válido!");
            }
        }
    }
}
