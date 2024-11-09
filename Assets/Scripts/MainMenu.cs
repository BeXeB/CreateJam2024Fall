using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject audioSettingsPanel;
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject tutorialPanel;
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button audioSettingsButton;
    [SerializeField] private Button highScoreButton;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private Button audioSettingsBackButton;
    [SerializeField] private Slider masterVolumeSlider;

    [SerializeField] private Button highScoreBackButton;
    [SerializeField] private Button tutorialBackButton;

    private void Awake()
    {
        mainMenuPanel.SetActive(true);
        audioSettingsPanel.SetActive(false);
        highScorePanel.SetActive(false);
        tutorialPanel.SetActive(false);

        masterVolumeSlider.value = AudioListener.volume;
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(HandlePlayButtonClicked);
        tutorialButton.onClick.AddListener(HandleTutorialButtonClicked);
        audioSettingsButton.onClick.AddListener(HandleAudioSettingsButtonClicked);
        highScoreButton.onClick.AddListener(HandleHighScoreButtonClicked);
        quitButton.onClick.AddListener(HandleQuitButtonClicked);
        
        audioSettingsBackButton.onClick.AddListener(HandleAudioSettingsBackButtonClicked);
        masterVolumeSlider.onValueChanged.AddListener(HandleMasterVolumeSliderValueChanged);

        highScoreBackButton.onClick.AddListener(HandleHighScoreBackButtonClicked);
        tutorialBackButton.onClick.AddListener(HandleTutorialBackButtonClicked);
    }
    
    private void OnDisable()
    {
        playButton.onClick.RemoveListener(HandlePlayButtonClicked);
        tutorialButton.onClick.RemoveListener(HandleTutorialButtonClicked);
        audioSettingsButton.onClick.RemoveListener(HandleAudioSettingsButtonClicked);
        highScoreButton.onClick.RemoveListener(HandleHighScoreButtonClicked);
        quitButton.onClick.RemoveListener(HandleQuitButtonClicked);
        
        audioSettingsBackButton.onClick.RemoveListener(HandleAudioSettingsBackButtonClicked);
        masterVolumeSlider.onValueChanged.RemoveListener(HandleMasterVolumeSliderValueChanged);

        highScoreBackButton.onClick.RemoveListener(HandleHighScoreBackButtonClicked);
        tutorialBackButton.onClick.RemoveListener(HandleTutorialBackButtonClicked);
    }

    private void HandlePlayButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        AudioMananger.instance.PlayMusicClip("Game");
        SceneManager.LoadScene("TestScene");
    }

    private void HandleTutorialButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        tutorialPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    private void HandleAudioSettingsButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        audioSettingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    private void HandleHighScoreButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        highScorePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    private void HandleQuitButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        Application.Quit();
    }

    private void HandleTutorialBackButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        tutorialPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private void HandleAudioSettingsBackButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        audioSettingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private void HandleHighScoreBackButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        highScorePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private void HandleMasterVolumeSliderValueChanged(float value)
    {
        AudioListener.volume = value;
    }
}
