using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace SpectatorTickets
{
    public class SpecTickets : Plugin<Config>
    {
        private EventHandlers EventHandlers;
        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandlers = new EventHandlers(this);
            Player.ChangingRole += EventHandlers.OnRoleChange;
            Player.Died += EventHandlers.OnDeath;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Player.ChangingRole -= EventHandlers.OnRoleChange;
            Player.Died -= EventHandlers.OnDeath;
            EventHandlers = null;
        }
    }
}
