namespace SpectatorTickets
{
    using Exiled.API.Features;
    using System;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    
    public class SpectatorTickets : Plugin<Configs>
    {
        private EventHandlers _eventHandlers;

        public override void OnEnabled()
        {
            _eventHandlers = new EventHandlers();
            PlayerEvents.ChangingRole += _eventHandlers.OnRoleChange;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerEvents.ChangingRole -= _eventHandlers.OnRoleChange;
            _eventHandlers = null;
        }

        public override string Name => "Build";
        public override Version Version => new Version(1, 0, 1);
    }
}