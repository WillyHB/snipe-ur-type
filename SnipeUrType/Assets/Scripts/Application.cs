using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Application : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Applicant applicant;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Address;
    public TextMeshProUGUI City;
    public Image Signature;

    public TextMeshProUGUI Physical;
    public TextMeshProUGUI Personality;
    void Start()
    {
        applicant = Applicant.GetNewApplicant();
        ApplicantSession.CurrentApplicant = applicant;
        Name.text = applicant.FirstName + " "  + applicant.LastName;
        Address.text = applicant.StreetNumber + " " + applicant.Street;
        City.text = applicant.City;
        Signature.sprite = applicant.Signature;
        Personality.text = applicant.IdealAttributes.Personality;
        Physical.text = Helpers.GetRandom(applicant.IdealAttributes.HairStyle.Descriptions) + "\n"
            + Helpers.GetRandom(applicant.IdealAttributes.BodyType.Descriptions) + "\n"
            + Helpers.GetRandom(applicant.IdealAttributes.EyeType.Descriptions) + "\n";
    }

}
