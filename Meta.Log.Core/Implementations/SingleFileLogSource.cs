using DynamicData;
using Meta.Log.Core.Interfaces;

namespace Meta.Log.Core.Implementations;

internal class SingleFileLogSource : ILogSource, IDisposable
{
    private readonly FileSystemWatcher _watcher;

    internal SingleFileLogSource(FileInfo file)
    {
        // if (!File.Exists(file))
        //     throw new FileNotFoundException(file);
        
        _watcher = new FileSystemWatcher(file.DirectoryName);
        _watcher.Filter = file.Name;
    }

    public SourceType Type => SourceType.SingleFile;
    
    public IObservableCache<ILogEntry, long> Items { get; }
    
    public void Dispose()
    {
        _watcher?.Dispose();
    }
}