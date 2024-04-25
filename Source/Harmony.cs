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
    [HarmonyPatch(typeof(GenRecipe), "MakeRecipeProducts")]
    public static class Patch1
    {
        private static readonly float Efficiency = 0.3f;
        private static List<ThingDefCountClass> Receive(Thing apparel){
            if(apparel == null || apparel.Smeltable){
                return new List<ThingDefCountClass>();
            }
            List<ThingDefCountClass> list = new List<ThingDefCountClass>(apparel.CostListAdjusted());
            list.ForEach(t => t.count = (int)Math.Floor(t.count * Efficiency));
            return list.Where(t => t.count > 0).ToList();
        }

        public static bool Prefix(ref RecipeDef recipeDef, ref Pawn worker, ref List<Thing> ingredients)
        {
            string name = recipeDef.defName;
            if(name == "SimpleRecycleApparel" || name == "NeolithicRecycleApparel"){
                recipeDef.products = new List<ThingDefCountClass>(Receive(ingredients.First()));
            }
            return true;
        }
    }
}