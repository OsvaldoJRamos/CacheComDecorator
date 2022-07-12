using CacheComDecorator.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CacheComDecorator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaQuery pessoaQuery;

        public PessoaController(
            IPessoaQuery pessoaQuery)
        {
            this.pessoaQuery = pessoaQuery;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pessoaQuery.GetAll());
        }

    }
}
