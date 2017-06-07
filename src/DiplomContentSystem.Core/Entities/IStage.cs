using System;

namespace DiplomContentSystem.Core
{
    public interface IStage
    {
        string Name { get; }
        DateTime StartDate {get;}
        DateTime EndDate { get; }
        bool Accepted {get;}
    }
}
