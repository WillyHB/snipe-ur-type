using UnityEngine;
using TMPro;

public class Applicant
{
    private static string[] firstNames =
    {
        "Bob",
        "John",
        "Thomas",
        "Dylan",
        "Zhi",
        "Ben",
        "Davis",
        "David",
        "George",
        "Jared",
        "Jacob",
        "Felix",
        "Elias",
        "Hugo",
        "Tobias",
        "Orion",
        "Enzo",
        "Aleksandra",
        "Alexandra",
        "Sarah",
        "Hannah",
        "Olivia",
        "Emma",
        "Ava",
        "Eva",
        "Charlotte",
        "Abigail",
        "Addison",
        "Daisy",
        "Camila"
    };

    private static string[] lastNames =
    {
        "Smith",
        "Bush",
        "Martin",
        "Nguyen",
        "Johnson",
        "Brown",
        "Garcia",
        "Miller",
        "Taylor",
        "Baker",
        "Woods",
        "Baird",
        "McGill",
        "Horsey",
        "Adams",
        "Anderson",
        "Clark",
        "Jones",
        "Lewis",
        "Brook",
        "King"
    };

    private static string[] streetNames =
    {
        "Forest Row",
        "Monument Avenue",
        "Ocean Lane",
        "Royalty Way",
        "Mason Avenue",
        "Dew Street",
        "Shade Lane",
        "Rue Durocher",
        "University Street",
        "Pine Street",
        "Blossom Boulevard",
        "Summit Lane",
        "Broadway",
        "Grime Route",
        "The Horse Street",
        "River Lane"
    };

    private static string[] cities =
    {
        "Montreal",
        "New York City",
        "San Diego",
        "Los Angeles",
        "Brussels",
        "Tokyo",
        "Sydney",
        "Lagos",
        "Quebec City",
        "Labrador",
        "Ottawa",
        "Toronto",
        "Vancouver",
        "Calgary",
    };

    public Attributes IdealAttributes { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public int StreetNumber { get; private set; }

    public Sprite Signature { get; private set; }

    public string DesiredPhysical { get; private set; }

    public TMP_FontAsset Handwriting;

    public static Applicant GetNewApplicant(bool getSpecial = false)
    {
        Attributes attr = Attributes.GetRandomAttr(getSpecial);
        string hair = Helpers.GetRandom(attr.HairStyle.Descriptions);
        string body = Helpers.GetRandom(attr.BodyType.Descriptions);
        string shoe = Helpers.GetRandom(attr.ShoeType.Descriptions);
        string top = Helpers.GetRandom(attr.TopType.Descriptions);
        string bottom = Helpers.GetRandom(attr.BottomType.Descriptions);
        string beard = attr.Female ? "Has no beard. None at all." : Helpers.GetRandom(attr.FacialHair.Descriptions);
        string physical = attr.Special ? attr.SpecialBodyType.Descriptions[0] : hair + "\n" + body + "\n" + shoe + "\n" + top + "\n" + bottom + "\n" + beard;
        return new()
        {
            IdealAttributes = attr,
            FirstName = Helpers.GetRandom(firstNames),
            LastName = Helpers.GetRandom(lastNames),
            City = Helpers.GetRandom(cities),
            Street = Helpers.GetRandom(streetNames),
            StreetNumber = Random.Range(1, 1000),
            Signature = DataManager.instance.Signatures[Random.Range(0, DataManager.instance.Signatures.Length)],
            DesiredPhysical = physical,
            Handwriting = Helpers.GetRandom(DataManager.instance.HandwrittenFonts),
        };
    }
}
