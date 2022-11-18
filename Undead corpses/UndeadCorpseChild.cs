using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Undead_corpses
{
    public class StealingDead : Mod
    {
        public StealingDead(ModContentPack content) : base(content)
        {
            new Harmony("UndeadCorpseChild").PatchAll();
        }
    }

    [HarmonyPatch]
    public static class ResurrectTraitsPatch
    {
        [HarmonyPostfix]
        public static void Postfix(Pawn pawn)
        {
            var corpseChildTrait = new Trait(TraitDef.Named("CorpseChildren_CorpseChild"));
            pawn.story.traits.GainTrait(corpseChildTrait);
        }

        [HarmonyTargetMethod]
        public static MethodBase ExposeTorannMagicInternalType() => AccessTools
            .TypeByName("TorannMagic.Projectile_RaiseUndead")
            .GetMethod("RemoveTraits", BindingFlags.Instance | BindingFlags.NonPublic);
    }
}
