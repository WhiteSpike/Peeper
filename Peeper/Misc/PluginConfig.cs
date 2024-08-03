using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using Peeper.Util;
using System.Runtime.Serialization;

namespace Peeper.Misc
{
    [DataContract]
    public class PluginConfig : SyncedConfig2<PluginConfig>
    {
        [field: SyncedEntryField] public SyncedEntry<bool> SCAN_NODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> WEIGHT { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> TWO_HANDED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> DROP_AHEAD_PLAYER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> GRABBED_BEFORE_START { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> CONDUCTIVE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> HIGHEST_SALE_PERCENTAGE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MAXIMUM_RANGE {  get; set; }
        public PluginConfig(ConfigFile cfg) : base(Metadata.GUID)
        {
            string topSection = Plugin.ITEM_NAME;

            PRICE = cfg.BindSyncedEntry(topSection, Constants.PEEPER_PRICE_KEY, Constants.PEEPER_PRICE_DEFAULT, Constants.PEEPER_PRICE_DESCRIPTION);
            WEIGHT = cfg.BindSyncedEntry(topSection, Constants.PEEPER_WEIGHT_KEY, Constants.PEEPER_WEIGHT_DEFAULT, Constants.PEEPER_WEIGHT_DESCRIPTION);
            TWO_HANDED = cfg.BindSyncedEntry(topSection, Constants.PEEPER_TWO_HANDED_KEY, Constants.PEEPER_TWO_HANDED_DEFAULT, Constants.PEEPER_TWO_HANDED_DESCRIPTION);
            SCAN_NODE = cfg.BindSyncedEntry(topSection, Constants.PEEPER_SCAN_NODE_KEY, Constants.ITEM_SCAN_NODE_DEFAULT, Constants.ITEM_SCAN_NODE_DESCRIPTION);
            DROP_AHEAD_PLAYER = cfg.BindSyncedEntry(topSection, Constants.PEEPER_DROP_AHEAD_PLAYER_KEY, Constants.PEEPER_DROP_AHEAD_PLAYER_DEFAULT, Constants.PEEPER_DROP_AHEAD_PLAYER_DESCRIPTION);
            CONDUCTIVE = cfg.BindSyncedEntry(topSection, Constants.PEEPER_CONDUCTIVE_KEY, Constants.PEEPER_CONDUCTIVE_DEFAULT, Constants.PEEPER_CONDUCTIVE_DESCRIPTION);
            GRABBED_BEFORE_START = cfg.BindSyncedEntry(topSection, Constants.PEEPER_GRABBED_BEFORE_START_KEY, Constants.PEEPER_GRABBED_BEFORE_START_DEFAULT, Constants.PEEPER_GRABBED_BEFORE_START_DESCRIPTION);
            HIGHEST_SALE_PERCENTAGE = cfg.BindSyncedEntry(topSection, Constants.PEEPER_HIGHEST_SALE_PERCENTAGE_KEY, Constants.PEEPER_HIGHEST_SALE_PERCENTAGE_DEFAULT, Constants.PEEPER_HIGHEST_SALE_PERCENTAGE_DESCRIPTION);
            MAXIMUM_RANGE = cfg.BindSyncedEntry(topSection, Constants.PEEPER_MAXIMUM_RANGE_KEY, Constants.PEEPER_MAXIMUM_RANGE_DEFAULT, Constants.PEEPER_MAXIMUM_RANGE_DESCRIPTION);

            ConfigManager.Register(this);
        }
    }
}
