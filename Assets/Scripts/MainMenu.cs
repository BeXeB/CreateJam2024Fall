using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject audioSettingsPanel;
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private GameObject mainMenuPanel;
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button audioSettingsButton;
    [SerializeField] private Button highScoreButton;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private Button audioSettingsBackButton;
    [SerializeField] private Slider masterVolumeSlider;

    [SerializeField] private Button highScoreBackButton;

    private void Awake()
    {
        mainMenuPanel.SetActive(true);
        audioSettingsPanel.SetActive(false);
        
        masterVolumeSlider.value = AudioListener.volume;
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(HandlePlayButtonClicked);
        audioSettingsButton.onClick.AddListener(HandleAudioSettingsButtonClicked);
        highScoreButton.onClick.AddListener(HandleHighScoreButtonClicked);
        quitButton.onClick.AddListener(HandleQuitButtonClicked);
        
        audioSettingsBackButton.onClick.AddListener(HandleAudioSettingsBackButtonClicked);
        masterVolumeSlider.onValueChanged.AddListener(HandleMasterVolumeSliderValueChanged);

        highScoreBackButton.onClick.AddListener(HandleHighScoreBackButtonClicked);
    }
    
    private void OnDisable()
    {
        playButton.onClick.RemoveListener(HandlePlayButtonClicked);
        audioSettingsButton.onClick.RemoveListener(HandleAudioSettingsButtonClicked);
        highScoreButton.onClick.RemoveListener(HandleHighScoreButtonClicked);
        quitButton.onClick.RemoveListener(HandleQuitButtonClicked);
        
        audioSettingsBackButton.onClick.RemoveListener(HandleAudioSettingsBackButtonClicked);
        masterVolumeSlider.onValueChanged.RemoveListener(HandleMasterVolumeSliderValueChanged);

        highScoreBackButton.onClick.RemoveListener(HandleHighScoreBackButtonClicked);
    }

    private void HandlePlayButtonClicked()
    {
        AudioMananger.instance.PlayAudioClip("Button");
        AudioMananger.instance.PlayMusicClip("Game");
        SceneManager.LoadScene("SampleScene");
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
