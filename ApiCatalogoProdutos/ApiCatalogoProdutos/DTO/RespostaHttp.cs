namespace ApiCatalogoProdutos.DTO
{
    public class RespostaHttp<T>
    {

        public string Mensagem { get; set; }
        public bool Ok { get; set; }
        public T Conteudo { get; set; }

        public RespostaHttp() { }

        public RespostaHttp(string mensagem, bool ok, T Conteudo)
        {
            this.Mensagem = mensagem;
            this.Ok = ok;
            this.Conteudo = Conteudo;
        }

    }
}
