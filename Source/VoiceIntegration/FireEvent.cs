using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace VoiceIntegration
{
    public class FireEvent
    {

        // partly copied from DebugActionsIncidents.ExecuteRaidWithFaction
        public static void ExecuteRaid()
        {
            // Initiates Storyteller for future use, idk how this works but it is what it is, thanks Tynan
            StorytellerComp storytellerComp = Find.Storyteller.storytellerComps.First((StorytellerComp x) => x is StorytellerComp_OnOffCycle || x is StorytellerComp_RandomMain);

            //storytellerComp gets points on its own with inc(ident)Cat(egory) and target (map raid occurs on)
            IncidentParms parms = storytellerComp.GenerateParms(IncidentCategoryDefOf.ThreatBig, Find.CurrentMap);

            // makes sure raid is from enemy faction, and not Ancients or Insects who can't carry out raids
            parms.faction = Find.FactionManager.AllFactions.RandomElement();
            while (!parms.faction.HostileTo(Faction.OfPlayer) || parms.faction.def == FactionDefOf.Insect || parms.faction.def == FactionDefOf.Ancients || parms.faction.def == FactionDefOf.AncientsHostile)
            {
                parms.faction = Find.FactionManager.AllFactions.RandomElement();
            }

            // RaidStrategy (NOT RANDOMIZED, some are advanced and we don't know what stage of the game player is in)
            // tl;dr fix this so it uses a generated raidstrategy
            parms.raidStrategy = DefDatabase<RaidStrategyDef>.GetNamed("ImmediateAttack");

            VoiceIntegration.FireEvent.DoRaid(parms);
        }
        private static void DoRaid(IncidentParms parms)
        {
            IncidentDef incidentDef;
            if (parms.faction.HostileTo(Faction.OfPlayer))
            {
                incidentDef = IncidentDefOf.RaidEnemy;
            }
            else
            {
                incidentDef = IncidentDefOf.RaidFriendly;
            }
            incidentDef.Worker.TryExecute(parms);
        }
    }
}
