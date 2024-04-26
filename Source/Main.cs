using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using Verse.Sound;
using Verse.Noise;
using Verse.Grammar;
using RimWorld;
using RimWorld.Planet;

using System.Reflection;
using HarmonyLib;

namespace ArvkusSimpleRecycle
{
    [StaticConstructorOnStartup]
    public static class Start
    {
        static Start()
        {
            Harmony harmony = new Harmony("ArvkusSimpleRecycle");
            harmony.PatchAll( Assembly.GetExecutingAssembly() );
        }
    }



    [DefOf]
    public static class SimpleDefOF
    {
        static public RecycleRecipeDef NeolithicRecycleApparel;
    }


}
