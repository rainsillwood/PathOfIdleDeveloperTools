using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;

namespace PathOfIdleDeveloperTools;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("PathOfIdle.exe")]
public class Plugin : BasePlugin
{
    internal static new ManualLogSource Log = null!;
    internal static ConfigEntry<KeyCode> configConsoleKey = null!;

    public override void Load()
    {
        Log = base.Log;

        // 自动注册本程序集中的 Harmony 补丁。
        Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, MyPluginInfo.PLUGIN_GUID);

        configConsoleKey = Config.Bind("按键设置", "唤出按键:", KeyCode.F6, "唤出按键");

        Log.LogInfo("Path of Idle Developer Tools loaded. Press F6 to toggle DebugLayer.");
    }
}
