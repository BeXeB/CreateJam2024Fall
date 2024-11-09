using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats _instance;
    public static Action<int> onScoreChanged;

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
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
