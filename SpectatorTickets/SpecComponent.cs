namespace SpectatorTickets
{
    using Exiled.API.Features;
    using Hints;
    using MEC;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpecComponent : MonoBehaviour
    {
        private CoroutineHandle _coroutineHandle;
        private Player _player;

        private void Awake()
        {
            _player = Player.Get(gameObject);
            _coroutineHandle = Timing.RunCoroutine(HintDisplay());
        }

        private void Update()
        {
            if (_player == null || _player.Role != RoleType.Spectator)
                Destroy();
        }

        private IEnumerator<float> HintDisplay()
        {
            while (true)
            {
                _player.HintDisplay.Show(
                    new TextHint(
                        $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n<align=right><color=blue>MTF Tickets:</color> {Respawning.RespawnTickets.Singleton.GetAvailableTickets(Respawning.SpawnableTeamType.NineTailedFox)}</align>" +
                        $"\n<align=right><color=green>Chaos Tickets:</color> {Respawning.RespawnTickets.Singleton.GetAvailableTickets(Respawning.SpawnableTeamType.ChaosInsurgency)}</align>",
                        new HintParameter[]
                        {
                            new StringHintParameter("")
                        },
                        HintEffectPresets.FadeInAndOut(0f, 0f, 0f), 0.6f));
                yield return Timing.WaitForSeconds(0.5f);
            }
        }

        private void Destroy()
        {
            Timing.KillCoroutines(_coroutineHandle);
            Destroy(this);
        }
    }
}