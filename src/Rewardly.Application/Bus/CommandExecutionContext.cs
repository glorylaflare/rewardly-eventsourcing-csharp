namespace Rewardly.Application.Bus;

public sealed class CommandExecutionContext
{
    public ICommandBase Command { get; }
    public object Handler { get; }
    public Type CommandType { get; }
    public Type HandlerType { get; }

    public CommandExecutionContext(ICommandBase command, object handler, Type commandType, Type handlerType)
    {
        Command = command;
        Handler = handler;
        CommandType = commandType;
        HandlerType = handlerType;
    }
}
