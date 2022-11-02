using RimWorld;

namespace VoiceIntegration
{
    [DefOf]
    public static class EventDefOf
    {
        // Some vanilla Defs don't have DefOfs -- when in doubt, shove them in here and get on with your life.
        public static IncidentDef AnimalInsanitySingle;
        public static IncidentDef AnimalInsanityMass;
        public static IncidentDef ShortCircuit;

        static EventDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(EventDefOf));
        }
    }
}