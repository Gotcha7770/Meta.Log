using DynamicData;

namespace Meta.Log.Core.Interfaces;

public enum SourceType
{
    SingleFile,
    ManyFiles
}

public interface ILogSource
{
    SourceType Type { get; }
    
    IObservableCache<ILogEntry, long> Items { get; }
}