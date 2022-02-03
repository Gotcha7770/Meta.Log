namespace Meta.Log.Core.Interfaces;

public interface ISourceFactory
{
    ILogSource CreateFromSingleFile(string file);

    ILogSource CreateFromManyFiles(IEnumerable<string> files);
}