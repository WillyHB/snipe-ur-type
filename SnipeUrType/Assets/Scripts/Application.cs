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

    public bool canHide;
    public GameObject[] DisableOnHide;

    private bool pressed;
    private bool hidden = true;
    void Start()
    {
        if (!canHide)LeanTween.moveLocalY(Page, 0, 1f).setEaseOutQuad();


        if (ApplicantSession.CurrentApplicant == null)
        {
            applicant = Applicant.GetNewApplicant(GameCounter.Counter >= 3 && GameCounter.Counter <= 5);
            ApplicantSession.CurrentApplicant = applicant;
        }else
        {
            applicant = ApplicantSession.CurrentApplicant;
        }

        Name.text = applicant.FirstName + " "  + applicant.LastName;
        Address.text = applicant.StreetNumber + " " + applicant.Street;
        City.text = applicant.City;
        Signature.sprite = applicant.Signature;
        Personality.text = applicant.IdealAttributes.Personality;

        Physical.text = applicant.DesiredPhysical;

        Name.font = applicant.Handwriting;
        Address.font = applicant.Handwriting;
        City.font = applicant.Handwriting;
        Date.font = applicant.Handwriting;
        Physical.font = applicant.Handwriting;
        Personality.font = applicant.Handwriting;
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
