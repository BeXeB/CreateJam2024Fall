using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveScoreDisplay : MonoBehaviour
{
    [SerializeField] private Button saveScoreButton;
    [SerializeField] private TMP_InputField input;

    private void OnEnable()
    {
        saveScoreButton.onClick.AddListener(HandleSaveButtonPressed);
    }

    private void OnDisable()
    {
        saveScoreButton.onClick.RemoveListener(HandleSaveButtonPressed);
    }

    private void HandleSaveButtonPressed()
    {
        ScoreManager.Record(input.text, PlayerStats.instance.GetScore());
        SceneManager.LoadScene("Menu");
    }
}
