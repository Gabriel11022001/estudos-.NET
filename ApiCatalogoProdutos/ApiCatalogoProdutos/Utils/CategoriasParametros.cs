namespace ApiCatalogoProdutos.Utils
{
    public class CategoriasParametros
    {

        private const int _maximoElementosPagina = 50;
        public int PaginaAtual { get; set; } = 1;
        private int _tamanhoPagina = 5;
        public int TamanhoPagina
        {
            get
            {

                return this._tamanhoPagina;
            }
            set
            {

                if (value <= 5 || value > _maximoElementosPagina)
                {

                    this._tamanhoPagina = 5;
                }
                else
                {
                    this._tamanhoPagina = value;
                }

            }
        }

    }
}
