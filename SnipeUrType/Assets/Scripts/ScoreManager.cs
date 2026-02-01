using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
//show times up if out of time
//show missed if missed
//show score otherwise

//play successful music upon score 50% or more
//play failure music otherwise
{
    public static int status; //0 if out of time, 1 if missed, 2 if hit
    public static int score; //from 0 to 100
    public TextMeshProUGUI display;
    public AudioSource success;
    public AudioSource failure;
    public GameObject hearts;
    public GameObject brokenhearts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject review;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log($"Score scene cursor: visible={Cursor.visible}, lock ={Cursor.lockState}");
        status = ScoreSession.status;
        score = ScoreSession.score;
        review.SetActive(false);

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
            case 2: //hit person
                ShowText("Score: " + score.ToString()+ "%");
                if (score >= 50)
                {
                    PlaySuccess();
                }
                else
                {
                    PlayFailure();
                }
                //get reviews
                review.SetActive(true);
                if (score < 10) writeReview("“I can’t believe you matched me with my cousin >:(. You should quit this game now");
                else if (score >= 10 && score < 20) writeReview("Is Cupid blind?");
                else if (score >= 20 && score < 30) writeReview("Terrible service. 1/5 stars");
                else if (score >= 30 && score < 40) writeReview("Maybe don’t match me with a serial cheater"); 
                else if (score >= 40 && score < 50) writeReview("Ugh, should have just used a dating app instead");
                else if (score >= 50 && score < 60) writeReview("The date was just ok");
                else if (score >= 60 && score < 70) writeReview("This might be better than those dating apps…");
                else if (score >= 70 && score < 80) writeReview("I think I’m giving love a second chance!");
                else if (score >= 80 && score < 90) writeReview("I think I’ve just found the love of my life!");
                else writeReview("Omg, Cupid is invited to my wedding");

                break;
            case 3: //kaitlin kills you
                ShowText("You died:(");
                PlayFailure();
                break;
        }
        
    }

    void PlaySuccess()
    {
        brokenhearts.SetActive(false);
        hearts.SetActive(true);
        success.Play();
    }

    void PlayFailure()
    {
        brokenhearts.SetActive(true);
        hearts.SetActive(false);
        failure.Play();
    }

    void ShowText(string text)
    {
        display.text = text;
    }

    void writeReview(string reviewtext)
    {
        review.transform.GetChild(0).GetComponent<TMP_Text>().text = reviewtext;
    }
}
