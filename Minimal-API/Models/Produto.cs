namespace Minimal_API.Models
{
    public class Produto
    {
        public int? id { get; set; }
        public string? nome { get; set; }
        public long? codigo { get; set; }
        public double preco { get; set; }
        public string? descricao { get; set; }
        public int quatidadeEmEstoque { get; set; }
        public double avaliacao { get; set; }
        public string? categoria { get; set; }
    }
}
