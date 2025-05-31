using Naninovel;

[CommandAlias("checkScore")]
public class CheckScoreCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        // ѕолучаем сервис управлени€ очками игрока
        var scoreManager = Engine.GetService<PlayerScoreManager>();
        int currentScore = scoreManager.GetScore();

        // —охран€ем текущее количество очков в переменную 'score'
        var variableManager = Engine.GetService<ICustomVariableManager>();
        variableManager.SetVariableValue("score", currentScore.ToString());

        return UniTask.CompletedTask;
    }
}
