namespace SpectatorTickets
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;

    public class EventHandlers
    {
        public void OnRoleChange (ChangingRoleEventArgs ev)
        {
            if (ev.NewRole.Equals(RoleType.Spectator) && Round.IsStarted)
                ev.Player.GameObject.AddComponent<SpecComponent>();
        }
    }
}