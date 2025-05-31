using Naninovel;
using UnityEngine;

[InitializeAtRuntime]
public class PlayerScoreManager : IEngineService
{
    private int score;
    public int Score => score;

    public UniTask InitializeServiceAsync()
    {
        // Инициализация сервиса
        return UniTask.CompletedTask;
    }

    public void ResetService()
    {
        // Сброс состояния сервиса
        score = 0;
    }

    public void DestroyService()
    {
        // Освобождение ресурсов сервиса
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log($"Текущий счёт: {score}");
        // Здесь можно обновить UI
    }

    public int GetScore() => score;

 
}
