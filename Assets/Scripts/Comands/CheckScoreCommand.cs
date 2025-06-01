using Naninovel;

[CommandAlias("checkScore")]
public class CheckScoreCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var scoreManager = Engine.GetService<PlayerScoreManager>();
        int currentScore = scoreManager.GetScore();

        var variableManager = Engine.GetService<ICustomVariableManager>();
        variableManager.SetVariableValue("score", currentScore.ToString());

        return UniTask.CompletedTask;
    }
}
