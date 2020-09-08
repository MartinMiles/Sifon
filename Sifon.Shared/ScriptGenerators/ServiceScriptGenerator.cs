namespace Sifon.Shared.ScriptGenerators
{
    public class ServiceScriptGenerator
    {
        private readonly string _prefix;

        public ServiceScriptGenerator(string prefix)
        {
            _prefix = prefix;
        }

        public string Start(string serviceName, int percents)
        {
            // TODO: when getting service also ask to get those that are active
            return $@"
                $service = Get-Service '{_prefix}*-{serviceName}' -ErrorAction SilentlyContinue
                if($service -And $service.Status -ne 'Running')
                {{
                    Write-Progress -Activity $activity -CurrentOperation 'starting xConnect {serviceName}' -PercentComplete {percents}
                    Start-Service -InputObject $service
                }}
                ";
        }

        public string Stop(string serviceName, int percents)
        {
            return $@"
                    $service = Get-Service '{_prefix}*-{serviceName}' -ErrorAction SilentlyContinue
                    if($service -And $service.Status -eq 'Running')
                    {{
                        Write-Progress -Activity $activity -CurrentOperation 'stopping xConnect {serviceName}' -PercentComplete {percents}
                        Stop-Service -InputObject $service
                    }}
                ";
        }
    }
}
