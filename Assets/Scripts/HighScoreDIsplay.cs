using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    private void OnEnable()
    {
        highScoreText.text = "";
        for (int i = 0; i < 10; i++)
        {
            var score = ScoreManager.GetEntry(i);
            highScoreText.text += score.name + ": " + score.score + "\n";
        }
    }
}
