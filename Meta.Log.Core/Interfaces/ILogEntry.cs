namespace Meta.Log.Core.Interfaces;

public interface ILogEntry
{
    int LineNumber { get; }
    
    DateTime Timestamp { get; }
    
    string Level { get; }
    
    string Message { get; }
}