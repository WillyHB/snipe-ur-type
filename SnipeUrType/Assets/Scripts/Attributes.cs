using UnityEngine;

public class Attributes
{
    private static Color32[] SkinColors =
    {
        new Color(232,231,178,255), // White
        new Color(110,78,44,255), // Black
        new Color(64,129,217,255), // Blue
        new Color(71,207,48,255), // Green
        new Color(225,235,122,255), // Jaundice
        new Color(243,245,219,255), // Pale
        new Color(232,175,216,255), // Pink
    };

    private static Color32[] HairColors =
    {
        new(206,232,99, 255), // Yellow Blonde
        new(176,189,123,255), // Dirty Blonde
        new(241,245,226, 255), // Fair Blonde / White
        new(79,57,41, 255), // Brunette
        new(26,12,1,255), // Black
        new(212,109,31,255), // Redhead
        new(48,232,79, 255), // Green
        new(108,48,232,255), // Blue
        new(232,48,48,255), // Red
    };

    private static string[] personalities =
    {
        "Loves horse riding",
        "Is a big fan of bowling",
        "Is just like so awesome",
        "Is a biiig fan of gacha games",
        "Has a car??",
        "Is not like weird",
        "Looks like they'd maybe know a thing or two about the anatomy of a horse (Important)",
        "Looks cool",
        "Is Alive?",
        "Idk?",
        "Has a JOB",
        "Is Funny",
        "Doesn't act the way they look.",
        "DONATES TO CHARITY",
        "Doesn't want me",
        "Doesn't hate me",
        "Is able to walk"
    };

    public HairStyle HairStyle { get; private set; }
    public BodyType BodyType { get; private set; }
    public EyeType EyeType { get; private set; }
    public FacialHair FacialHair { get; private set; }

    public float Height { get; private set; }
    public float Mass { get; private set; }

    public Color HairColor { get; private set; }
    public Color SkinColor { get; private set; }
    public Color EyeColor { get; private set; }


    public bool Freckles { get; private set; }

    public bool Special { get; private set; }
    public BodyType SpecialBodyType { get; private set; }

    public string Personality { get; private set; }

    public Attributes() { }

    public static Attributes GetRandomAttr()
    {
        return new Attributes()
        {
            HairStyle = Helpers.GetRandom(GameManager.instance.HairStyles.Styles),
            BodyType = Helpers.GetRandom(GameManager.instance.BodyTypes.Types),
            EyeType = Helpers.GetRandom(GameManager.instance.EyeTypes.Types),
            FacialHair = Helpers.GetRandom(GameManager.instance.FacialHairs.Styles),

            HairColor = Helpers.GetRandom(HairColors),
            SkinColor = Helpers.GetRandom(SkinColors),

            EyeColor = Random.ColorHSV(),
            Freckles = Random.Range(0f, 1f) < 0.5,
            Special = Random.Range(0f, 1f) < 0.5,//Random.Range(0, 100) == 1,
            SpecialBodyType = Helpers.GetRandom(GameManager.instance.SpecialBodyTypes.Types),

            Height = Random.Range(0.5f, 2f),
            Mass = Random.Range(0.5f, 2f),
            Personality = Helpers.GetRandom(personalities),
        };
    }
}

