using System.Collections.Generic;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using Oxide.Core.Libraries.Covalence;

namespace Oxide.Plugins
{
    [Info("PluginTest", "dd", "1.0.0")]
    class PluginTest : CovalencePlugin {

        private DataFileSystem dataFile;
        private Dictionary<string, FactionData> factions;
 

        // get the data from the data folder
        private void Init()
        {
         dataFile = new DataFileSystem($"{Interface.Oxide.DataDirectory}/FactionData");
         factions = dataFile.ReadObject<Dictionary<string, FactionData>>("factions") ?? new Dictionary<string, FactionData>();
         
        }
        private class FactionData
        {
            public string FactionName { get; set; }
            public Dictionary<string, PlayerData> Players { get; set; }
        }

        private class PlayerData
        {
            public string PlayerName { get; set; }
            public string PlayerID { get; set; }
            public string Rank { get; set; }
        }

        private string GetPlayerFactionName(string playerId)
        {
            // loop through all factions
            foreach (var factionData in factions.Values)
            {
                // check if the player is in the faction
                if (factionData.Players.ContainsKey(playerId))
                {
                    // return the faction name if the player is found
                    return factionData.FactionName;
                }
            }

            // return null if the player is not found in any faction
            return null;
        }


        private void CreateMenu(IPlayer player)
        {
            var UImenu = new CuiElementContainer();
            var listPanel = UImenu.Add(new CuiPanel
            {
                RectTransform = { AnchorMin = "0.684375 0.1712963", AnchorMax = "0.8666667 0.912037" },
                Image = { Color = "0.3607843 0.3607843 0.3607843 0.9063065" },
                CursorEnabled = true
            }, "Overlay", "Menu");

            var HeaderLabel = UImenu.Add(new CuiLabel
            {
                RectTransform = { AnchorMin = "0.0228568 0.8849999", AnchorMax = "0.9714284 0.93625" },
                Text = { Text = "Faction Menu", FontSize = 16, Align = TextAnchor.MiddleCenter }
            }, "Menu");

            var VoteBtn = UImenu.Add(new CuiButton
            {
                Text = { Text = "Vote King/Queen", FontSize = 12, Align = TextAnchor.MiddleCenter },
                RectTransform = { AnchorMin = "0.1594943 0.7212501", AnchorMax = "0.8714287 0.7800001" },
                Button = { Command = "factionmenu.vote" , Color = "0.1868231 0.4831642 0.468096 0.9135534", FadeIn = 0 }
            }, "Menu");


            var closeButton = UImenu.Add(new CuiButton
            {
                Text = { Text = "X", FontSize = 13, Align = TextAnchor.MiddleCenter },
                RectTransform = { AnchorMin = "0.8742861 0.955", AnchorMax = "0.9914283 0.9974999" },
                Button = { Command = "factionmenu.close" , Color = "0.1868231 0.4831642 0.468096 0.9135534", FadeIn = 0 }
            }, "Menu");


            var bPlayer = (BasePlayer)player.Object;
            CuiHelper.AddUi(bPlayer, UImenu);

        }
        private void CreateContainer(IPlayer player, int type)
        {
            var UICotainer = new CuiElementContainer();
            switch(type)
            {
                case 1: // Faction Members
                var listPanel = UICotainer.Add(new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.1614583 0.1712963", AnchorMax = "0.682292 0.912037" },
                    Image = { Color = "0.3607843 0.3607843 0.3607843 0.9063065" },
                    CursorEnabled = true
                }, "Overlay", "FactionMembers");

                var HeaderLabel = UICotainer.Add(new CuiLabel
                {
                    RectTransform = { AnchorMin = "0.02133352 0.9193518", AnchorMax = "0.9829991 0.9619444" },
                    Text = { Text = "Faction Members", FontSize = 16, Align = TextAnchor.MiddleCenter }
                }, "FactionMembers");

                // create a list of players
                var playerNames = new List<string>();
                var playerRanks = new List<string>();
                var playerFactionName = GetPlayerFactionName(player.Id);
                foreach (var playerData in factions[playerFactionName].Players.Values)
                {
                    playerNames.Add(playerData.PlayerName);
                    playerRanks.Add(playerData.Rank);
                }

                var listPlayers = UICotainer.Add(new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.007999986 0.01625001", AnchorMax = "0.9879993 0.86375" },
                    Image = { Color = "0.3607843 0.3607843 0.3607843 0" }
                }, "FactionMembers", "listPanelName");

                var offset = 0.1f;
                for (int i = 0; i < playerNames.Count; i++)
                {
                    var nameLabel = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = $"0 {1 - (i + 1) * offset}", AnchorMax = "0.3 1" },
                        Text = { Text = playerNames[i], Align = TextAnchor.MiddleCenter}
                    },"listPanelName");
                    var rankLabel = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = $"0.305 {1 - (i + 1) * offset}", AnchorMax = "0.5 1" },
                        Text = { Text = playerRanks[i], Align = TextAnchor.MiddleLeft}
                        
                    },"listPanelName");
                }
                break;

                //case 2 : container pentru vote

                default:
                break;
            }
            


            var bPlayer = (BasePlayer)player.Object;
            CuiHelper.AddUi(bPlayer, UICotainer);
        }

        [Command("faction")]
        private void TestingPanel(IPlayer player, string command, string[] args)
        {
            var playerFactionName = GetPlayerFactionName(player.Id);
            if (playerFactionName == null)
            {
                player.Message("You are not a member of any faction.");
            }
            else
            {
                CreateMenu(player);
                CreateContainer(player,1);
            }
            
            
        }

        // close factionmenu ...and the container
        [Command("factionmenu.close")]
        private void FactionMenuCloseMenu(IPlayer player, string command, string[] args)
        {
            var bPlayer = (BasePlayer)player.Object;
            CuiHelper.DestroyUi(bPlayer, "Menu");
            CuiHelper.DestroyUi(bPlayer, "FactionMembers");             
        }

        // close previus container and open vote container
        [Command("factionmenu.vote")]
        private void FactionMenuVoteMenu(IPlayer player, string command, string[] args)
        {
            var bPlayer = (BasePlayer)player.Object;
            CuiHelper.DestroyUi(bPlayer, "Menu");
            CuiHelper.DestroyUi(bPlayer, "FactionMembers");
        }







        
    }
}