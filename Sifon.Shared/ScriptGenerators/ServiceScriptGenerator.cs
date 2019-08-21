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
            return $@"
                $service = Get-Service '{_prefix}*-{serviceName}' -ErrorAction SilentlyContinue
                if($service -And $service.Status -ne 'Running')
                {{
                    Write-Progress -Activity $activity -CurrentOperation 'starting xConnect {serviceName}' -PercentComplete {percents}
                    net start $service
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
                        net stop $service
                    }}
                ";
        }
    }
}
