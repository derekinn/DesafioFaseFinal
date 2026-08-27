using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using System.Security.Cryptography;

namespace API.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaService agendaService;
        public AgendaController(AgendaService agendaService)
        {
            this.agendaService = agendaService;
        }

        [HttpPost]
        public IActionResult SalvarPessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                int id = agendaService.SalvarPessoa(pessoa);
                return Ok(new { Success = true, Id = id });
            }
            catch (Exception ex)
            {
                return Ok(new { Success = false, Error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Listar(
          [FromQuery] string? busca,
          [FromQuery] string? tipoBusca)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(busca))
                {
                    return Ok(new
                    {
                        Success = true,
                        Pessoas = agendaService.ListarPessoas()
                    });
                }

                if (tipoBusca != "CPF" && tipoBusca != "Nome")
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Tipo de busca inválido!"
                    });
                }

                if (tipoBusca == "CPF")
                {
                    if (!busca.All(char.IsDigit))
                    {
                        return Ok(new
                        {
                            Success = false,
                            Error = "Para pesquisar por CPF, informe somente números!"
                        });
                    }
                }

                if (tipoBusca == "Nome")
                {
                    if (!busca.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        return Ok(new
                        {
                            Success = false,
                            Error = "Para pesquisar por nome, informe somente letras!"
                        });
                    }
                }

                var pessoas = agendaService.BuscarPessoas(
                    busca,
                    tipoBusca
                );

                return Ok(new
                {
                    Success = true,
                    Pessoas = pessoas
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                }); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {
            try
            {
                var pessoa = agendaService.ObterPessoaCompleta(id);

                if (pessoa == null)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhuma pessoa encontrada"
                    });
                }
                return Ok(new
                {
                    Success = true,
                    Pessoa = pessoa
                });

            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                int PessoaDeletada = agendaService.DeletarPessoa(id);
                if (PessoaDeletada == 0)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhuma pessoa encontrada"
                    });
                }
                return Ok(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult Atualizar(int id, [FromBody] Pessoa pessoa)
        {
            try
            {
                pessoa.Id = id;
                int LinhasMudadas = agendaService.AtualizarPessoa(pessoa);

                if (LinhasMudadas == 0)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhuma pessoa encontrada"
                    });
                }

                return Ok(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpPost("{pessoaId}/telefones")]
        public IActionResult AdicionarTelefone(int pessoaId, [FromBody] Telefone telefone)
        {
            try
            {
                int id = agendaService.AdicionarTelefone(pessoaId, telefone);

                return Ok(new
                {
                    Success = true,
                    Id = id
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpPut("telefones/{id:int}")]
        public IActionResult AtualizarTelefone(int id, [FromBody] Telefone telefone)
        {
            try
            {
                int TelefoneAtualizado = agendaService.AtualizarTelefone(id, telefone);

                if (TelefoneAtualizado == 0)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhum telefone encontrado!"
                    });
                }
                return Ok(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpGet("telefones/{id:int}")]
        public IActionResult ObterTelefone(int id)
        {
            try
            {
                var telefone = agendaService.ObterTelefone(id);

                if (telefone == null)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhum telefone encontrado!"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Telefone = telefone
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpDelete("telefones/{id:int}")]
        public IActionResult DeletarTelefone(int id)
        {
            try
            {
                int telefoneDeletado = agendaService.DeletarTelefone(id);

                if (telefoneDeletado == 0)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhum telefone encontrado!"
                    });
                }

                return Ok(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpPost("{pessoaId}/enderecos")]
        public IActionResult AdicionarEndereco(int pessoaId, [FromBody] Endereco endereco)
        {
            try
            {
                int id = agendaService.AdicionarEndereco(pessoaId, endereco);
                return Ok(new
                {
                    Success = true,
                    Id = id
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpPut("enderecos/{id:int}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] Endereco endereco)
        {
            try
            {
                int enderecoAtualizado = agendaService.AtualizarEndereco(id, endereco);

                if (enderecoAtualizado == 0)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhum endereço encontrado!"
                    });
                }
                return Ok(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpDelete("enderecos/{id:int}")]
        public IActionResult DeletarEndereco(int id)
        {
            try
            {
                int enderecoDeletado = agendaService.DeletarEndereco(id);

                if (enderecoDeletado == 0)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhum endereço encontrado!"
                    });
                }
                return Ok(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
        [HttpGet("enderecos/{id:int}")]
        public IActionResult ObterEndereco(int id)
        {
            try
            {
                var endereco = agendaService.ObterEndereco(id);

                if (endereco == null)
                {
                    return Ok(new
                    {
                        Success = false,
                        Error = "Nenhum endereço encontrado!"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Endereco = endereco
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
    }
}