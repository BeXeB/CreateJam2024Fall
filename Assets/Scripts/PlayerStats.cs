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
    private int currentBonus = 0;

    public void AddScore(int value, bool wasStunned)
    {
        if (wasStunned)
        {
            currentBonus = 0;
        }
        else currentBonus += value;
        score += currentBonus;
        onScoreChanged?.Invoke(score);
    }

    public int GetScore()
    {
        return score;
    }

}
