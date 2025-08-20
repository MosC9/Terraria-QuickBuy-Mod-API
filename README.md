# QuickBuy Mod API - Developer Guide

This repository provides example code and documentation for developers who want to integrate their Terraria mods with the **QuickBuy Mod**.
### ▶️ [Find the QuickBuy Mod on the Steam Workshop Here](https://steamcommunity.com/sharedfiles/filedetails/?id=3536320364)

---

## 🚀 How to Use

To use this API in your own mod, simply copy the code from the `คู่มือการใช้งาน QuickBuy Mod.Call() (API) สำหรับนักพัฒนา.cs` file and adapt it to your needs.

The core logic involves checking if the QuickBuy mod is enabled before attempting to call its functions:

```csharp
if (ModLoader.TryGetMod("QuickBuy", out Mod quickBuyMod))
{
    // You can now safely call the API functions
    // Example: quickBuyMod.Call("GetBalance", Main.LocalPlayer);
}
else
{
    // Handle the case where QuickBuy is not installed or enabled.
    // It's good practice to disable features that depend on it.
}
```

---

## 📋 API Functions

Here is a summary of the available functions you can call using `quickBuyMod.Call()`:

### `ModifyBalance`
Modifies a player's QB balance.
- **Parameters**: `Player player`, `long amount` (positive to add, negative to subtract)
- **Returns**: `bool` on success, `string` on error.

### `GetBalance`
Retrieves a player's current QB balance.
- **Parameters**: `Player player`
- **Returns**: `long` (balance) on success, `string` on error.

### `GetBuyPrice`
Gets the purchase price of an item.
- **Parameters**: `int itemID`
- **Returns**: `long` (price) on success, `string` on error.

### `GetSellPrice`
Gets the selling price of an item.
- **Parameters**: `int itemID`
- **Returns**: `long` (price) on success, `string` on error.

### `SpawnItem`
Sends an item to a player via a Delivery Box.
- **Parameters**: `Player player`, `int itemID`, `int stack`
- **Returns**: `bool` on success, `string` on error.
