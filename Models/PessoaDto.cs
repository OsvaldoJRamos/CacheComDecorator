namespace CacheComDecorator.Models
{
    public class PessoaDto
    {
        public IEnumerable<Pessoa> Pessoas { get; set; }
        public string From { get; set; } = "DataBase";

        public PessoaDto(string from, params Pessoa[] alimentos)
        {
            Pessoas = alimentos.ToList();
            From = from;
        }

        public void FromMemory()
        {
            From = "Memory Cache";
        }
    }
}
