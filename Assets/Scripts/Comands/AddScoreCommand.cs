using Naninovel;

[CommandAlias("addScore")]
public class AddScoreCommand : Command
{
    [ParameterAlias("value")]
    public IntegerParameter Value;

    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
        var currentScore = variableManager.GetVariableValue("score");
        int score = int.TryParse(currentScore, out var result) ? result : 0;
        score += Value;
        variableManager.SetVariableValue("score", score.ToString());
        await UniTask.CompletedTask;
    }
}