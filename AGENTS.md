# com.orbit.portalsdk — AGENTS.md

## Purpose
Unity UPM package ("Portal SDK for Unity", `package.json` version `1.6.2`, min Unity `2021.0`) wrapping the Orbit
Portal JS SDK for **WebGL builds**. C# lives in `Runtime/Plugins/SDK/` (asmdef `com.orbit.portalsdk`, root
namespace `Orbit`). Outside `UNITY_WEBGL && !UNITY_EDITOR` every native call is a stub (returns `null`/`true`/no-op),
so the API compiles and runs in the Editor without the JS SDK.

## Installation
- Package Manager -> "Add package from git URL":
  `https://github.com/orbit-software/com.orbit.portalsdk.git` (git remote of this repo; no `#tag` since the repo
  has no tags — pin to a commit with `#<sha>` if needed).
- Or add to `Packages/manifest.json`: `"com.orbit.portalsdk": "https://github.com/orbit-software/com.orbit.portalsdk.git"`.
- Import the sample "PortalSDK" (WebGL Template) from Package Manager, then select it as the WebGL template.

## C# API surface (`Runtime/Plugins/SDK/PortalSDK.cs`, `static partial class Orbit.PortalSDK`)
Serializable DTOs: `UserProfile{id, experience, user_name, first_name, last_name, avatar}`,
`GameConfig{supported_screen_formats[], supported_devices[]}`, `ShopItem{id, name, description, price, created,
updated, quantity}`, `ShopItemsResponse{items[]}`, `PurchaseConfirmResponse{status, IsSucсessful}` (note: the
property name contains a Cyrillic "с"), `InvoiceResponse{invoice_link}`, `Achievement{...}`, `enum PurchaseStatus`.
- `GameReady()` — tell the portal the game is loaded (call once at start).
- `Task<bool> IsAdEnabled()` — whether ads are enabled.
- `Task<bool> RequestAd(string placement = null)` / `Task<bool> RequestRewardAd(string placement = null)` — show ad.
- `SetOnAdStart(Action<bool>)` / `SetOnAdEnd(Action<bool>)` — ad lifecycle callbacks; **static methods only**
  (throws `ArgumentException` otherwise). `ClearOnAdStart()` / `ClearOnAdEnd()`.
- `string GetVersion()` — JS SDK version.  `string GetLocale()` — user locale.
- `Task<GameConfig> GetConfig()`; `Task<UserProfile> GetProfile()`.
- `Task<ulong> GetBalanceGems()` / `Task<ulong> GetBalanceCoins()` (parsed from strings; 0 on failure).
- `string GetStartParam()` — app start parameter (e.g. multiplayer session id). `ShowSharing(url, text)`.
- `Task<ShopItemsResponse> GetShopItems()` / `GetPurchasedShopItems()`.
- `Task<PurchaseConfirmResponse> OpenPurchaseConfirmModal(int itemId)` and overload `(int itemId, Vector2Int rect)`
  (rect passes x,y with width/height fixed to 1).
- Cloud KV (sync, PlayerPrefs-like): `string GetValue(key)`, `SetValue(key, value)`, `RemoveValue(key)`.
- `[Obsolete]`: `IsAdRunning()` (false), `ReloadAd()`, `GetBalance()` (string gems), `SetValueAsync`, `GetValueAsync`.
`Internal.cs` holds the `[DllImport("__Internal")]` externs, `TaskCompletionSource` bridging and
`[MonoPInvokeCallback]` static callbacks.

## JS bridge (`Runtime/Plugins/SDK/portalsdk.jslib`)
- Emscripten library merged via `mergeInto(LibraryManager.library, LIB)`; functions map 1:1 to the C# externs.
  Strings go through `UTF8ToString`/`stringToUTF8` + `_malloc`; callbacks via `dynCall_vi`.
- It calls the browser global **`window.PortalSDK`** for almost everything (`gameReady`, `isAdEnabled`,
  `requestAd({placementId})`, `getVersion`, `getConfig`, `getProfile`, `getBalance().balance_gems|balance_coins`,
  `getLocale`, `showSharing`, `getShopItems`, `getPurchasedShopItems`, `openPurchaseConfirmModal(item, rect)`,
  `setValue`/`getValue`, `onAdStart`/`onAdEnd` hooks) and **`window.PortalEmuSDK`** for `getStartParam`,
  `setValueSync`, `getValueSync`, `removeValueSync`.
- The global is provided by the script tag in the WebGL template: `https://sdk.portalapp.games/sdk.umd.js`
  (no `@orbit-software/sdk` npm reference exists in this repo). Template then runs
  `await PortalSDK.initialize(); await PortalSDK.initializeOverlay()` and calls `PortalSDK.gameReady()` after
  `createUnityInstance` resolves. `window.startupConfig = { isFullscreen, overlayPosition }` is set before loading.

## Samples
- `Samples~/PortalSDK/` — WebGL template (`index.html`, `TemplateData/style.css`, progress-bar PNGs) registered in
  `package.json` `samples[]` as "PortalSDK — WebGL Template for PortalSDK". `window.runGame` is defined by the
  template and is expected to be invoked by the portal after `initialize()`.

## Release
- Bump `package.json` `version` (history: commit "Bump version"); no git tags, no CI workflow, no CHANGELOG.
  Consumers on the bare git URL get `main` HEAD.

## Gotchas
- One `TaskCompletionSource` per API in `Internal.cs`: overlapping calls to the same method overwrite the pending
  task (the first awaiter never completes).
- `openPurchaseConfirmModal` returns the plain string `item not found` (not JSON) when the id is unknown;
  `JsonUtility.FromJson` on it yields a default object. `getValueSync` returns `""` for missing keys.
- Ad callbacks must be static because they are passed as raw function pointers to JS.
- `Internal.cs` and `.gitignore` start with a UTF-8 BOM; `.gitignore` references `.idea/.idea.CryptoSteamSDK`
  (legacy project name).
- Every file has a `.meta`; add one when adding assets so Unity does not regenerate GUIDs.
