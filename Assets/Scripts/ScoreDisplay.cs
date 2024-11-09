using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreCounter;

    private void OnEnable()
    {
        PlayerStats.onScoreChanged += HandleOnScoreChanged;
        scoreCounter.text = "Score: \n" + 0;
    }

    public void HandleOnScoreChanged(int newValue)
    {
        scoreCounter.text = "Score: \n" + newValue;
    }

    private void OnDisable()
    {
        PlayerStats.onScoreChanged -= HandleOnScoreChanged;
    }
}
