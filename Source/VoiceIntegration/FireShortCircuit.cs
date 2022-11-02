using RimWorld;
using System.Linq;
using Verse;
namespace VoiceIntegration
{
    public class FireShortCircuit
    {
        public static void ExecuteShortCircuit()
        {
            // Initiates Storyteller for future use, idk how this works but it is what it is, thanks Tynan
            StorytellerComp storytellerComp = Find.Storyteller.storytellerComps.First((StorytellerComp x) => x is StorytellerComp_OnOffCycle || x is StorytellerComp_RandomMain);

            //storytellerComp gets points on its own with inc(ident)Cat(egory) and target (map raid occurs on)
            IncidentParms parms = storytellerComp.GenerateParms(IncidentCategoryDefOf.ThreatSmall, Find.CurrentMap);
            DoShortCircuit(parms);
        }
        private static void DoShortCircuit(IncidentParms parms)
        {
            EventDefOf.ShortCircuit.Worker.TryExecute(parms);
        }
    }
}