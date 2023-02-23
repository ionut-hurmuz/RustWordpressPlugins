using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("AntiRaid", "JustKiller / Holoxy Solutions", "1.0.0")]
    [Description("Blocks raiding when there are less than 5 players online or during the first 7 days after wipe.")]
    public class AntiRaid : RustPlugin
    {
        private bool isRaidBlocked = false;
        private DateTime serverUptime;

        private void OnServerInitialized()
        {
            serverUptime = DateTime.UtcNow;
            PrintToConsole("AntiRaid plugin has been initialized.");
        }

        private void OnPlayerInit(BasePlayer player)
        {
            if (isRaidBlocked && (BasePlayer.activePlayerList.Count < 5 || DateTime.UtcNow < serverUptime.AddDays(7)))
            {
                player.ChatMessage("Raiding is currently blocked due to low player count or during the first 7 days after wipe.");
            }
        }

        private void OnEntityTakeDamage(BaseCombatEntity entity, HitInfo hitInfo)
        {
            if (entity is BuildingBlock && hitInfo.Initiator is BasePlayer)
            {
                BasePlayer player = hitInfo.Initiator as BasePlayer;
                if (isRaidBlocked && (BasePlayer.activePlayerList.Count < 5 || DateTime.UtcNow < serverUptime.AddDays(7)))
                {
                    player.ChatMessage("Raiding is currently blocked due to low player count or during the first 7 days after wipe.");
                    hitInfo.damageTypes.ScaleAll(0);
                    hitInfo.DoHitEffects = false;
                    hitInfo.HitMaterial = 0;
                }
            }
        }

        [ChatCommand("antiraid")]
        private void cmdAntiRaid(BasePlayer player, string command, string[] args)
        {
            if (player.net.connection.authLevel < 1)
            {
                player.ChatMessage("You do not have permission to use this command.");
                return;
            }

            isRaidBlocked = !isRaidBlocked;
            player.ChatMessage("Raiding has been " + (isRaidBlocked ? "blocked" : "unblocked") + ".");
        }
    }
}
