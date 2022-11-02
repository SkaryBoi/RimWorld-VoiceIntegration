using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace VoiceIntegration
{
    public class GameComponent_ButtonHandler : GameComponent
    {
        // Class doesn't work without constructor. GameComponent MUST have Game as a parameter in the constructor.
        public GameComponent_ButtonHandler(Game g) {
            GameComponent gameComp = this;
        }

        // most concise solution to tell program that StartRaid in KeyBindingDefs.xml exists
        KeyBindingDef StartRaid = DefDatabase<KeyBindingDef>.GetNamed("StartRaid");

        public override void GameComponentUpdate()
        {
            if (StartRaid.JustPressed)
            {
                Log.Message("Attempted to StartRaid");
                VoiceIntegration.FireEvent.ExecuteRaid();
            }
        }
    }
}