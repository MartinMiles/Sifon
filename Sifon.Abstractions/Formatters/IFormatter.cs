namespace Sifon.Abstractions.Formatters
{
    public interface IFormatter<T>
    {
        string Format(T obj);
    }
}
