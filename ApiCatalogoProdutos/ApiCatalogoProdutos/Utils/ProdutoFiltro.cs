using Microsoft.IdentityModel.Tokens;

namespace ApiCatalogoProdutos.Utils
{
    public class ProdutoFiltro
    {

        private int _minimoProdutosPorPagina = 5;
        public int MinimoProdutosPorPagina
        {
            get
            {

                return this._minimoProdutosPorPagina;
            }
            set
            {

                if (value < 5)
                {
                    this.MinimoProdutosPorPagina = 5;
                }
                else
                {
                    this._minimoProdutosPorPagina = value;
                }

            }
        }
        private int _maximoProdutosPorPagina = 10;
        public int MaximoProdutosPorPagina
        {
            get
            {

                return this._maximoProdutosPorPagina;
            }
            set
            {

                if (value < 10 || value > 10)
                {
                    this._maximoProdutosPorPagina = 10;
                }
                else
                {
                    this._maximoProdutosPorPagina = value;
                }

            }
        }
        private int _paginaAtual = 1;
        public int PaginaAtual
        {
            get
            {

                return this._paginaAtual;
            }
            set
            {

                if (value <= 0)
                {
                    this._paginaAtual = 1;
                }
                else
                {
                    this._paginaAtual = value;
                }

            }
        }
        private String[] _criterios = { "maior", "menor", "igual" };
        private string _precoCriterio;
        public string PrecoCriterio
        {
            get
            {

                if (this._precoCriterio.IsNullOrEmpty())
                {

                    return this._criterios[ 0 ];
                }

                return this._precoCriterio;
            }
            set
            {

                if (!this._criterios.Contains(value.Trim().ToLower()))
                {
                    this._precoCriterio = this._criterios[0];
                }
                else
                {
                    this._precoCriterio = value.Trim().ToLower();
                }

            }
        }
        private double _precoFiltro;
        public double PrecoFiltro
        {
            get
            {

                return this._precoFiltro;
            }
            set
            {

                if (value <= 0)
                {
                    this._precoFiltro = 0;
                }
                else
                {
                    this._precoFiltro = value;
                }

            }
        }

    }
}
