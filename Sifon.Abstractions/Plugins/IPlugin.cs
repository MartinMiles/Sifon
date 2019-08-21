namespace Sifon.Abstractions.Plugins
{
    public interface IPlugin
    {
        string Name { get; }
        void Execute();
    }
}
