using FluentValidation;
using Games.Model;
using Games.Service;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [Route("~/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;

    public ProdutoController(IProdutoService produtoService, IValidator<Produto> produtoValidator)
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }

    [HttpGet]
    public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _produtoService.GetById(id);

            if (Resposta is null)
                return NotFound();

            return Ok(Resposta);
        }
    }
}
