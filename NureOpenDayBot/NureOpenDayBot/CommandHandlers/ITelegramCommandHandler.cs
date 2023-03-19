namespace NureOpenDayBot.CommandHandlers
{
    /// <summary>
    /// Represents common interface for all telegram command handlers.
    /// </summary>
    public interface ITelegramCommandHandler
    {
        /// <summary>
        /// Handles incoming command.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="Task"/>.</returns>
        public Task HandleAsync(CancellationToken cancellationToken);
    }
}
