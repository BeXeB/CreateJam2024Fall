using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreCounter;

    private void OnEnable()
    {
        PlayerStats.onScoreChanged += HandleOnScoreChanged;
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
