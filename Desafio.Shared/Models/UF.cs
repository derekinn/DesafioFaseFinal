namespace Desafio.Models
{
    public class UF
    {
        private static readonly List<UF> ufs = [
            new UF() {Sigla ="AC", Nome="Acre" },
            new UF() {Sigla ="AL", Nome="Alagoas"},
            new UF() {Sigla ="AP", Nome="Amapá"},
            new UF() {Sigla ="AM", Nome="Amazonas"},
            new UF() {Sigla ="BA", Nome="Bahia"},
            new UF() {Sigla ="CE", Nome="Ceará"},
            new UF() {Sigla ="DF", Nome="Distrito Federal"},
            new UF() {Sigla ="ES", Nome="Espírito Santo"},
            new UF() {Sigla ="GO", Nome="Goiás"},
            new UF() {Sigla ="MA", Nome="Maranhão"},
            new UF() {Sigla ="MT", Nome="Mato Grosso"},
            new UF() {Sigla ="MS", Nome="Mato Grosso do Sul"},
            new UF() {Sigla ="MG", Nome="Minas Gerais"},
            new UF() {Sigla ="PA", Nome="Pará"},
            new UF() {Sigla ="PB", Nome="Paraíba"},
            new UF() {Sigla ="PR", Nome="Paraná"},
            new UF() {Sigla ="PE", Nome="Pernambuco"},
            new UF() {Sigla ="PI", Nome="Piauí"},
            new UF() {Sigla ="RJ", Nome="Rio de Janeiro"},
            new UF() {Sigla ="RN", Nome="Rio Grande do Norte"},
            new UF() {Sigla ="RS", Nome="Rio Grande do Sul"},
            new UF() {Sigla ="RO", Nome="Rondônia"},
            new UF() {Sigla ="RR", Nome="Roraima"},
            new UF() {Sigla ="SC", Nome="Santa Catarina"},
            new UF() {Sigla ="SP", Nome="São Paulo"},
            new UF() {Sigla ="SE", Nome="Sergipe"},
            new UF() {Sigla ="TO", Nome="Tocantins"},
            ];

        public string Sigla { get; private set; } = string.Empty;
        public string Nome { get; private set; } = string.Empty;

        public static IEnumerable<UF> ListaUF => ufs;
    }
}
