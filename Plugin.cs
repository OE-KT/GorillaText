using BepInEx;
using System;
using UnityEngine;
using Utilla;
using System.IO;
using System.Reflection;
using UnityEngine.UI;
namespace type
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public static Plugin instines;
        public static string fileLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
           
            GameObject obj = UnityEngine.Object.Instantiate<GameObject>(AssetBundle.LoadFromFile(Plugin.fileLocation + "\\mic\\hhh").LoadAsset<GameObject>("textconputer"));
            obj.transform.position = new Vector3(-68.2598f, 11.394f, -83.8336f);
            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            obj.transform.rotation = Quaternion.Euler(0, 322.6407f, 0);
            Transform[] allChildren;
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
            GameObject buttonPan = GameObject.Find("textconputer(Clone)/keybord/button");
            allChildren = buttonPan.GetComponentsInChildren<Transform>();
            foreach (Transform button in allChildren)
            {
                button.gameObject.layer = 18;
                button.gameObject.AddComponent<Class1>();
            }

        }

        void Update()
        {
            /* Code here runs every frame when the mod is enabled */
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
