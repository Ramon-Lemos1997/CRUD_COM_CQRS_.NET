using Domain.Interfaces;

namespace CQRS.Support
{
    public class CommandResult : ICommandResult
    {
        public dynamic Content { get; private set; }

        public int HttpCode { get; private set; }

        public bool HasError { get; private set; }

        public string Key { get; private set; }

        public static ICommandResult Ok(dynamic content = null)
            => new CommandResult { HttpCode = 200, Content = content };

        public static ICommandResult Ok(string key, dynamic content = null)
            => new CommandResult { HttpCode = 200, Content = content, Key = key };

        public static ICommandResult BadRequest(string key = null, dynamic content = null)
            => new CommandResult { HttpCode = 400, Key = key, Content = content, HasError = true };
    }
}