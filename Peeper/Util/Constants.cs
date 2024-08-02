using Peeper.Behaviour;
namespace Peeper.Util
{
    internal static class Constants
    {
        internal const string ITEM_SCAN_NODE_KEY_FORMAT = "Enable scan node of {0}";
        internal const bool ITEM_SCAN_NODE_DEFAULT = true;
        internal const string ITEM_SCAN_NODE_DESCRIPTION = "Shows a scan node on the item when scanning";

        internal const string PEEPER_PRICE_KEY = $"{Plugin.ITEM_NAME} price";
        internal const int PEEPER_PRICE_DEFAULT = 500;
        internal const string PEEPER_PRICE_DESCRIPTION = $"Price for {Plugin.ITEM_NAME}.";

        internal const string PEEPER_WEIGHT_KEY = "Item weight";
        internal const int PEEPER_WEIGHT_DEFAULT = 15;
        internal const string PEEPER_WEIGHT_DESCRIPTION = "Weight (in lbs)";

        internal const string PEEPER_TWO_HANDED_KEY = "Two Handed Item";
        internal const bool PEEPER_TWO_HANDED_DEFAULT = false;
        internal const string PEEPER_TWO_HANDED_DESCRIPTION = "One or two handed item.";

        internal const string PEEPER_CONDUCTIVE_KEY = "Conductive";
        internal const bool PEEPER_CONDUCTIVE_DEFAULT = true;
        internal const string PEEPER_CONDUCTIVE_DESCRIPTION = "Wether it attracts lightning to the item or not. (Or other mechanics that rely on item being conductive)";

        internal const string PEEPER_DROP_AHEAD_PLAYER_KEY = "Drop ahead of player when dropping";
        internal const bool PEEPER_DROP_AHEAD_PLAYER_DEFAULT = true;
        internal const string PEEPER_DROP_AHEAD_PLAYER_DESCRIPTION = "If on, the item will drop infront of the player. Otherwise, drops underneath them and slightly infront.";

        internal const string PEEPER_GRABBED_BEFORE_START_KEY = "Grabbable before game start";
        internal const bool PEEPER_GRABBED_BEFORE_START_DEFAULT = true;
        internal const string PEEPER_GRABBED_BEFORE_START_DESCRIPTION = "Allows wether the item can be grabbed before hand or not";

        internal const string PEEPER_HIGHEST_SALE_PERCENTAGE_KEY = "Highest Sale Percentage";
        internal const int PEEPER_HIGHEST_SALE_PERCENTAGE_DEFAULT = 50;
        internal const string PEEPER_HIGHEST_SALE_PERCENTAGE_DESCRIPTION = "Maximum percentage of sale allowed when this item is selected for a sale.";

        internal static readonly string PEEPER_SCAN_NODE_KEY = string.Format(ITEM_SCAN_NODE_KEY_FORMAT, Plugin.ITEM_NAME);
    }
}
