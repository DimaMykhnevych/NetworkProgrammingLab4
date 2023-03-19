namespace NureOpenDayBot.CommandHandlers
{
    public interface ITelegramCommandHandler
    {
        public Task HandleAsync(CancellationToken cancellationToken);
    }
}
