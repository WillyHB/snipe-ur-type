using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
//show times up if out of time
//show missed if missed
//show score otherwise

//play successful music upon score 50% or more
//play failure music otherwise
{
    public int status; //0 if out of time, 1 if missed, 2 if hit
    public int score; //from 0 to 100
    public TextMeshProUGUI display;
    public AudioSource success;
    public AudioSource failure;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = ScoreSession.status;
        score = ScoreSession.score;

        switch(status)
        {
            case 0:
                ShowText("Time's up!");
                PlayFailure();
                break;
            case 1:
                ShowText("Missed :(");
                PlayFailure();
                break;
            default: //hit person
                ShowText("Score: " + score.ToString());
                if (score >= 50)
                {
                    PlaySuccess();
                }
                else
                {
                    PlayFailure();
                }
                break;
        }
        
    }

    void PlaySuccess()
    {
        success.Play();
    }

    void PlayFailure()
    {
        failure.Play();
    }

    void ShowText(string text)
    {
        display.text = text;
    }
}
