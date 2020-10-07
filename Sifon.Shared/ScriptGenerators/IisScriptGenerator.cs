namespace Sifon.Code.ScriptGenerators
{
    public class IisScriptGenerator
    {
        public string Start(int percents)
        {
            return $@"
                    Write-Progress -Activity $activity -CurrentOperation 'starting IIS' -PercentComplete {percents}
                    iisreset /start
                   ";
        }

        public string Stop(int percents)
        {
            return $@"
                    Write-Progress -Activity $activity -CurrentOperation 'stopping IIS' -PercentComplete {percents}
                    iisreset /stop
                    ";
        }
    }
}
