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
        public const string pluginVersion = "1.0.1.0";




        public void Awake()
        {
            InitializeMod();
        }


        private void InitializeMod()
        {
            Harmony harmony = new Harmony(pluginGuid);
            MethodInfo original = AccessTools.Method(typeof(Villager), "GetRequiredFoodCount");
            MethodInfo patched = AccessTools.Method(typeof(Main), "GetRequiredFoodCount_Patched");

            harmony.Patch(original, new HarmonyMethod(patched));
        }


        public static bool GetRequiredFoodCount_Patched()
        {
            return false;
        }

    }
}
