namespace WebAPI.Contracts.Request
{
    public class ProdutoCadastroPutRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
