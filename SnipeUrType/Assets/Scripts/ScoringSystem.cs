using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private string resultsSceneName = "TimesUp";

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

        var applicant = ApplicantSession.CurrentApplicant;

        int score = 0;

        if (applicant != null && applicant.IdealAttributes != null && person != null && person.Attributes != null)
        {
            score = ComputeScore(applicant.IdealAttributes, person.Attributes);
        }
        ScoreSession.status = 2;
        ScoreSession.score = score;
        SceneManager.LoadScene(resultsSceneName);

    }
    public void Miss()
    {
        if (resolved) return;
        resolved = true;

        ScoreSession.status = 1;
        ScoreSession.score = 0;
        SceneManager.LoadScene(resultsSceneName);
    }

    public void TimeUp()
    {
        if (resolved) return;
        resolved = true;

        ScoreSession.status = 0;
        ScoreSession.score = 0;
        SceneManager.LoadScene(resultsSceneName);
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
        Count(shot.EyeType == target.EyeType);
        Count(shot.FacialHair == target.FacialHair);
        Count(shot.TopType == target.TopType);
        Count(shot.BottomType == target.BottomType);
        Count(shot.Freckles == target.Freckles);
        Count(shot.Special == target.Special);

        if (target.Special)
            Count(shot.SpecialBodyType == target.SpecialBodyType);

        Count(Mathf.Abs(shot.Height - target.Height) <= 0.15f);
        Count(Mathf.Abs(shot.Mass - target.Mass) <= 0.15f);

        Count(ColorDistance(shot.HairColor, target.HairColor) <= 0.15f);
        Count(ColorDistance(shot.SkinColor, target.SkinColor) <= 0.15f);
        Count(ColorDistance(shot.EyeColor, target.EyeColor) <= 0.15f);

        Count(shot.Personality == target.Personality);

        if (total == 0) return 0;
        return Mathf.RoundToInt((matches/(float) total)*100f);
    }
    
    private float ColorDistance(Color a, Color b)
    {
        return Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b);
    }
}
