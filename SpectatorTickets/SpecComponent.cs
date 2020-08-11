using Exiled.API.Features;
using Hints;
using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpectatorTickets
{
    public class SpecComponent : MonoBehaviour
    {
        private Player player;
        private List<CoroutineHandle> coroutines = new List<CoroutineHandle>();

        private void Awake()
        {
            player = Player.Get(gameObject);
            coroutines.Add(Timing.RunCoroutine(HintDisplay()));
        }

        private void Update()
        {
            if(player == null || !player.Role.Equals(RoleType.Spectator))
            {
                Destroy();
            }
        }

        private IEnumerator<float> HintDisplay()
        {
            for (; ; )
            {
                player.ReferenceHub.hints.Show(new TextHint($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n<align=right><color=blue>MTF Tickets:</color> {Respawning.RespawnTickets.Singleton.GetAvailableTickets(Respawning.SpawnableTeamType.NineTailedFox)}</align>" +
                                                            $"\n<align=right><color=green>Chaos Tickets:</color> {Respawning.RespawnTickets.Singleton.GetAvailableTickets(Respawning.SpawnableTeamType.ChaosInsurgency)}</align>", 
                                                            new HintParameter[]
                                                            {
                                                                new StringHintParameter("")
                                                            },
                                                           HintEffectPresets.FadeInAndOut(0f, 0f, 0f), 1.25f));
                yield return Timing.WaitForSeconds(1f);
            }
        }

        private void Destroy()
        {
            try
            {
                foreach (CoroutineHandle coroutine in coroutines)
                    Timing.KillCoroutines(coroutine);

                Destroy(this);
            }
            catch (Exception e)
            {
                Log.Error("Cannot destroy specComponent: " + e);
            }
        }
    }
}
