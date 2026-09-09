namespace Desafio.Shared.Models
{
    public class TipoTelefone
    {
        private static readonly List<TipoTelefone> tipos =
        [
            new TipoTelefone() { Tipo = "Pessoal" },
            new TipoTelefone() { Tipo = "Comercial" },
            new TipoTelefone() { Tipo = "Whatsapp" }
        ];

        public string Tipo { get; private set; } = string.Empty;

        public static IReadOnlyList<TipoTelefone> GetTipos() => tipos.AsReadOnly();
    }
}
