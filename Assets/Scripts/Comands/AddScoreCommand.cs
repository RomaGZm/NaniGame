using Naninovel;

[CommandAlias("addScore")]
public class AddScoreCommand : Command
{
    [ParameterAlias(NamelessParameterAlias), RequiredParameter]
    public IntegerParameter Value;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var scoreManager = Engine.GetService<PlayerScoreManager>();
        scoreManager.AddScore(Value);
        return UniTask.CompletedTask;
    }
}