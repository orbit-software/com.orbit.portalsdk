using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AOT;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace Orbit
{
    public static partial class PortalSDK
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static class Internal
        {
            
            #region Startup Events
        
                        
            #region API Method: requestAd
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void gameReady();
#else
            public static void gameReady() {}
#endif
            #endregion

            #endregion
            
            #region Advertisement
            
            #region API Method: isAdEnabled
            
            private static TaskCompletionSource<bool> isAdEnabledCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void isAdEnabledCallback(bool val) => isAdEnabledCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void isAdEnabled(Action<bool> callback);
#else
            private static void isAdEnabled(Action<bool> cb) => cb(true);
#endif

            public static Task<bool> isAdEnabledAsync()
            {
                isAdEnabledCS = new TaskCompletionSource<bool>();
                isAdEnabled(isAdEnabledCallback);
                return isAdEnabledCS.Task;
            }
            #endregion
            
            #region API Method: isAdRunning
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern bool isAdRunning();
#else
            public static bool isAdRunning() => false;
#endif
            #endregion
            
            #region API Method: reloadAd
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void reloadAd();
#else
            public static void reloadAd() {}
#endif
            #endregion
            
            #region API Method: requestAd
            
            private static TaskCompletionSource<bool> requestAdCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void requestAdCallback(bool val) => requestAdCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void requestAd(Action<bool> callback);
#else
            private static void requestAd(Action<bool> cb) => cb(true);
#endif
            public static Task<bool> requestAdAsync()
            {
                requestAdCS = new TaskCompletionSource<bool>();
                requestAd(requestAdCallback);
                return requestAdCS.Task;
            }
            
            #endregion
            
            #region API Method: requestRewardAd
            
            private static TaskCompletionSource<bool> requestRewardAdCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void requestRewardAdCallback(bool val) => requestRewardAdCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void requestRewardAd(Action<bool> callback);
#else
            private static void requestRewardAd(Action<bool> cb) => cb(true);
#endif
            public static Task<bool> requestRewardAdAsync()
            {
                requestRewardAdCS = new TaskCompletionSource<bool>();
                requestRewardAd(requestRewardAdCallback);
                return requestRewardAdCS.Task;
            }

            #endregion
            
            #endregion
            
            #region SDK Information
            
            #region API Method: getVersion
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern string getVersion();
#else
            public static string getVersion() => null;
#endif
            #endregion

            #endregion
            
            #region Per-App Information
            
            #region API Method: getConfig
            
            private static TaskCompletionSource<string> getConfigCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void getConfigCallback(string val) => getConfigCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void getConfig(Action<string> callback);
#else
            private static void getConfig(Action<string> cb) => cb(null);
#endif

            public static Task<string> getConfigAsync()
            {
                getConfigCS = new TaskCompletionSource<string>();
                getConfig(getConfigCallback);
                return getConfigCS.Task;
            }
            #endregion
            
            #endregion
            
            #region User
            
            #region API Method: getProfile
            
            private static TaskCompletionSource<string> getProfileCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void getProfileCallback(string val) => getProfileCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void getProfile(Action<string> callback);
#else
            private static void getProfile(Action<string> cb) => cb(null);
#endif

            public static Task<string> getProfileAsync()
            {
                getProfileCS = new TaskCompletionSource<string>();
                getProfile(getProfileCallback);
                return getProfileCS.Task;
            }
            #endregion
            
            #region API Method: getBalanceGems
            
            private static TaskCompletionSource<string> getBalanceGemsCS;
            [MonoPInvokeCallback(typeof(Action<string>))] private static void getBalanceGemsCallback(string val) => getBalanceGemsCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void getBalanceGems(Action<string> callback);
#else
            private static void getBalanceGems(Action<string> cb) => cb(null);
#endif

            public static Task<string> getBalanceGemsAsync()
            {
                getBalanceGemsCS = new TaskCompletionSource<string>();
                getBalanceGems(getBalanceGemsCallback);
                return getBalanceGemsCS.Task;
            }
            #endregion
            
            #region API Method: getBalanceCoins
            
            private static TaskCompletionSource<string> getBalanceCoinsCS;
            [MonoPInvokeCallback(typeof(Action<string>))] private static void getBalanceCoinsCallback(string val) => getBalanceCoinsCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void getBalanceCoins(Action<string> callback);
#else
            private static void getBalanceCoins(Action<string> cb) => cb(null);
#endif

            public static Task<string> getBalanceCoinsAsync()
            {
                getBalanceCoinsCS = new TaskCompletionSource<string>();
                getBalanceCoins(getBalanceCoinsCallback);
                return getBalanceCoinsCS.Task;
            }
            #endregion
            
            #region API Method: getLocale
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern string getLocale();
#else
            public static string getLocale() => null;
#endif
            #endregion
            
            #endregion
            
            #region Share
            
            #region API Method: getStartParam
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern string getStartParam();
#else
            public static string getStartParam() => null;
#endif
            #endregion
            
            #region API Method: showSharing
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern string showSharing(string url, string text);
#else
            public static string showSharing(string url, string text) => null;
#endif
            #endregion
            
            
            #endregion
            
            #region IAP
            
            #region API Method: getPurchasedShopItems
            
            private static TaskCompletionSource<string> getPurchasedShopItemsCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void getPurchasedShopItemsCallback(string val) => getPurchasedShopItemsCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void getPurchasedShopItems(Action<string> callback);
#else
            private static void getPurchasedShopItems(Action<string> cb) => cb(null);
#endif

            public static Task<string> getPurchasedShopItemsAsync()
            {
                getPurchasedShopItemsCS = new TaskCompletionSource<string>();
                getPurchasedShopItems(getPurchasedShopItemsCallback);
                return getPurchasedShopItemsCS.Task;
            }
            #endregion
            
            #region API Method: getShopItems
            
            private static TaskCompletionSource<string> getShopItemsCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void getShopItemsCallback(string val) => getShopItemsCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void getShopItems(Action<string> callback);
#else
            private static void getShopItems(Action<string> cb) => cb(null);
#endif

            public static Task<string> getShopItemsAsync()
            {
                getShopItemsCS = new TaskCompletionSource<string>();
                getShopItems(getShopItemsCallback);
                return getShopItemsCS.Task;
            }
            
            #endregion
            
            #region API Method: openPurchaseConfirmModal
            
            private static TaskCompletionSource<string> openPurchaseConfirmModalCS;
            [MonoPInvokeCallback(typeof(Action<int>))] private static void openPurchaseConfirmModalCallback(string val) => openPurchaseConfirmModalCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void openPurchaseConfirmModal(int itemId,  bool useRect, int x, int y, int width, int height, Action<string> callback);
#else
            private static void openPurchaseConfirmModal(int itemId,  bool useRect, int x, int y, int width, int height, Action<string> cb) => cb(null);
#endif

            public static Task<string> openPurchaseConfirmModalAsync(int itemId, bool useRect, int x, int y, int width, int height)
            {
                openPurchaseConfirmModalCS = new TaskCompletionSource<string>();
                openPurchaseConfirmModal(itemId, useRect, x, y, width, height, openPurchaseConfirmModalCallback);
                return openPurchaseConfirmModalCS.Task;
            }
            #endregion

            
            #endregion
            
            #region Cloud Saves

            #region API Method: setValueSync
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void setValueSync(string key, string value);
#else
            public static void setValueSync(string key, string value) { }
#endif
            #endregion
            
            #region API Method: getValueSync
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern string getValueSync(string key);
#else
            public static string getValueSync(string key) { return null; }
#endif
            #endregion
            
            #region API Method: removeValue
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void removeValue(string key);
#else
            public static void removeValue(string key) {}
#endif
            #endregion
            
            #region API Method: setValue
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void setValue(string key, string value);
#else
            public static void setValue(string key, string value) {}
#endif
            #endregion
            
            #region API Method: getValue
            
            private static TaskCompletionSource<string> getValueCS;
            [MonoPInvokeCallback(typeof(Action<string>))] private static void getValueCallback(string val) => getValueCS.TrySetResult(val);

#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void getValue(string key, Action<string> callback);
#else
            private static void getValue(string key, Action<string> cb) => cb(null);
#endif

            public static Task<string> getValueAsync(string key)
            {
                getValueCS = new TaskCompletionSource<string>();
                getValue(key, getValueCallback);
                return getValueCS.Task;
            }
            #endregion
            
            #endregion
            
            #region Ad Callbacks
            
            #region API Method: setOnAdStart
            
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void setOnAdStart(Action<bool> callback);
#else
            public static void setOnAdStart(Action<bool> cb) => cb(true);
#endif
            #endregion
            
            #region API Method: setOnAdEnd
            
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void setOnAdEnd(Action<bool> callback);
#else
            public static void setOnAdEnd(Action<bool> cb) => cb(true);
#endif
            #endregion
            
            #region API Method: clearOnAdStart
            
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void clearOnAdStart();
#else
            public static void clearOnAdStart() {}
#endif
            #endregion
            
            #region API Method: clearOnAdEnd
            
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")] public static extern void clearOnAdEnd();
#else
            public static void clearOnAdEnd() {}
#endif
            #endregion
            
            #endregion
            
        }
    }
}