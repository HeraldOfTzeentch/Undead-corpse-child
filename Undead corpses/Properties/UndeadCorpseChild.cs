using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;
using HarmonyLib;
using Verse;
using TorannMagic;
using RimWorld;



[assembly: AssemblyTitle("Undead corpses")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Undead corpses")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("1bffc2e9-9931-445d-8e61-6dd7964f242f")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace MagicUndeadCorpseChildren
{ 


[StaticConstructorOnStartup]
public static class StealingDead 
{
    static StealingDead()
        {
        //Harmony.DEBUG = true;
        new Harmony("UndeadCorpseChild").PatchAll();

        }

}

[HarmonyPatch(typeof(TorannMagic.Projectile_RaiseUndead), "RemoveTraits")]
public static class RessurectTraitsPatch
{
    public static void Postfix(Pawn undeadPawn, List<Trait> traits)
    {
       undeadPawn.story.traits.GainTrait(new Trait(TraitDef.Named("CorpseChildren_CorpseChild"), 0, false), false);
        }
}
}