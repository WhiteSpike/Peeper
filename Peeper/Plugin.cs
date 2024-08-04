using BepInEx;
using BepInEx.Logging;
using Peeper.Behaviour;
using Peeper.Misc;
using HarmonyLib;
using LethalLib.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
namespace Peeper
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.sigurd.csync")]
    [BepInDependency("evaisa.lethallib")]
    [BepInDependency("com.github.WhiteSpike.CustomItemBehaviourLibrary")]
    public class Plugin : BaseUnityPlugin
    {
        internal const string ITEM_NAME = "Peeper";
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);

        public new static PluginConfig Config;

        void Awake()
        {
            Config = new PluginConfig(base.Config);

            // netcode patching stuff
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "peeper");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);
            string root = "Assets/Peeper/";

            Item peeperItem = ScriptableObject.CreateInstance<Item>();
            peeperItem.name = "PeeperItemProperties";
            peeperItem.allowDroppingAheadOfPlayer = Config.DROP_AHEAD_PLAYER;
            peeperItem.canBeGrabbedBeforeGameStart = Config.GRABBED_BEFORE_START;
            peeperItem.canBeInspected = false;
            peeperItem.creditsWorth = Config.PRICE;
            peeperItem.restingRotation = new Vector3(0f, 0f, 0f);
            peeperItem.rotationOffset = new Vector3(100f, 0f, 225f);
            peeperItem.positionOffset = new Vector3(-1f, 0.1f, 0.9f);
            peeperItem.weight = 1f + ((Config.WEIGHT - 1) / 100f);
            peeperItem.twoHanded = Config.TWO_HANDED;
            peeperItem.itemIcon = bundle.LoadAsset<Sprite>(root + "Icon.png");
            peeperItem.spawnPrefab = bundle.LoadAsset<GameObject>(root + "Peeper.prefab");
            peeperItem.dropSFX = bundle.LoadAsset<AudioClip>(root + "Drop.ogg");
            peeperItem.grabSFX = bundle.LoadAsset<AudioClip>(root + "Grab.ogg");
            peeperItem.pocketSFX = bundle.LoadAsset<AudioClip>(root + "Pocket.ogg");
            peeperItem.throwSFX = bundle.LoadAsset<AudioClip>(root + "Throw.ogg");
            peeperItem.highestSalePercentage = Config.HIGHEST_SALE_PERCENTAGE;
            peeperItem.itemName = ITEM_NAME;
            peeperItem.itemSpawnsOnGround = true;
            peeperItem.isConductiveMetal = Config.CONDUCTIVE;
            peeperItem.requiresBattery = false;
            peeperItem.batteryUsage = 0f;

            PeeperBehaviour grabbableObject = peeperItem.spawnPrefab.AddComponent<PeeperBehaviour>();
            grabbableObject.itemProperties = peeperItem;
            grabbableObject.grabbable = true;
            grabbableObject.grabbableToEnemies = true;
            NetworkPrefabs.RegisterNetworkPrefab(peeperItem.spawnPrefab);

            TerminalNode infoNode = SetupInfoNode();
            Items.RegisterShopItem(shopItem: peeperItem, itemInfo: infoNode, price: peeperItem.creditsWorth);

            bundle.Unload(unloadAllLoadedObjects: false);

            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
        internal static TerminalNode SetupInfoNode()
        {
            TerminalNode infoNode = ScriptableObject.CreateInstance<TerminalNode>();
            infoNode.displayText += GetDisplayInfo() + "\n";
            infoNode.clearPreviousText = true;
            return infoNode;
        }
        public static string GetDisplayInfo()
        {
            return "Looks at Coil-Heads for you.\n";
        }
    }   
}
