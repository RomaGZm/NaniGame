using Naninovel;
using UnityEngine;

[InitializeAtRuntime]
public class PlayerScoreManager : IEngineService
{
    private int score;
    public int Score => score;

    public UniTask InitializeServiceAsync()
    {
        return UniTask.CompletedTask;
    }

    public void ResetService()
    {
        score = 0;
    }

    public void DestroyService()
    {
    
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log($"Текущий счёт: {score}");
    
    }

    public int GetScore() => score;

 
}
