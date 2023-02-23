using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Libraries;
using Oxide.Game.Rust.Cui;
using Oxide.Core;
using System.Collections.Generic;
using Oxide.Core.Configuration;
using Newtonsoft.Json.Linq;
using Oxide.Core.Plugins;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
using UnityEngine.UI;

namespace Oxide.Plugins
{
  [Info("Factions", "JustKiller - holoxy.net", "0.1.6")]
  class Factions : CovalencePlugin
  {

    private void CreateFactionList(IPlayer player)
    {
      var UIFactionList = new CuiElementContainer();
      var panelfactionsUI = UIFactionList.Add(new CuiPanel
      {
          RectTransform = { AnchorMin = "0.1390625 0.2273148", AnchorMax = "0.8286458 0.9226851" },
          Image = { Color = "0.3607843 0.3607843 0.3607843 0.9063065" },
          CursorEnabled = true
      }, "Overlay", "UIFactionList");

      var HeaderLabel = UIFactionList.Add(new CuiLabel
      {
          RectTransform = { AnchorMin = "0.3028702 0.8908121", AnchorMax = "0.6941087 0.9540611" },
          Text = { Text = "Choose your Faction!", FontSize = 20, Align = TextAnchor.MiddleCenter }
      }, "UIFactionList");

      var background1 = new CuiElement
      {
          Name = "ImagePanel",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.07401803 0.544607", AnchorMax = "0.2250755 0.8109186" }
          }
      };
      UIFactionList.Add(background1);

      // Faction 1
      var F1Btn = UIFactionList.Add(new CuiButton
      {
          //Text = { Text = "Faction 1", FontSize = 12, Align = TextAnchor.MiddleCenter },
          RectTransform = { AnchorMin = "0.07401803 0.544607", AnchorMax = "0.2250755 0.8109186" },
          Button = { Command = "faction.1" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0}
      }, "UIFactionList");


      // Faction 2
      var background2 = new CuiElement
      {
          Name = "ImagePanel2",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.3104221 0.5459385", AnchorMax = "0.4614796 0.8122501" }
          }
      };
      UIFactionList.Add(background2);

      var F2Btn = UIFactionList.Add(new CuiButton
      {
          RectTransform = { AnchorMin = "0.3104221 0.5459385", AnchorMax = "0.4614796 0.8122501" },
          Button = { Command = "faction.2" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
      }, "UIFactionList", "F2Btn");

      

      // Faction 3
      var background3 = new CuiElement
      {
          Name = "ImagePanel3",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.5400301 0.5459386", AnchorMax = "0.69109 0.8122501"}
          }
      };
      UIFactionList.Add(background3);

      var F3Btn = UIFactionList.Add(new CuiButton
      {
          RectTransform = { AnchorMin = "0.5400301 0.5459386", AnchorMax = "0.69109 0.8122501" },
          Button = { Command = "faction.3" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
      }, "UIFactionList", "F3Btn");
     


      // Faction 4
      var background4 = new CuiElement
      {
          Name = "ImagePanel4",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.7734167 0.5459383", AnchorMax = "0.9244742 0.8122502"}
          }
      };
      UIFactionList.Add(background4);
      var F4Btn = UIFactionList.Add(new CuiButton
      {
          RectTransform = { AnchorMin = "0.7734167 0.5459383", AnchorMax = "0.9244742 0.8122502" },
          Button = { Command = "faction.4" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
      }, "UIFactionList","F4Btn");
      

      // Faction 5
      var background5 = new CuiElement
      {
          Name = "ImagePanel5",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.07250746 0.1371503", AnchorMax = "0.2235649 0.4034618" }
          }
      };
      UIFactionList.Add(background5);

      var F5Btn = UIFactionList.Add(new CuiButton
      {
          RectTransform = { AnchorMin = "0.07250746 0.1371503", AnchorMax = "0.2235649 0.4034618" },
          Button = { Command = "faction.5" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
      }, "UIFactionList", "F5Btn");
      

      // Faction 6
      var background6 = new CuiElement
      {
          Name = "ImagePanel6",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.3111773 0.1371501", AnchorMax = "0.4622347 0.4034619"  }
          }
      };
      UIFactionList.Add(background6);

      var F6Btn = UIFactionList.Add(new CuiButton
      {
          RectTransform = { AnchorMin = "0.3111773 0.1371501", AnchorMax = "0.4622347 0.4034619" },
          Button = { Command = "faction.6" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
      }, "UIFactionList", "F6Btn");
      

      // Faction 7
       var background7 = new CuiElement
      {
          Name = "ImagePanel7",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.5385207 0.1358186", AnchorMax = "0.6895781 0.4021304" }
          }
      };
      UIFactionList.Add(background7);

      var F7Btn = UIFactionList.Add(new CuiButton
      {
          RectTransform = { AnchorMin = "0.5385207 0.1358186", AnchorMax = "0.6895781 0.4021304" },
          Button = { Command = "faction.7" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
      }, "UIFactionList", "F7Btn");
     
      

      // Faction 8
      var background8 = new CuiElement
      {
          Name = "ImagePanel8",
          Parent = "UIFactionList",
          Components =
          {
              new CuiRawImageComponent { Url = "https://i.imgur.com/SsYiMz0.png" },
              new CuiRectTransformComponent { AnchorMin = "0.7741705 0.1358186", AnchorMax = "0.9252279 0.4021304" }
          }
      };
      UIFactionList.Add(background8);

      var F8Btn = UIFactionList.Add(new CuiButton
      {
          RectTransform = { AnchorMin = "0.7741705 0.1358186", AnchorMax = "0.9252279 0.4021304" },
          Button = { Command = "faction.8" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
      }, "UIFactionList", "F8Btn");
      
      // Close Btn
      var closeButton = UIFactionList.Add(new CuiButton
      {
          Text = { Text = "X", FontSize = 13, Align = TextAnchor.MiddleCenter },
          RectTransform = { AnchorMin = "0.4395771 0.04993339", AnchorMax = "0.5574018 0.09254329" },
          Button = { Command = "factionlist.close" , Color = "0.1868231 0.4831642 0.468096 0.9135534", FadeIn = 0 }
      }, "UIFactionList");


      var bPlayer = (BasePlayer)player.Object;
      CuiHelper.AddUi(bPlayer, UIFactionList);

    }

    // Init Var
    private DataFileSystem dataFile;
    private Dictionary<string, FactionData> factions;
    private Dictionary<string, int> voteCounts;

    private void Init()
    {
      dataFile = new DataFileSystem($"{Interface.Oxide.DataDirectory}/FactionData");

      factions = dataFile.ReadObject<Dictionary<string, FactionData>>("factions_data") ?? new Dictionary<string, FactionData>();
    }
    private void OnServerInitialized()
    {
      timer.Every(300, () =>
      {
          SaveData();
      });
    }


  

    private void SaveData()
    {
        dataFile.WriteObject("factions_data", factions);
    }
    private class FactionData
    {
        public string FactionName { get; set; }
        public string FactionMotd { get; set; }
        public string FactionDescription { get; set; }
        public Dictionary<string, PlayerData> Players { get; set; }
    }

    private class PlayerData
    {
        public string PlayerName { get; set; }
        public string PlayerID { get; set; }
        public string Rank { get; set; }
        public int Votes { get; set; }
        public bool HasVote { get; set; }
    }

    private bool IsPlayerInFaction(IPlayer player)
    {
        foreach (var faction in factions.Values)
        {
            if (faction.Players.ContainsKey(player.Id))
            {
                return true;
            }
        }
        return false;
    }

    private void AddPlayerToFaction(IPlayer player, string factionName, string rank)
    {
      if (IsPlayerInFaction(player))
      {
          player.Message("You are already a member of a faction and cannot join another.");
          return;
      }
      FactionData faction;
      if (!factions.TryGetValue(factionName, out faction))
      {
          faction = new FactionData
          {
              FactionName = factionName,
              FactionMotd = "",
              FactionDescription = "",
              Players = new Dictionary<string, PlayerData>()
          };
          factions[factionName] = faction;
      }

      string playerId = player.Id;
      if (faction.Players.ContainsKey(playerId))
      {
          player.Message($"You are already a member of {factionName}. ");
          return;
      }

      if (faction.Players.Count >= 25)
      {
          player.Message($"Sorry, {factionName} is already full. Please choose another faction.");
          return;
      }

      string playerName = player.Name;
      faction.Players[playerId] = new PlayerData
      {
          PlayerName = playerName,
          PlayerID = playerId,
          Rank = rank,
          Votes = 0,
          HasVote = false
      };
      player.Message($"You joined the faction {factionName} !");

      SaveData();
    }




    void OnUserConnected(IPlayer player) // check if the player is in a faction or else display the faction menu
    {
      if (!IsPlayerInFaction(player))
      {
          player.Message("You have to choose a faction!");
          CreateFactionList(player);
      }

    }

    [Command("factionlist")]
    private void CommandFactionsList(IPlayer player, string command, string[] args)
    {
        CreateFactionList(player);
    }

    [Command("factionlist.close")]
    private void CommandFactionMenuClose(IPlayer player, string command, string[] args)
    {
        var bPlayer = (BasePlayer)player.Object;
        CuiHelper.DestroyUi(bPlayer, "UIFactionList");
    }

    [Command("faction.1")]
    private void SelectFaction1(IPlayer player, string command, string[] args)
    {
        //player.Message("You chose the Faction 1");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");

        AddPlayerToFaction(player,"The Eternals","Peasants");
        //AddPlayerToClan(player, factionName);
    }

    [Command("faction.2")]
    private void SelectFaction2(IPlayer player, string command, string[] args)
    {
        //player.Message("You chose the Faction 2");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");
        AddPlayerToFaction(player,"The Faceless Ones","Peasants");
    }

    [Command("faction.3")]
    private void SelectFaction3(IPlayer player, string command, string[] args)
    {
        //player.Reply("You chose the Faction 3");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");
        AddPlayerToFaction(player,"The Forsaken","Peasants");
    }

    [Command("faction.4")]
    private void SelectFaction4(IPlayer player, string command, string[] args)
    {
        //player.Reply("You chose the Faction 4");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");
        AddPlayerToFaction(player,"The Grim Reapers","Peasants");
    }

    [Command("faction.5")]
    private void SelectFaction5(IPlayer player, string command, string[] args)
    {
        //player.Reply("You chose the Faction 5");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");
        AddPlayerToFaction(player,"The Illuminati","Peasants");
    }

    [Command("faction.6")]
    private void SelectFaction6(IPlayer player, string command, string[] args)
    {
        // player.Reply("You chose the Faction 6");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");
        AddPlayerToFaction(player,"The Night Stalkers","Peasants");
    }

    [Command("faction.7")]
    private void SelectFaction7(IPlayer player, string command, string[] args)
    {
        //player.Reply("You chose the Faction 7");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");
        AddPlayerToFaction(player,"The Red Cross","Peasants");
    }

    [Command("faction.8")]
    private void SelectFaction8(IPlayer player, string command, string[] args)
    {
        //player.Reply("You chose the Faction 8");
        CuiHelper.DestroyUi((BasePlayer)player.Object, "UIFactionList");
        AddPlayerToFaction(player,"The White Wolves","Peasants");
    }

    public void Unload()
    {
        SaveData();
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
            RectTransform = { AnchorMin = "0.684375 0.1157408", AnchorMax = "0.8666667 0.9537038" },
            Image = { Color = "0.3607843 0.3607843 0.3607843 0.9063065" },
            CursorEnabled = true
        }, "Overlay", "Menu");

        var HeaderLabel = UImenu.Add(new CuiLabel
        {
            RectTransform = { AnchorMin = "0.0228568 0.8849999", AnchorMax = "0.9714284 0.93625" },
            Text = { Text = "Faction Menu", FontSize = 16, Align = TextAnchor.MiddleCenter }
        }, "Menu");

        var HomeBtn = UImenu.Add(new CuiButton
        {
            Text = { Text = "Home", FontSize = 12, Align = TextAnchor.MiddleCenter },
            RectTransform = { AnchorMin = "0.15 0.76", AnchorMax = "0.87 0.82" },
            Button = { Command = "faction" , Color = "0.1868231 0.4831642 0.468096 0.9135534", FadeIn = 0 }
        }, "Menu");

        var VoteBtn = UImenu.Add(new CuiButton
        {
            Text = { Text = "Vote King/Queen", FontSize = 12, Align = TextAnchor.MiddleCenter },
            RectTransform = { AnchorMin = "0.15 0.65", AnchorMax = "0.87 0.71" },
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




    private void CreateContainer(IPlayer player, int type, string VoteChoise, string ErrorHandlerString)
    {
        var UICotainer = new CuiElementContainer();
        switch(type)
        {
            case 1: // Faction Members
            var listPanel = UICotainer.Add(new CuiPanel
            {
                RectTransform = { AnchorMin = "0.1614583 0.1157408", AnchorMax = "0.682292 0.9537038" },
                Image = { Color = "0.3607843 0.3607843 0.3607843 0.9063065" },
                CursorEnabled = true
            }, "Overlay", "FactionMembers");

            var HeaderLabel = UICotainer.Add(new CuiLabel
            {
                RectTransform = { AnchorMin = "0.02133352 0.9464377", AnchorMax = "0.9829991 0.9890302" },
                Text = { Text = "Faction Members", FontSize = 18, Align = TextAnchor.MiddleCenter }
                
            }, "FactionMembers");

            // create a list of players
            var playerNames = new List<string>();
            var playerRanks = new List<string>();
            var playerVotes = new List<int>();
            var playerID = new List<string>();
            var playerHasVote = new List<bool>();
            var playerFactionName = GetPlayerFactionName(player.Id);
            foreach (var playerData in factions[playerFactionName].Players.Values)
            {
                playerNames.Add(playerData.PlayerName);
                playerID.Add(playerData.PlayerID);
                playerRanks.Add(playerData.Rank);
                playerVotes.Add(playerData.Votes);
                playerHasVote.Add(playerData.HasVote);
            }

            var listPlayers = UICotainer.Add(new CuiPanel
            {
                RectTransform = { AnchorMin = "0.007999986 0.009750724", AnchorMax = "0.9879993 0.9079089" },
                Image = { Color = "0.3607843 0.3607843 0.3607843 0" }
            }, "FactionMembers", "listPanelName");

            

            var nameHeaderLabel1 = UICotainer.Add(new CuiLabel
            {
                RectTransform = { AnchorMin = $"0.05 0.95", AnchorMax = "0.27 1" },
                Text = { Text = "Player Name", Align = TextAnchor.MiddleLeft, FontSize = 14 , Color = "0 0.5960785 0.07843138 1"}
            },"listPanelName");
            var rankHeaderLabel1 = UICotainer.Add(new CuiLabel
            {
                RectTransform = { AnchorMin = $"0.275 0.95", AnchorMax = "0.4 1" },
                Text = { Text = "Rank", Align = TextAnchor.MiddleLeft, FontSize = 14 , Color = "0 0.5960785 0.07843138 1"}
                
            },"listPanelName");
            var votesHeaderLabel1 = UICotainer.Add(new CuiLabel
            {
                RectTransform = { AnchorMin = $"0.405 0.95", AnchorMax = "0.47 1" },
                Text = { Text = "Votes", Align = TextAnchor.MiddleLeft, FontSize = 14 , Color = "0 0.5960785 0.07843138 1"}
                
            },"listPanelName");


            if (playerNames.Count > 17)
            {
                var nameHeaderLabel2 = UICotainer.Add(new CuiLabel
                {
                    RectTransform = { AnchorMin = $"0.545 0.95", AnchorMax = "0.765 1" },
                    Text = { Text = "Player Name", Align = TextAnchor.MiddleLeft, FontSize = 14 , Color = "0 0.5960785 0.07843138 1"}
                },"listPanelName");
                var rankHeaderLabel2 = UICotainer.Add(new CuiLabel
                {
                    RectTransform = { AnchorMin = $"0.77 0.95", AnchorMax = "0.895 1" },
                    Text = { Text = "Rank", Align = TextAnchor.MiddleLeft, FontSize = 14 , Color = "0 0.5960785 0.07843138 1"}
                    
                },"listPanelName");
                var votesHeaderLabel2 = UICotainer.Add(new CuiLabel
                {
                    RectTransform = { AnchorMin = $"0.9 0.95", AnchorMax = "0.965 1" },
                    Text = { Text = "Votes", Align = TextAnchor.MiddleLeft, FontSize = 14 , Color = "0 0.5960785 0.07843138 1"}
                    
                },"listPanelName");
            }


            
            for (int i = 0; i < playerNames.Count; i++)
            {
                var offset1 = (0.88 - (i * 0.05)); 
                var offset2 = (0.88 - ((i - 17) * 0.05));
                string VoteNumbers = playerVotes[i].ToString();
                if (i<17){                    
                    var closeButton = UICotainer.Add(new CuiButton
                    {
                        Text = { Text = playerNames[i], FontSize = 14, Align = TextAnchor.MiddleLeft },
                        RectTransform = { AnchorMin = $"0.05 {offset1}", AnchorMax = $"0.27 {offset1 + 0.04}"},
                        Button = { Command = $"select.player {playerNames[i]} {playerID[i]}" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
                    }, "listPanelName");

                    var rankLabel = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = $"0.275 {offset1}", AnchorMax = $"0.4 {offset1 + 0.04}" },
                        Text = { Text = playerRanks[i], FontSize = 14 , Align = TextAnchor.MiddleLeft}
                        
                    },"listPanelName");
                    var votesLabel = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = $"0.405 {offset1}", AnchorMax = $"0.47 {offset1 + 0.04}" },
                        Text = { Text = VoteNumbers , FontSize = 14 , Align = TextAnchor.MiddleLeft}
                        
                    },"listPanelName");

                }else{
                    var closeButton = UICotainer.Add(new CuiButton
                    {
                        Text = { Text = playerNames[i], FontSize = 14, Align = TextAnchor.MiddleLeft },
                        RectTransform = { AnchorMin = $"0.545 {offset2}", AnchorMax = $"0.765 {offset2 + 0.04}"},
                        Button = { Command = $"select.player {playerNames[i]} {playerID[i]}" , Color = "0.1868231 0.4831642 0.468096 0", FadeIn = 0 }
                    }, "listPanelName");

                    var rankLabel = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = $"0.77 {offset2}", AnchorMax = $"0.895 {offset2 + 0.04}" },
                        Text = { Text = playerRanks[i], FontSize = 14 , Align = TextAnchor.MiddleLeft}
                        
                    },"listPanelName");
                    
                    var votesLabel = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = $"0.9 {offset2}", AnchorMax = $"0.965 {offset2 + 0.04}" },
                        Text = { Text = VoteNumbers , FontSize = 14 , Align = TextAnchor.MiddleLeft}
                        
                    },"listPanelName");
                }
            }

            // display vote choise

            

            var yourchoiseLabel = UICotainer.Add(new CuiLabel
            {
                RectTransform = { AnchorMin = "0.545 0.35", AnchorMax = "0.965 0.4" },
                Text = { Text = "Your Choise for the King/Queen", FontSize = 14 , Align = TextAnchor.MiddleCenter}
                
            },"listPanelName");
            var choiseLabel = UICotainer.Add(new CuiLabel
            {
                RectTransform = { AnchorMin = "0.545 0.3", AnchorMax = "0.965 0.35" },
                Text = { Text = VoteChoise, FontSize = 14 , Align = TextAnchor.MiddleCenter, Color = "0 0.5960785 0.07843138 1"}
                
            },"listPanelName");
            var voteButton = UICotainer.Add(new CuiButton
            {
                Text = { Text = "Send Vote", FontSize = 16, Align = TextAnchor.MiddleCenter },
                RectTransform = { AnchorMin = "0.67 0.2", AnchorMax = "0.87 0.25"},
                Button = { Command = $"vote.send {VoteChoise} {ErrorHandlerString}" , Color = "0.1868231 0.4831642 0.468096 0.9135534", FadeIn = 0 }
            }, "listPanelName");

            break;

            //case 2 : container pentru vote 
            case 2: 
                if(ErrorHandlerString == "None")
                {
                    var VoteSuccesPanel = UICotainer.Add(new CuiPanel
                    {
                        RectTransform = { AnchorMin = "0.1614583 0.1157408", AnchorMax = "0.682292 0.9537038" },
                        Image = { Color = "0.3607843 0.3607843 0.3607843 0.9063065" },
                        CursorEnabled = true
                    }, "Overlay", "FactionMembers");

                    var HeaderLabelCase2 = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = "0.02133352 0.9464377", AnchorMax = "0.9829991 0.9890302" },
                        Text = { Text = $"Thank you for voting {VoteChoise} as a King/Queen!", FontSize = 18, Align = TextAnchor.MiddleCenter }
                        
                    }, "FactionMembers");

                    break;
                }else{
                    var VoteSuccesPanel = UICotainer.Add(new CuiPanel
                    {
                        RectTransform = { AnchorMin = "0.1614583 0.1157408", AnchorMax = "0.682292 0.9537038" },
                        Image = { Color = "0.3607843 0.3607843 0.3607843 0.9063065" },
                        CursorEnabled = true
                    }, "Overlay", "FactionMembers");

                    var HeaderLabelCase2 = UICotainer.Add(new CuiLabel
                    {
                        RectTransform = { AnchorMin = "0.02 0.5", AnchorMax = "0.98 0.8" },
                        Text = { Text = ErrorHandlerString, FontSize = 18, Align = TextAnchor.MiddleCenter }
                        
                    }, "FactionMembers");

                    break;
                }
                
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
            var bPlayer = (BasePlayer)player.Object;
            CuiHelper.DestroyUi(bPlayer, "Menu");
            CuiHelper.DestroyUi(bPlayer, "FactionMembers");
            CreateMenu(player);
            CreateContainer(player,2,"None", "Faction Description soon");
        }        
    }

    [Command("factionmenu.vote")]
    private void FactionMenuVoteMenu(IPlayer player, string command, string[] args)
    {
        var bPlayer = (BasePlayer)player.Object;
        CuiHelper.DestroyUi(bPlayer, "FactionMembers"); 
        CreateContainer(player,1,"Not Selected - Please Click on a Player Name", "None");

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
    [Command("select.player")]
    private void SelectPlayerForVoteLabel(IPlayer player, string command, string[] args)
    {        
        if (args.Length == 2)
        {   
            string targetUserName = args[0];
            string targetUserId = args[1];
            var bPlayer = (BasePlayer)player.Object;
            CuiHelper.DestroyUi(bPlayer, "FactionMembers");
            CreateContainer(player,1,targetUserName,targetUserId);
        }
    }

    [Command("vote.send")]
    private void RegisterTheVote(IPlayer player, string command, string[] args)
    {       
        if (args.Length == 2 )
        {   
            // Get the FactionData object for the faction the player belongs to
            FactionData factionData;
            string errorMessage = "None";
            string targetUserName = args[0];
            string targetUserId = args[1];
            var playerFactionName = GetPlayerFactionName(player.Id);
            if(targetUserName != "None" && targetUserId != "None"){
                if (factions.TryGetValue(playerFactionName, out factionData))
                {
                    // Get the PlayerData object for the player
                    PlayerData playerData;

                    if (factionData.Players.TryGetValue(player.Id, out playerData))
                    {         
                        if(!playerData.HasVote){
                            PlayerData votedPlayer;
                            if (factionData.Players.TryGetValue(targetUserId, out votedPlayer))
                            {
                                votedPlayer.Votes = votedPlayer.Votes + 1;
                                playerData.HasVote = true; 
                                SaveData();
                            }else{
                                errorMessage="Cannot find the player you chose!";
                            }
                        }else{
                            errorMessage="You already voted a player!";
                        }          
                        
                    }
                }else{
                    errorMessage="Please Click on a Player before Voting!";
                }
            }
            
            var bPlayer = (BasePlayer)player.Object;
            CuiHelper.DestroyUi(bPlayer, "FactionMembers");
            CreateContainer(player,2,targetUserName,errorMessage);
        }
    }


}
}
