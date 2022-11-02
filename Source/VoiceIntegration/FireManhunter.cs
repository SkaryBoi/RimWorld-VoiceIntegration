using RimWorld;
using System.Linq;
using Verse;

namespace VoiceIntegration
{
    public class FireManhunter
    {
        public static void ExecuteManhunt()
        {
            // Initiates Storyteller for future use, idk how this works but it is what it is, thanks Tynan
            StorytellerComp storytellerComp = Find.Storyteller.storytellerComps.First((StorytellerComp x) => x is StorytellerComp_OnOffCycle || x is StorytellerComp_RandomMain);

            //storytellerComp gets points on its own with inc(ident)Cat(egory) and target (map raid occurs on)
            IncidentParms parms = storytellerComp.GenerateParms(IncidentCategoryDefOf.ThreatSmall, Find.CurrentMap);

            DoManhunt(parms);
        }

        private static void DoManhunt(IncidentParms parms)
        {
            EventDefOf.AnimalInsanitySingle.Worker.TryExecute(parms);
        }
    }

}