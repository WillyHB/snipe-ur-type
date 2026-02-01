using UnityEngine;

public class AudioComment : MonoBehaviour
{
    public Application Application;
    private bool played = false;

    private void Update()
    {
        if (Application.applicant == null || played) return;
        played = true;
        GetComponent<AudioSource>().clip
            = Application.applicant.IdealAttributes.Special
            ? Application.applicant.IdealAttributes.SpecialBodyType.AudioComment
            : Application.applicant.IdealAttributes.BodyType.AudioComment;
        GetComponent<AudioSource>().Play();
    }
}
