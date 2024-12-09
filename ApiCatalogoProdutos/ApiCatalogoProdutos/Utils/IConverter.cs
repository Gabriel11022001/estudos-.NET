namespace ApiCatalogoProdutos.Utils
{
    public interface IConverter<E, T>
    {

        abstract List<T> ConverterLista(List<E> listaConverter);

    }
}
