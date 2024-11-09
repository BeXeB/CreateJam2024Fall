using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button saveScoreButton;
    [SerializeField] private GameObject saveScoreDisplay;

    private void OnEnable()
    {
        mainMenuButton.onClick.AddListener(HandleButtonPressed);
        saveScoreButton.onClick.AddListener(HandleSaveButtonPressed);
    }

    private void OnDisable()
    {
        mainMenuButton.onClick.RemoveListener(HandleButtonPressed);
        saveScoreButton.onClick.RemoveListener(HandleSaveButtonPressed);
    }

    private void HandleButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    private void HandleSaveButtonPressed()
    {
        saveScoreDisplay.SetActive(true);
        gameObject.SetActive(false);
    }
}
