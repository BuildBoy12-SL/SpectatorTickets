using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace SpectatorTickets
{
    public class EventHandlers
    {
        public SpecTickets plugin;
        public EventHandlers(SpecTickets plugin) => this.plugin = plugin;

        public void OnRoleChange (ChangingRoleEventArgs ev)
        {
            if (ev.NewRole.Equals(RoleType.Spectator) && Round.IsStarted)
            {
                ev.Player.GameObject.AddComponent<SpecComponent>();
            }
        }

        public void OnDeath(DiedEventArgs ev)
        {
            if (Round.IsStarted)
            {
                ev.Target.GameObject.AddComponent<SpecComponent>();
            }
        }
    }
}
