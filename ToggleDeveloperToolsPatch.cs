using HarmonyLib;
using UnityEngine;

namespace PathOfIdleDeveloperTools;

// 复用游戏内置的开发者 DebugLayer。
// 该界面包含装备、套装、宝箱、符文、材料和奇物等调试功能。
[HarmonyPatch(typeof(Root), "Update")]
internal static class ToggleDeveloperToolsPatch
{
    private const KeyCode ToggleKey = KeyCode.F6;

    private static void Postfix()
    {
        if (!Input.GetKeyDown(ToggleKey))
            return;

        var uiMgr = Game.uiMgr;
        if (uiMgr == null)
        {
            Plugin.Log.LogWarning("游戏 UI 尚未初始化，暂时无法打开开发者工具。");
            return;
        }

        if (uiMgr.CheckActiveLayer(TLayer.DebugLayer))
        {
            uiMgr.closeLayerByTag(TLayer.DebugLayer);
            Plugin.Log.LogDebug("开发者调试界面已关闭。");
        }
        else
        {
            // 使用游戏原本为调试窗口设置的最高层级，避免被普通界面遮挡。
            uiMgr.openLayer(TLayer.DebugLayer, 100, null);
            Plugin.Log.LogDebug("开发者调试界面已打开。");
        }
    }
}
