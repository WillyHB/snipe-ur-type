using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Application : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Applicant applicant { get; private set; }

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Address;
    public TextMeshProUGUI City;
    public TextMeshProUGUI Date;
    public Image Signature;

    public TextMeshProUGUI Physical;
    public TextMeshProUGUI Personality;

    public TMP_FontAsset[] Fonts;
    void Start()
    {
        TMP_FontAsset font = Helpers.GetRandom(Fonts);

        Name.font = font;
        Address.font = font;
        City.font = font;
        Date.font = font;
        Physical.font = font;
        Personality.font = font;

        applicant = Applicant.GetNewApplicant();
        ApplicantSession.CurrentApplicant = applicant;
        
        Name.text = applicant.FirstName + " "  + applicant.LastName;
        Address.text = applicant.StreetNumber + " " + applicant.Street;
        City.text = applicant.City;
        Signature.sprite = applicant.Signature;
        Personality.text = applicant.IdealAttributes.Personality;

        if (applicant.IdealAttributes.Special) {
            Physical.text = applicant.IdealAttributes.SpecialBodyType.Descriptions[0];
        } else
        {
            Physical.text = Helpers.GetRandom(applicant.IdealAttributes.HairStyle.Descriptions) + "\n"
                + Helpers.GetRandom(applicant.IdealAttributes.BodyType.Descriptions) + "\n"
                + Helpers.GetRandom(applicant.IdealAttributes.ShoeType.Descriptions) + "\n"
                + Helpers.GetRandom(applicant.IdealAttributes.TopType.Descriptions) + "\n"
                + Helpers.GetRandom(applicant.IdealAttributes.BottomType.Descriptions) + "\n"
                + Helpers.GetRandom(applicant.IdealAttributes.FacialHair.Descriptions) ?? "Has no beard" + "\n";

        }
    }
}
