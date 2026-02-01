using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer: MonoBehaviour {
    public float targetTime = 60.0f;
    public TMP_Text timeText;
    private bool isRunning = true;

    void Update() {

        if (!isRunning) return;    

        targetTime -= Time.deltaTime;
        DisplayTime(targetTime);
        if (targetTime <= 10.0f) {
            timeText.color = Color.red;
            
        }
        if (targetTime <= 0.0f) {
            timerEnded();
        }
    }

    void DisplayTime(float time) {
        int seconds = Mathf.CeilToInt(time);
        timeText.text = seconds.ToString();
    }
    
    public void StopTimer()
    {
        isRunning = false;
    }

    void timerEnded() {
        Debug.Log("times up!");
        FindFirstObjectByType<ScoringSystem>()?.TimeUp();
        SceneManager.LoadScene("Score");
    }
}