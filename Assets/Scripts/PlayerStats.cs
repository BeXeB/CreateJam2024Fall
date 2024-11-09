using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public static Action<int> onScoreChanged;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private int score;

    public void AddScore(int value)
    {
        score += value;
        onScoreChanged?.Invoke(score);
    }

    public int GetScore()
    {
        return score;
    }

}
