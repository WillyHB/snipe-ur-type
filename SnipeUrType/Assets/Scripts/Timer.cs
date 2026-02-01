using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer: MonoBehaviour {
    public float targetTime = 120.0f;
    public TMP_Text timeText;

    void Update() {
        targetTime -= Time.deltaTime;
        DisplayTime(targetTime);
        if (targetTime <= 0.0f) {
            Debug.Log("times up!");
            timerEnded();
        }
    }

    void DisplayTime(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void timerEnded() {
        ScoreManager.status = 0;
        SceneManager.LoadScene("Score");
        Debug.Log("times up!");
        FindFirstObjectByType<ScoringSystem>()?.TimeUp();
    }
}