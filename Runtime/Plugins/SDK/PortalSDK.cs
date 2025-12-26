using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using UnityEngine;

namespace Orbit
{
    /// <summary>
    /// Represents a user profile
    /// </summary>
    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class UserProfile
    {
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        public ulong id;

        /// <summary>
        /// The total experience points the user has earned.
        /// </summary>
        public ulong experience;

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string user_name;

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string first_name;

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string last_name;

        /// <summary>
        /// The URL of the user's avatar image.
        /// </summary>
        public string avatar;
    }


    /// <summary>
    /// Represents the configuration of game
    /// </summary>
    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameConfig
    {
        /// <summary>
        /// The orientation of the application ('landscape' | 'portrait' | 'fullscreen').
        /// </summary>
        public string[] supported_screen_formats;

        /// <summary>
        /// A list of supported devices for the application.
        /// </summary>
        public string[] supported_devices;
    }
    
    /// <summary>
    /// Represents an item
    /// </summary>
    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ShopItem
    {
        /// <summary>
        /// The unique identifier of the shop item.
        /// </summary>
        public int id;

        /// <summary>
        /// The name of the shop item.
        /// </summary>
        public string name;

        /// <summary>
        /// The description of the shop item.
        /// </summary>
        public string description;

        /// <summary>
        /// The price of the shop item.
        /// </summary>
        public int price;

        /// <summary>
        /// The date and time when the shop item was created.
        /// </summary>
        public DateTime created;

        /// <summary>
        /// The date and time when the shop item was last updated.
        /// </summary>
        public DateTime updated;
        
        /// <summary>
        /// Quantity of purchased items
        /// </summary>
        public int quantity;
    }

    /// <summary>
    /// Represents the response from creating an invoice.
    /// </summary>
    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class InvoiceResponse
    {
        /// <summary>
        /// The link to the created invoice.
        /// </summary>
        public string invoice_link;
    }

    /// <summary>
    /// Represents achievement
    /// </summary>
    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Achievement
    {
        /// <summary>
        /// Achievement ID
        /// </summary>
        public uint id;
        /// <summary>
        /// Achievement name
        /// </summary>
        public string name;
        
        /// <summary>
        /// Achievement description
        /// </summary>
        public string description;
        
        /// <summary>
        /// Achieved status
        /// </summary>
        public bool achieved;
        
        /// <summary>
        /// Icon url
        /// </summary>
        public string icon;
    }
    
    /// <summary>
    /// Represents the response from get shop items
    /// </summary>
    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ShopItemsResponse
    {
        /// <summary>
        /// List of shop items.
        /// </summary>
        public ShopItem[] items;
    }
    
    /// <summary>
    /// Represents the response from purchase shop item
    /// </summary>
    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PurchaseConfirmResponse
    {
        /// <summary>
        /// Status: "success" | "error"
        /// </summary>
        public string status;
        public bool IsSucсessful => status == "success";
    }

    [Serializable]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum PurchaseStatus
    {
        Success,
        Error,
    }

    /// <summary>
    /// Provides various methods for interacting with the PortalSDK.
    /// </summary>
    public static partial class PortalSDK
    {
    
        #region Startup Events
        
        /// <summary>
        /// Send event what game is loaded and ready. Required.
        /// </summary>
        public static void GameReady() => Internal.gameReady();
    
        #endregion
    
        #region Advertisement

        /// <summary>
        /// Checks if advertisements are enabled.
        /// </summary>
        /// <returns>True if ads are enabled; otherwise, false.</returns>
        public static async Task<bool> IsAdEnabled() => await Internal.isAdEnabledAsync();

              
        /// <summary>
        /// Requests an advertisement to be shown.
        /// </summary>
        /// <returns>Success</returns>
        public static async Task<bool> RequestAd() => await Internal.requestAdAsync();
        
        /// <summary>
        /// Requests an reward advertisement to be shown.
        /// </summary>
        /// <returns>Success</returns>
        public static async Task<bool> RequestRewardAd() => await Internal.requestRewardAdAsync();

        /// <summary>
        /// [Obsolete] Checks if an advertisement is currently running.
        /// </summary>
        /// <returns>True if an ad is running; otherwise, false.</returns>
        [Obsolete]
        public static bool IsAdRunning() => false;

        /// <summary>
        /// [Obsolete] Reload active advertisement
        /// </summary>
        [Obsolete]
        public static void ReloadAd() {}

        
        #endregion

        #region SDK Information
        
        /// <summary>
        /// Retrieves the version of the SDK.
        /// </summary>
        /// <returns>The version string.</returns>
        public static string GetVersion() => Internal.getVersion();
        
        #endregion

        #region Per-App Information

        /// <summary>
        /// Retrieves the configuration for loaded game
        /// </summary>
        /// <returns>The configuration of game.</returns>
        public static async Task<GameConfig> GetConfig() => JsonUtility.FromJson<GameConfig>(await Internal.getConfigAsync());
        
        #endregion

        #region User
        
        /// <summary>
        /// Retrieves the user's profile.
        /// </summary>
        /// <returns>The user's profile.</returns>
        public static async Task<UserProfile> GetProfile() => JsonUtility.FromJson<UserProfile>(await Internal.getProfileAsync());

        /// <summary>
        /// [Obsolete] Retrieves the user's gems (for IAPs balance) balance.
        /// </summary>
        /// <returns>The balance as a string.</returns>
        [Obsolete] public static async Task<string> GetBalance() => (await Internal.getBalanceGemsAsync());

        /// <summary>
        /// Retrieves the user's gems (for IAPs) balance.
        /// </summary>
        /// <returns>The balance as a string.</returns>
        public static async Task<ulong> GetBalanceGems()
        {
            ulong.TryParse(await Internal.getBalanceGemsAsync(), out var result);
            return result;
        }

        /// <summary>
        /// Retrieves the user's coins balance.
        /// </summary>
        /// <returns>The balance as a string.</returns>
        public static async Task<ulong> GetBalanceCoins()
        {
            ulong.TryParse(await Internal.getBalanceCoinsAsync(), out var result);
            return result;
        }
         
        /// <summary>
        /// Get current user locale
        /// </summary>
        /// <returns>User locale</returns>
        public static string GetLocale() => Internal.getLocale();

        
        #endregion

        #region Share
        
        /// <summary>
        /// Retrieves any start parameter of the application. Currently used for transferring multiplayer session IDs to games.
        /// </summary>
        /// <returns>The start parameter.</returns>
        public static string GetStartParam() => Internal.getStartParam();

        /// <summary>
        /// Show telegram's share dialog for join new players into multiplayer session right from game overlay
        /// </summary>
        /// <param name="url">Your internal sessionId/roomId</param>
        /// <param name="text">Text in share dialog</param>
        public static void ShowSharing(string url, string text) => Internal.showSharing(url, text);

        #endregion
        
        #region IAP

        /// <summary>
        /// Retrieves all shop items.
        /// </summary>
        /// <returns>A list of shop items.</returns>
        public static async Task<ShopItemsResponse> GetShopItems() => JsonUtility.FromJson<ShopItemsResponse>(await Internal.getShopItemsAsync());

        /// <summary>
        /// Retrieves purchased shop items.
        /// </summary>
        public static async Task<ShopItemsResponse> GetPurchasedShopItems() => JsonUtility.FromJson<ShopItemsResponse>(await Internal.getPurchasedShopItemsAsync());

        /// <summary>
        /// Open purchase confirm modal to buy shop item
        /// </summary>
        /// <param name="itemId">Item ID</param>
        public static async Task<PurchaseConfirmResponse> OpenPurchaseConfirmModal(int itemId) =>
            JsonUtility.FromJson<PurchaseConfirmResponse>(
                await Internal.openPurchaseConfirmModalAsync(itemId, false, 0, 0, 0, 0));

        /// <summary>
        /// Open purchase confirm modal to buy shop item
        /// </summary>
        /// <param name="itemId">Item ID</param>
        /// <param name="rect">Position of purchase-confirmation popup</param>
        public static async Task<PurchaseConfirmResponse> OpenPurchaseConfirmModal(int itemId, Vector2Int rect) =>
            JsonUtility.FromJson<PurchaseConfirmResponse>(
                await Internal.openPurchaseConfirmModalAsync(itemId, true, rect.x, rect.y, 1, 1));
        
        #endregion

        #region Cloud Saves
        
        /// <summary>
        /// (Sync) Key-value storage (similar to PlayerPrefs). Get value.
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>Value or string.Empty if value not exist</returns>
        public static string GetValue(string key) => Internal.getValueSync(key);

        /// <summary>
        /// (Sync) Key-value storage (similar to PlayerPrefs). Set value.
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <param name="value">Value</param>
        public static void SetValue(string key, string value) => Internal.setValueSync(key, value);

        /// <summary>
        /// Key-value storage (similar to PlayerPrefs). Remove value by key.
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>Value or null if value not exist</returns>
        public static void RemoveValue(string key) => Internal.removeValue(key);
        
        /// <summary>
        /// [Obsolete] Key-value storage (similar to PlayerPrefs). Set value.
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <param name="value">Value</param>
        [Obsolete]
        public static void SetValueAsync(string key, string value) => Internal.setValue(key, value);

        /// <summary>
        /// [Obsolete] Key-value storage (similar to PlayerPrefs). Get value.
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>Value or string.Empty if value not exist</returns>
        [Obsolete]
        public static async Task<string> GetValueAsync(string key) => await Internal.getValueAsync(key);
        
        
        #endregion
        
        #region Ad Callbacks
        
        public static void SetOnAdStart(Action<bool> callback)
        {
            if (callback != null && !callback.Method.IsStatic) {
                throw new ArgumentException("Only static methods are allowed as ad callbacks");
            }
            
            Internal.setOnAdStart(callback);
        }

        public static void SetOnAdEnd(Action<bool> callback)
        {
            if (callback != null && !callback.Method.IsStatic) {
                throw new ArgumentException("Only static methods are allowed as ad callbacks");
            }
            
            Internal.setOnAdEnd(callback);
        }
        public static void ClearOnAdStart() => Internal.clearOnAdStart();
        public static void ClearOnAdEnd() => Internal.clearOnAdEnd();

        #endregion

    }
}
