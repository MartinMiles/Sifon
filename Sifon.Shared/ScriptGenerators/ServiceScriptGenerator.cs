using System;
using Sifon.Shared.Statics;

namespace Sifon.Shared.ScriptGenerators
{
    public class ServiceScriptGenerator
    {
        private readonly string _prefix;

        public ServiceScriptGenerator(string prefix)
        {
            _prefix = prefix;
        }

        public string StopDependentServices()
        {
            string executionScript = String.Empty;

            executionScript += StopService(Settings.Services.MarketingAutomation, 10);
            executionScript += StopProcess(Settings.Process.MarketingAutomationEngine);

            executionScript += StopService(Settings.Services.IndexWorker, 12);
            executionScript += StopProcess(Settings.Process.Indexer);

            executionScript += StopService(Settings.Services.ProcessingEngineService, 15);
            executionScript += StopProcess(Settings.Process.ProcessingEngine);

            return executionScript;
        }

        public string StartService(string serviceName, int percents)
        {
            return $@"
                $service = Get-Service '{_prefix}*-{serviceName}' -ErrorAction SilentlyContinue
                if($service -And $service.Status -ne 'Running')
                {{
                    Write-Progress -Activity $activity -CurrentOperation 'starting xConnect {serviceName}' -PercentComplete {percents}
                    Start-Service -InputObject $service
                }}
                ";
        }

        private string StopService(string serviceName, int percents)
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

        public string StopProcess(string processName)
        {
            return $@"  Try {{
                                $Process = Get-Process -Name {processName} -ErrorAction SilentlyContinue
	                            Stop-Process -InputObject $Process -Force
				                Write-Output ""Stopping $Process""
                        }}
                        Catch {{ }}
                    ";
        }
    }
}
