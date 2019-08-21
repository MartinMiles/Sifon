using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Sifon.PowerShell
{
    //TODO: Duplicates Main
    public class SimpleRunner
    {
        public IEnumerable<T> Execute<T>(string script)
        {
            var results = new List<T>();
            try
            {
                using (System.Management.Automation.PowerShell PowerShellInstance = System.Management.Automation.PowerShell.Create())
                {
                    PowerShellInstance.AddScript(script);

                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    foreach (PSObject outputItem in PSOutput)
                    {
                        if (outputItem != null)
                        {
                            results.Add((T)outputItem.BaseObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return results;
        }
    }
}
