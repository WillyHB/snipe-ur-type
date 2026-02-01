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
    public GameObject Page;

    public TMP_FontAsset[] Fonts;

    public bool canHide;
    public GameObject[] DisableOnHide;

    private bool pressed;
    private bool hidden = true;
    void Start()
    {
        if (!canHide) LeanTween.moveLocalY(Page, 0, 1f).setEaseOutQuad();
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
            string hair = Helpers.GetRandom(applicant.IdealAttributes.HairStyle.Descriptions);
            string body = Helpers.GetRandom(applicant.IdealAttributes.BodyType.Descriptions);
            string shoe = Helpers.GetRandom(applicant.IdealAttributes.ShoeType.Descriptions);
            string top = Helpers.GetRandom(applicant.IdealAttributes.TopType.Descriptions);
            string bottom = Helpers.GetRandom(applicant.IdealAttributes.BottomType.Descriptions);
            string beard = Helpers.GetRandom(applicant.IdealAttributes.ShoeType.Descriptions) ?? "Has no beard. None at all.";
            Physical.text = hair + "\n" + body + "\n" + shoe + "\n" + top + "\n" + bottom + "\n" + beard;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!canHide) return;
            if (LeanTween.isTweening(Page)) return;

            if (!pressed)
            {
                Page.transform.localPosition = new Vector2(0, hidden ? -500 : 0);
                LeanTween.moveLocalY(Page, hidden ? 0 : -500, 0.25f).setEaseInOutQuad();
                hidden = !hidden;
                foreach (var go in DisableOnHide)
                {
                    go.SetActive(hidden);
                }
            }
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }
}
