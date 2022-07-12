using Bogus;
using CacheComDecorator.Models;

namespace CacheComDecorator.Queries
{
    public class PessoaQuery : IPessoaQuery
    {
        public IEnumerable<Pessoa> PessoasDisponiveis { get; set; }

        public PessoaQuery()
        {
            var id = 0;
            var testOrders = new Faker<Pessoa>()
                .RuleFor(o => o.Id, f => ++id)
                .RuleFor(o => o.Descricao, f => f.Name.FullName())
                .RuleFor(o => o.Emprego, f => f.Name.JobTitle());

            PessoasDisponiveis = testOrders.Generate(10);
        }

        public PessoaDto GetAll()
        {
            return new PessoaDto("Database", PessoasDisponiveis.ToArray());
        }
    }
}
