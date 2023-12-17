

namespace Domain.Interfaces
{
    public interface ICommandResult
    {
        dynamic Content { get; }
        int HttpCode { get; }
        bool HasError { get; }
        string Key { get; }
    }
}
