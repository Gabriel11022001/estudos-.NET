namespace ApiCatalogoProdutos.Utils
{
    public interface IValidador<T>
    {

        abstract String Validar(T entidadeValidar);

    }
}
