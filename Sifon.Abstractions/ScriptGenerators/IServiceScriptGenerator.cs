namespace Sifon.Abstractions.ScriptGenerators
{
    public interface IServiceScriptGenerator
    {
        string StopDependentServices();
        string StartService(string serviceName, int percents);
        string StartPublishingService(string publishingServiceFolder);
    }
}
