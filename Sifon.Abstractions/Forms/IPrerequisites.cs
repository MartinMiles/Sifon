﻿namespace Sifon.Abstractions.Forms
{
    public interface IPrerequisites
    {
        bool Chocolatey { get; set; }
        bool Git { get; set; }
        bool WinRM { get; set; }
        bool SIF { get; set; }
        bool NetCore { get; set; }
        bool SqlServer { get; set; }
    }
}
