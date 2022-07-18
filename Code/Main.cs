using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using Sokpop;

namespace NoMoreHungry
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {

        public const string pluginGuid = "horhorou.stacklands.noMoreHunger";
        public const string pluginName = "No more hunger";
        public const string pluginVersion = "1.0.2";




        public void Awake()
        {
            InitializeMod();
        }


        private void InitializeMod()
        {
            Harmony harmony = new Harmony(pluginGuid);

            MethodInfo originalHungerMethod = AccessTools.Method(typeof(WorldManager), "GetCardRequiredFoodCount");
            MethodInfo prefixPatch = AccessTools.Method(typeof(Main), "GetCardRequiredFoodCount_Patched");


            harmony.Patch(originalHungerMethod, null, new HarmonyMethod(prefixPatch));
        }


        public static void GetCardRequiredFoodCount_Patched(ref int __result)
        {
            __result = 0;
        }


    }
}
