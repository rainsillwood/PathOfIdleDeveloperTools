# Path of Idle Developer Tools

独立的 BepInEx IL2CPP Mod，用于显示《Path of Idle》内置的开发者调试界面。

## 使用方法

1. 指定游戏目录并编译项目：

   ```powershell
   dotnet build -p:PathOfIdleGameDir="D:\path\to\PathOfIdle"
   ```

2. 将 `bin/Debug/net6.0/PathOfIdleDeveloperTools.dll` 放入游戏的 `BepInEx/plugins` 目录。
3. 进入游戏后按 `F6` 打开或关闭内置 `DebugLayer`。

> 调试界面可以直接改变物品、地图和进度数据。使用前建议备份存档，不要点击用途不明确的按钮。
