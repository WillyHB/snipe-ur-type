using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private string resultsSceneName = "Score";
    [SerializeField] private float resultsDelay = 1f;
    [SerializeField] private float hitDelay = 4f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip drumRoll;
    [SerializeField] private AudioClip boo;

    [SerializeField] private GameObject k;

    private bool resolved;

    private void OnEnable()
    {
        ShootController.OnPersonShot += HandleHit;
    }

    private void OnDisable()
    {
        ShootController.OnPersonShot -= HandleHit;
    }

    private void HandleHit(Person person)
    {
        if (resolved) return;
        resolved = true;

        if (GameManager.instance != null)
            GameManager.instance.KeepOnly(person);

        //if (person.Attributes.Special)
        //{
        //    Debug.Log(person.Attributes.SpecialBodyType.name);
        //}

        var applicant = ApplicantSession.CurrentApplicant;

        int score = 0;

        if (applicant != null && applicant.IdealAttributes != null && person != null && person.Attributes != null)
        {
            score = ComputeScore(applicant.IdealAttributes, person.Attributes);
        }

        if (person.Attributes.Special && person.Attributes.SpecialBodyType.name == "Ben")
        {
            ScoreSession.status = 3;
        }
        else
        {
            ScoreSession.status = 2;
        }
        ScoreSession.score = score;
        StartCoroutine(LoadResultsAfterDelay(person));

    }
    public void Miss()
    {
        if (resolved) return;
        resolved = true;

        if (GameManager.instance != null)
            GameManager.instance.ClearAllPeople();

        ScoreSession.status = 1;
        ScoreSession.score = 0;
        StartCoroutine(LoadResultsAfterDelay(null));
    }

    public void TimeUp()
    {
        if (resolved) return;
        resolved = true;

        if (GameManager.instance != null)
            GameManager.instance.ClearAllPeople();

        ScoreSession.status = 0;
        ScoreSession.score = 0;
        StartCoroutine(LoadResultsAfterDelay(null));
    }

    private IEnumerator LoadResultsAfterDelay(Person? person)
    {
        ApplicantSession.CurrentApplicant = null;
        GameCounter.Counter++;
        if (ScoreSession.status == 3 && audioSource != null && drumRoll != null) 
        {
            Instantiate(k, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(2.7f);
            SceneManager.LoadScene("MainMenu");
        }
        if (ScoreSession.status == 2 && audioSource != null && drumRoll != null) 
        {
            audioSource.PlayOneShot(drumRoll);
            yield return new WaitForSeconds(hitDelay);
            SceneManager.LoadScene(resultsSceneName);
        }
        if (ScoreSession.status == 1 && audioSource != null && boo != null) 
        {
            audioSource.PlayOneShot(boo);
            yield return new WaitForSeconds(resultsDelay);
            SceneManager.LoadScene(resultsSceneName);
        }
        if (ScoreSession.status == 0) 
        {
            yield return new WaitForSeconds(resultsDelay);
            SceneManager.LoadScene(resultsSceneName);
        }
    }

    private int ComputeScore(Attributes target, Attributes shot)
    {

        int matches = 0;
        int total = 0;

        void Count(bool condition)
        {
            total++;
            if (condition) matches++;
        }

        Count(shot.HairStyle == target.HairStyle);
        Count(shot.BodyType == target.BodyType);
        Count(shot.FacialHair == target.FacialHair);
        Count(shot.TopType == target.TopType);
        Count(shot.BottomType == target.BottomType);
        Count(shot.Special == target.Special);

        if (target.Special)
            Count(shot.SpecialBodyType == target.SpecialBodyType);

        Count(Mathf.Abs(shot.Height - target.Height) <= 0.15f);
        Count(Mathf.Abs(shot.Mass - target.Mass) <= 0.15f);

        Count(ColorDistance(shot.HairColor, target.HairColor) <= 0.15f);
        Count(ColorDistance(shot.SkinColor, target.SkinColor) <= 0.15f);

        Count(shot.Personality == target.Personality);

        if (total == 0) return 0;
        return Mathf.RoundToInt((matches/(float) total)*100f);
    }
    
    private float ColorDistance(Color a, Color b)
    {
        return Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b);
    }
}
