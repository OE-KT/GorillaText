using BepInEx;
using System;
using UnityEngine;
using Utilla;
using System.IO;
using System.Reflection;
using UnityEngine.UI;
using BepInEx.Configuration;
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
       static bool inRoom = false;
       static bool ison;
        static GameObject ds;
        public static Plugin instines = new Plugin();
        
        public static string fileLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static ConfigEntry<string> basecoler;
        public static ConfigEntry<string> keybordcoler;
        public static ConfigEntry<string> screencoler;
        public static ConfigEntry<string> textColor;
        Color basea;
        Color KEYBORD;
        Color screencolerdffd;
        Color textd;
        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
            ison = true;
            
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
            ison = false;
            
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
            
            ds = obj;
            #region Config
            basecoler = Config.Bind("Colors",      // The section under which the option is shown
                                       "baseCol",  // The key of the configuration option in the configuration file
                                       "#717175", // The default value
                                       "The base color of the conputer");
            keybordcoler = Config.Bind("Colors",      // The section under which the option is shown
                                       "keybordCol",  // The key of the configuration option in the configuration file
                                       "#ffffff", // The default value
                                       "The keybord color of the conputer");
            screencoler = Config.Bind("Colors",      // The section under which the option is shown
                                       "screenCol",  // The key of the configuration option in the configuration file
                                       "#184a17", // The default value 
                                       "The screen color of the conputer");
            textColor = Config.Bind("Colors",      // The section under which the option is shown
                                       "textCol",  // The key of the configuration option in the configuration file
                                       "#ffffff", // The default value
                                       "The text color of the conputer");
           
            ColorUtility.TryParseHtmlString(basecoler.Value, out basea);
            ColorUtility.TryParseHtmlString(keybordcoler.Value, out KEYBORD);
            ColorUtility.TryParseHtmlString(screencoler.Value, out screencolerdffd);
            ColorUtility.TryParseHtmlString(textColor.Value, out textd);
            Console.WriteLine(basea);
            Console.WriteLine(KEYBORD);
            Console.WriteLine(screencolerdffd);
            Console.WriteLine(textd);

            #endregion
            GameObject.Find("textconputer(Clone)/Cube").GetComponent<MeshRenderer>().material.color = basea;
            GameObject.Find("textconputer(Clone)/Cube (1)").GetComponent<MeshRenderer>().material.color = basea;
            GameObject.Find("textconputer(Clone)/Plane").GetComponent<MeshRenderer>().material.color = screencolerdffd;
            GameObject.Find("textconputer(Clone)/Canvas/Text").gameObject.GetComponent<Text>().color = textd;
            
          
            foreach (Transform button in allChildren)
            {
                if(button.gameObject.name != "button")
               button.gameObject.GetComponent<MeshRenderer>().material.color = KEYBORD;
                
            }
            obj.SetActive(false);


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
            Ative();

                //obj.SetActive(true);
            

        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/
            
                //obj.SetActive(false);
            
            inRoom = false;
            Ative();
        }

        void Ative()
        {
            if(inRoom)
            {
                ds.SetActive(true);
            }
            if(!inRoom)
            {
                ds.SetActive(false);
            }
        }
       public void setupconfig()
        {
            ColorUtility.TryParseHtmlString(basecoler.Value, out basea);
            ColorUtility.TryParseHtmlString(keybordcoler.Value, out KEYBORD);
            ColorUtility.TryParseHtmlString(screencoler.Value, out screencolerdffd);
            ColorUtility.TryParseHtmlString(textColor.Value, out textd);
            GameObject.Find("textconputer(Clone)/Cube").GetComponent<MeshRenderer>().material.color = basea;
            GameObject.Find("textconputer(Clone)/Cube (1)").GetComponent<MeshRenderer>().material.color = basea;
            GameObject.Find("textconputer(Clone)/Plane").GetComponent<MeshRenderer>().material.color = screencolerdffd;
            GameObject.Find("textconputer(Clone)/Canvas/Text").gameObject.GetComponent<Text>().color = textd;
            GameObject buttonPan = GameObject.Find("textconputer(Clone)/keybord/button");
            Transform[] allChildren;
            allChildren = buttonPan.GetComponentsInChildren<Transform>();

            foreach (Transform button in allChildren)
            {
                if (button.gameObject.name != "button")
                    button.gameObject.GetComponent<MeshRenderer>().material.color = KEYBORD;

            }
            
        }
    }
}
