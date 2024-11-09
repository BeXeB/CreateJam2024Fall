using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float startTime = 60f;
    private float timeLeft;
    private bool timerOn = false;
    [SerializeField]
    private TextMeshProUGUI timerTxt;
    [SerializeField]
    private Slider timerSlider;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject player;

    public float TimeLeft
    {
        get => timeLeft;
        private set => timeLeft = value;
    }
    
    public float StartTime
    {
        get => startTime;
        private set => startTime = value;
    }
    
    void Start()
    {
        timerOn = true;
        timerSlider.value = 0;
        timerSlider.maxValue = startTime;
        timeLeft = startTime;
    }

    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                player.GetComponent<PlayerInput>().DeactivateInput();
                gameOverPanel.SetActive(true);
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerSlider.value = currentTime;
    }
}
