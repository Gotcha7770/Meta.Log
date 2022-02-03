using Meta.Log.Core.Interfaces;

namespace Meta.Log.Core.Implementations;

internal class SourceFactory : ISourceFactory
{
    public ILogSource CreateFromSingleFile(string file)
    {
        return new SingleFileLogSource(new FileInfo(file));
    }

    public ILogSource CreateFromManyFiles(IEnumerable<string> files)
    {
        throw new NotImplementedException();
    }
}