using Exiled.API.Interfaces;

namespace SpectatorTickets
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
