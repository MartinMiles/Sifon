﻿namespace Sifon.Abstractions.Forms
{
    public interface IPrerequisites
    {
        bool Chocolatey { get; set; }
        bool Git { get; set; }
        bool SIF { get; set; }
    }
}
