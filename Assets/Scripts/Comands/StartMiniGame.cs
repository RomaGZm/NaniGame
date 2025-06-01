using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("startMiniGame")]
public class StartMiniGame : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var uiManager = Engine.GetService<IUIManager>();
        uiManager.GetUI("MiniGame")?.Show();
        return UniTask.CompletedTask;
    }
}
