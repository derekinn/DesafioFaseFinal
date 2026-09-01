using DesafioWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace DesafioWeb.Controllers
{
    public class PessoaController : Controller
    {
        private readonly HttpClient http;

        public PessoaController(IHttpClientFactory httpClientFactory)
        {
            http = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index(string? TermoBusca, string? TipoFiltro)
        {
            string url = "https://localhost:7234/api/Agenda";

            if (!string.IsNullOrWhiteSpace(TermoBusca)) 
            {
                url += $"?busca={Uri.EscapeDataString(TermoBusca)}" + $"&tipoBusca={Uri.EscapeDataString(TipoFiltro ?? "")}";

            }

            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Erro = "Não foi possível carregar as pessoas!";
                return View(new List<PessoaModel>());
            }

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseListaPessoasModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao buscar pessoas!";
            }

            return View(resultado?.Pessoas ?? new List<PessoaModel>());
        }

        [HttpGet]
        public IActionResult Criar()
        {
            var pessoa = new PessoaModel
            {
                DataNascimento = DateOnly.FromDateTime(DateTime.Today)
            };

            pessoa.Enderecos.Add(new EnderecoModel 
            {
                IsPrincipal = true
            });

            pessoa.Telefones.Add(new TelefoneModel());

            return View(pessoa);
        }
        [HttpPost]
        public async Task<IActionResult> Criar(PessoaModel pessoa)
        {
            string url = "https://localhost:7234/api/Agenda";

            var json = JsonSerializer.Serialize(pessoa);

            var conteudo = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await http.PostAsync(url, conteudo);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions 
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao cadastrar pessoa!";

                return View(pessoa);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            string url = $"https://localhost:7234/api/Agenda/{id}";

            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Erro = "Não foi possível carregar a pessoa!";
                return RedirectToAction(nameof(Index));
            }

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponsePessoaModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true || resultado.Pessoa == null)
            {
                ViewBag.Erro = resultado?.Error ?? "Pessoa não encontrada!";
                return RedirectToAction(nameof(Index));
            }

            if (TempData["Erro"] != null)
            {
                ViewBag.Erro = TempData["Erro"];
            }

            return View(resultado.Pessoa);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(PessoaModel pessoa)
        {
            string url = $"https://localhost:7234/api/Agenda/{pessoa.Id}";

            var json = JsonSerializer.Serialize(pessoa);

            var conteudo = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await http.PutAsync(url, conteudo);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true) 
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao atualizar pessoa!";

                return View(pessoa);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            string url = $"https://localhost:7234/api/Agenda/{id}";

            var response = await http.DeleteAsync(url);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao deletar pessoa!";
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CriarEndereco(int pessoaId)
        {
            var endereco = new EnderecoModel
            {
                PessoaId = pessoaId,
                IsPrincipal = false
            };

            return View(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> CriarEndereco(EnderecoModel endereco)
        {
            string url = $"https://localhost:7234/api/Agenda/{endereco.PessoaId}/enderecos";

            var json = JsonSerializer.Serialize(endereco);

            var conteudo = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await http.PostAsync(url, conteudo);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao cadastrar endereço!";
                return View(endereco);
            }

            return RedirectToAction(
                nameof(Editar),
                new { id = endereco.PessoaId });
        }
        [HttpGet]
        public async Task<IActionResult> EditarEndereco(int id)
        {
            string url = $"https://localhost:7234/api/Agenda/enderecos/{id}";

            var response = await http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Erro = "Não foi possível carregar o endereço!";
                return RedirectToAction(nameof(Index));
            }

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseEnderecoModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true || resultado.Endereco == null)
            {
                ViewBag.Erro = resultado?.Error ?? "Endereço não encontrado!";
                return RedirectToAction(nameof(Index));
            }

            return View(resultado.Endereco);
        }
        [HttpPost]
        public async Task<IActionResult> EditarEndereco(EnderecoModel endereco)
        {
            string url = $"https://localhost:7234/api/Agenda/enderecos/{endereco.Id}";

            var json = JsonSerializer.Serialize(endereco);

            var conteudo = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await http.PutAsync(url, conteudo);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao atualizar endereço!";

                return View(endereco);
            }

            return RedirectToAction(nameof(Editar), new { id = endereco.PessoaId });
        }
        [HttpGet]
        public async Task<IActionResult> EditarTelefone(int id)
        {
            string url = $"https://localhost:7234/api/Agenda/telefones/{id}";

            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Erro = "Não foi possível carregar o telefone!";
                return RedirectToAction(nameof(Index));
            }

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseTelefoneModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true || resultado.Telefone == null)
            {
                ViewBag.Erro = resultado?.Error ?? "Telefone não encontrado!";
                return RedirectToAction(nameof(Index));
            }

            return View(resultado.Telefone);
        }
        [HttpPost]
        public async Task<IActionResult> EditarTelefone(TelefoneModel telefone)
        {
            string url = $"https://localhost:7234/api/Agenda/telefones/{telefone.Id}";

            var json = JsonSerializer.Serialize(telefone);

            var conteudo = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await http.PutAsync(url, conteudo);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao atualizar telefone!";

                return View(telefone);
            }

            return RedirectToAction(
                nameof(Editar),
                new { id = telefone.PessoaId });
        }
        [HttpPost]
        public async Task<IActionResult> DeletarEndereco(int enderecoId, int pessoaId)
        {
            string url = $"https://localhost:7234/api/Agenda/enderecos/{enderecoId}";

            var response = await http.DeleteAsync(url);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                TempData["Erro"] = resultado?.Error ?? "Erro ao deletar endereço!";

                return RedirectToAction(
                    nameof(Editar),
                    new { id = pessoaId });
            }

            return RedirectToAction(
                nameof(Editar),
                new { id = pessoaId });

        }
        [HttpGet]
        public IActionResult CriarTelefone(int pessoaId)
        {
            var telefone = new TelefoneModel
            {
                PessoaId = pessoaId
            };
            return View(telefone);
        }
        [HttpPost]
        public async Task<IActionResult> CriarTelefone(TelefoneModel telefone)
        {
            string url = $"https://localhost:7234/api/Agenda/{telefone.PessoaId}/telefones";

            var json = JsonSerializer.Serialize(telefone);

            var conteudo = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await http.PostAsync(url, conteudo);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                ViewBag.Erro = resultado?.Error ?? "Erro ao cadastrar telefone!";

                return View(telefone);
            }

            return RedirectToAction(
                nameof(Editar),
                new { id = telefone.PessoaId });
        }
        [HttpPost]
        public async Task<IActionResult> DeletarTelefone(int telefoneId, int pessoaId)
        {
            string url = $"https://localhost:7234/api/Agenda/telefones/{telefoneId}";

            var response = await http.DeleteAsync(url);

            string resposta = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPIModel>(
                resposta,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true)
            {
                TempData["Erro"] = resultado?.Error ?? "Erro ao deletar telefone!";

                return RedirectToAction(
                    nameof(Editar),
                    new { id = pessoaId });
            }

            return RedirectToAction(
                nameof(Editar),
                new { id = pessoaId });
        }
        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            string url = $"https://localhost:7234/api/Agenda/{id}";

            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return Content("Não foi possível carregar os dados da pessoa!");
            }

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponsePessoaModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado?.Success != true || resultado.Pessoa == null)
            {
                return Content(
                    resultado?.Error ?? "Pessoa não encontrada!");
            }

            return PartialView("_DetalhesPessoa", resultado.Pessoa);
        }
    }
}